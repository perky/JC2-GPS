//
//  PlayerPin.h
//  Just Cause 2 GPS
//
//  Created by Luke Perkin on 10/04/2011.
//  Copyright 2011 MetFilm. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <QuartzCore/QuartzCore.h>


@interface PlayerPin : UIView {
    UIImageView *pin;
    NSDate *lastTime;
}

@property (assign) int x;
@property (assign) int y;

- (void)setPos:(int)x y:(int)y;

@end
