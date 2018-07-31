#import <React/RCTBridge.h>
#import "RNColorMatrixImageFilterManager.h"
#import "RNColorMatrixImageFilter.h"

@implementation RNColorMatrixImageFilterManager

@synthesize bridge = _bridge;

RCT_EXPORT_MODULE();

- (dispatch_queue_t)methodQueue
{
  return dispatch_get_main_queue();
}

- (UIView *)view
{
  return [[RNColorMatrixImageFilter alloc] init];
}

RCT_EXPORT_VIEW_PROPERTY(matrix, NSArray<NSNumber *>);

@end
