//
//  Just_Cause_2_GPSViewController.h
//  Just Cause 2 GPS
//
//  Created by Luke Perkin on 09/04/2011.
//  Copyright 2011 MetFilm. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "UDPEcho.h"
#import "ImageScrollView.h"

@interface Just_Cause_2_GPSViewController : UIViewController <UDPEchoDelegate>
{
    
    IBOutlet UIView *infoBar;
    IBOutlet UILabel *speedLabel;
    IBOutlet UILabel *altitudeLabel;
    IBOutlet UILabel *speedPreLabel;
    IBOutlet UILabel *altitudePreLabel;
    ImageScrollView *imageScrollView;
    UDPEcho *_echo;
}

@property (nonatomic, retain) UDPEcho *echo;

@end
