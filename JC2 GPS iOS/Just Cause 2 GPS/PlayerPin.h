//
//  PlayerPin.h
//  Just Cause 2 GPS
//
//  Created by Luke Perkin on 10/04/2011.
//  Copyright 2011 MetFilm. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <QuartzCore/QuartzCore.h>

@class TilingView;

@interface PlayerPin : UIView {
    UIImageView *pin;
    NSDate *lastTime;
    CGPoint *playerPath;
}

@property (nonatomic, assign) int playerPathSize;
@property (nonatomic, retain) TilingView *tileView;
@property (nonatomic, assign) CGPoint *playerPath;
@property (assign) int x;
@property (assign) int y;

- (void)setPos:(int)x y:(int)y;

@end
