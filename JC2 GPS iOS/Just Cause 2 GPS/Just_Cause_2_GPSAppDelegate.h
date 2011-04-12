//
//  Just_Cause_2_GPSAppDelegate.h
//  Just Cause 2 GPS
//
//  Created by Luke Perkin on 09/04/2011.
//  Copyright 2011 MetFilm. All rights reserved.
//

#import <UIKit/UIKit.h>
#include <netdb.h>

@class Just_Cause_2_GPSViewController;

@interface Just_Cause_2_GPSAppDelegate : NSObject <UIApplicationDelegate> {
    
}

@property (nonatomic, retain) IBOutlet UIWindow *window;
@property (nonatomic, retain) IBOutlet Just_Cause_2_GPSViewController *viewController;

@end
