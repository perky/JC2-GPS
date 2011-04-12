//
//  PlayerPin.m
//  Just Cause 2 GPS
//
//  Created by Luke Perkin on 10/04/2011.
//  Copyright 2011 MetFilm. All rights reserved.
//

#import "PlayerPin.h"


@implementation PlayerPin
@synthesize x, y;

- (id)initWithFrame:(CGRect)frame
{
    self = [super initWithFrame:frame];
    if (self) {
        // Initialization code
        self.backgroundColor = [UIColor clearColor];
        
        UIImage *pinimg = [UIImage imageNamed:@"google_pin.png"];
        pin = [[UIImageView alloc] initWithImage:pinimg];
        [self addSubview:pin];
        
        [self setPos:1000 y:1000];
        lastTime = nil;
    }
    return self;
}

- (void)dealloc
{
    [lastTime release];
    [pin release];
    [super dealloc];
}

- (void)setPos:(int)xx y:(int)yy
{    
    self.x = xx;
    self.y = yy;
    
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

@end
