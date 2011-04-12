//
//  Just_Cause_2_GPSViewController.m
//  Just Cause 2 GPS
//
//  Created by Luke Perkin on 09/04/2011.
//  Copyright 2011 MetFilm. All rights reserved.
//

#import "Just_Cause_2_GPSViewController.h"
#import "ImageScrollView.h"
#import "TilingView.h"

@implementation Just_Cause_2_GPSViewController
@synthesize echo=_echo;

- (void)dealloc
{
    [imageScrollView release];
    [altitudeLabel release];
    [speedLabel release];
    [infoBar release];
    [speedPreLabel release];
    [altitudePreLabel release];
    [super dealloc];
}

- (void)didReceiveMemoryWarning
{
    // Releases the view if it doesn't have a superview.
    [super didReceiveMemoryWarning];
    
    // Release any cached data, images, etc that aren't in use.
}

- (BOOL)runServerOnPort:(NSUInteger)port
// One of two Objective-C 'mains' for this program.  This creates a UDPEcho 
// object and runs it in server mode.
{
    assert(self.echo == nil);
    
    self.echo = [[[UDPEcho alloc] init] autorelease];
    assert(self.echo != nil);
    
    self.echo.delegate = self;
    
    [self.echo startServerOnPort:port];
    
    //while (self.echo != nil) {
    //    [[NSRunLoop currentRunLoop] runMode:NSDefaultRunLoopMode beforeDate:[NSDate distantFuture]];
    //}
    
    // The loop above is supposed to run forever.  If it doesn't, something must 
    // have failed and we want main to return EXIT_FAILURE.
    
    return NO;
}

- (void)echo:(UDPEcho *)echo didReceiveData:(NSData *)data fromAddress:(NSData *)addr
// This UDPEcho delegate method is called after successfully receiving data.
{
    assert(echo == self.echo);
    #pragma unused(echo)
    assert(data != nil);
    assert(addr != nil);
    
    NSString *datastr = [[NSString alloc] initWithData:data encoding:NSStringEncodingConversionAllowLossy];
    
    NSArray *values = [datastr componentsSeparatedByString:@","];
    
    [imageScrollView.player setPos:[[values objectAtIndex:0] intValue] y:[[values objectAtIndex:1] intValue]];
    
    [altitudeLabel setText:[NSString stringWithFormat:@"%@m", [values objectAtIndex:2]]];
    [speedLabel setText:[NSString stringWithFormat:@"%@km/h", [values objectAtIndex:3]]];
    
    [datastr release];
}

#pragma mark - View lifecycle

- (void)didRotateDevice:(id)sender
{
    UIDeviceOrientation orentation = [[UIDevice currentDevice] orientation];
    if (UIDeviceOrientationIsPortrait(orentation)) {
        infoBar.hidden = NO;
        altitudePreLabel.hidden = NO;
        altitudeLabel.hidden = NO;
        speedPreLabel.hidden = NO;
        speedLabel.hidden = NO;
    } else {
        infoBar.hidden = YES;
        altitudePreLabel.hidden = YES;
        altitudeLabel.hidden = YES;
        speedPreLabel.hidden = YES;
        speedLabel.hidden = YES;
    }
}

// Handle double finger tap.
- (void)handleTapFrom:(UITapGestureRecognizer *)recognizer
{
    [imageScrollView jumpToPlayer];
}


// Implement viewDidLoad to do additional setup after loading the view, typically from a nib.
- (void)viewDidLoad
{
    [super viewDidLoad];
    
    // Load scrolling view with map.
    imageScrollView = [[ImageScrollView alloc] initWithFrame:CGRectMake(0, 0, 320, 480)];
    [self.view addSubview:imageScrollView];
    [imageScrollView displayTiledImageNamed:@"Map" size:CGSizeMake(2048, 2048)];
    [self.view sendSubviewToBack:imageScrollView];
    
    // Start listen server for incoming UDP messages.
    [self runServerOnPort:49898];
    
    // Listen for device rotation change.
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(didRotateDevice:) name:@"UIDeviceOrientationDidChangeNotification" object:nil];
    
    // Listen for double taps.
    UITapGestureRecognizer *doubleTapRecognizer;
    doubleTapRecognizer = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(handleTapFrom:)];
    [self.view addGestureRecognizer:doubleTapRecognizer];
    
}


- (void)viewDidUnload
{
    [imageScrollView release];
    imageScrollView = nil;
    [altitudeLabel release];
    altitudeLabel = nil;
    [speedLabel release];
    speedLabel = nil;
    [infoBar release];
    infoBar = nil;
    [speedPreLabel release];
    speedPreLabel = nil;
    [altitudePreLabel release];
    altitudePreLabel = nil;
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    // Return YES for supported orientations
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}


@end
