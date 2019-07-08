#import <React/RCTResizeMode.h>

#ifndef CMIFResizable_h
#define CMIFResizable_h

@protocol CMIFResizable <NSObject>

- (UIImage *)image;
- (void)setImage:(UIImage *)image;
- (RCTResizeMode)resizeMode;

@end

#endif /* CMIFResizable_h */
