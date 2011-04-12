//
//  PlayerPin.m
//  Just Cause 2 GPS
//
//  Created by Luke Perkin on 10/04/2011.
//  Copyright 2011 MetFilm. All rights reserved.
//

#import "PlayerPin.h"


@implementation PlayerPin
@synthesize x, y, playerPath, tileView, playerPathSize;

- (id)initWithFrame:(CGRect)frame
{
    self = [super initWithFrame:frame];
    if (self) {
        // Initialization code
        self.backgroundColor = [UIColor clearColor];
        self.clearsContextBeforeDrawing = YES;
        self.opaque = NO;
        
        UIImage *pinimg = [UIImage imageNamed:@"google_pin.png"];
        pin = [[UIImageView alloc] initWithImage:pinimg];
        [self addSubview:pin];
        
        self.playerPath = calloc(2000, sizeof(CGPoint));
        self.playerPathSize = 0;

        lastTime = nil;
    }
    return self;
}

- (void)dealloc
{
    free(playerPath);
    [lastTime release];
    [pin release];
    [super dealloc];
}

- (void)setPos:(int)xx y:(int)yy
{    
    self.x = xx;
    self.y = yy;
    
    if (self.playerPathSize >= 2000) {
        free(self.playerPath);
        self.playerPath = calloc(2000, sizeof(CGPoint));
        self.playerPathSize = 0;
    } else if (self.playerPathSize == 0) {
        self.playerPath[ self.playerPathSize ] = CGPointMake(xx, yy);
        self.playerPathSize += 1;
    } else {
        if (!(self.playerPath[self.playerPathSize-1].x == xx && self.playerPath[self.playerPathSize-1].y == yy)) {
            self.playerPath[ self.playerPathSize ] = CGPointMake(xx, yy);
            self.playerPathSize += 1;
        }
    }
    
    [self.tileView setNeedsDisplay];
    
    float time = 1;
    if (lastTime) {
        time = [lastTime timeIntervalSinceDate:[NSDate date]];
    }
    lastTime = [[NSDate date] retain];
    
    [UIView beginAnimations:nil context:nil];
    [UIView setAnimationCurve:UIViewAnimationCurveLinear];
    [UIView setAnimationDuration:time];
    
    pin.center = CGPointMake(xx, yy-22);
    
    [UIView commitAnimations];
}

//- (void)drawRect:(CGRect)rect
//{
//    CGContextRef context = UIGraphicsGetCurrentContext();
//}

@end
