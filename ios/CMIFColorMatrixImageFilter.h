#import <React/UIView+React.h>

#ifdef RCT_NEW_ARCH_ENABLED
#import <React/RCTViewComponentView.h>
#else
#import <React/RCTView.h>
#endif

#ifdef RCT_NEW_ARCH_ENABLED
@interface CMIFColorMatrixImageFilter : RCTViewComponentView
#else
@interface CMIFColorMatrixImageFilter : RCTView

@property (nonatomic, strong) NSArray<NSNumber *> *matrix;
#endif

@end
