#import "Image/RCTImageView.h"
#import "Image/RCTImageUtils.h"
#import "RNColorMatrixImageFilter.h"


static CIContext* context;

@interface UIImage (React)

@property (nonatomic, copy) CAKeyframeAnimation *reactKeyframeAnimation;

@end


@interface RNColorMatrixImageFilter ()

@property (nonatomic, strong) CIFilter* filter;
@property (nonatomic, strong) UIImage *inputImage;
@property (nonatomic, weak) RCTImageView *target;

@end


@implementation RNColorMatrixImageFilter

- (instancetype)initWithFrame:(CGRect)frame
{
  if ((self = [super initWithFrame:frame])) {
    static dispatch_once_t onceToken;
    
    dispatch_once(&onceToken, ^{
      NSDictionary *options = @{kCIImageColorSpace: [NSNull null],
                                kCIImageProperties: [NSNull null],
                                kCIContextWorkingColorSpace: [NSNull null]};
      
      context = [RNColorMatrixImageFilter createContextWithOptions:options];
    });
    
    _filter = [CIFilter filterWithName:@"CIColorMatrix"];
  }
  
  return self;
}

- (void)dealloc
{
  [self unlinkTarget];
}

- (void)layoutSubviews
{
  [super layoutSubviews];
  
  [self linkTarget];
}

- (void)linkTarget
{
  for (UIView *child in self.subviews) {
    if ([child isKindOfClass:[RCTImageView class]] && !_target) {
      _target = (RCTImageView *)child;
      [child addObserver:self
              forKeyPath:@"image"
                 options:NSKeyValueObservingOptionNew
                 context:NULL];
      break;
    }
  }
}

- (void)unlinkTarget
{
  if (_target) {
    [_target removeObserver:self forKeyPath:@"image"];
    _target = nil;
  }
}

- (void)observeValueForKeyPath:(NSString *)keyPath
                      ofObject:(id)object
                        change:(NSDictionary *)change
                       context:(void *)context {
  if ([keyPath isEqualToString:@"image"]) {
    _inputImage = [_target.image copy];
    NSLog(@"filter: %@", _inputImage);
    [self renderFilteredImage];
  }
}

- (void)didSetProps:(NSArray<NSString *> *)changedProps
{
  if ([changedProps containsObject:@"matrix"]) {
    CGFloat m[20] = {
      [_matrix[0] floatValue], [_matrix[1] floatValue], [_matrix[2] floatValue], [_matrix[3] floatValue],
      [_matrix[5] floatValue], [_matrix[6] floatValue], [_matrix[7] floatValue], [_matrix[8] floatValue],
      [_matrix[10] floatValue], [_matrix[11] floatValue], [_matrix[12] floatValue], [_matrix[13] floatValue],
      [_matrix[15] floatValue], [_matrix[16] floatValue], [_matrix[17] floatValue], [_matrix[18] floatValue],
      [_matrix[4] floatValue], [_matrix[9] floatValue], [_matrix[14] floatValue], [_matrix[19] floatValue]
    };
    
    [_filter setValue:[CIVector vectorWithValues:&m[0] count:4] forKey:@"inputRVector"];
    [_filter setValue:[CIVector vectorWithValues:&m[4] count:4] forKey:@"inputGVector"];
    [_filter setValue:[CIVector vectorWithValues:&m[8] count:4] forKey:@"inputBVector"];
    [_filter setValue:[CIVector vectorWithValues:&m[12] count:4] forKey:@"inputAVector"];
    [_filter setValue:[CIVector vectorWithValues:&m[16] count:4] forKey:@"inputBiasVector"];
    
    [self renderFilteredImage];
  }
}

- (void)renderFilteredImage
{
  if (_target) {
    UIImage *image = [self filteredImage:_inputImage resizeMode:_target.resizeMode];

    [_target removeObserver:self forKeyPath:@"image"];
    [_target setImage:image];
    [_target addObserver:self
              forKeyPath:@"image"
                 options:NSKeyValueObservingOptionNew
                 context:NULL];
  }
}

- (UIImage *)filteredImage:(UIImage *)image
                resizeMode:(RCTResizeMode)resizeMode
{
  if (image != nil) {
    CIImage *tmp = [[CIImage alloc] initWithImage:image];
    [_filter setValue:tmp forKey:@"inputImage"];
    
    CGRect outputRect = tmp.extent;
    
    CGImageRef cgim = [context createCGImage:_filter.outputImage fromRect:outputRect];
    
    UIImage *filteredImage = [RNColorMatrixImageFilter resizeImageIfNeeded:[UIImage imageWithCGImage:cgim]
                                                                   srcSize:outputRect.size
                                                                  destSize:image.size
                                                                     scale:image.scale
                                                                resizeMode:resizeMode];
    
    CGImageRelease(cgim);
    
    return filteredImage;
  }
  
  return nil;
}

+ (CIContext *)createContextWithOptions:(nullable NSDictionary<NSString *, id> *)options
{
  // CFAbsoluteTime start = CFAbsoluteTimeGetCurrent();
  EAGLContext *eaglContext = [[EAGLContext alloc] initWithAPI:kEAGLRenderingAPIOpenGLES3];
  eaglContext = eaglContext ?: [[EAGLContext alloc] initWithAPI:kEAGLRenderingAPIOpenGLES2];
  
  CIContext *context = [CIContext contextWithEAGLContext:eaglContext options:options];
  // NSLog(@"filter: context %f", CFAbsoluteTimeGetCurrent() - start);
  
  return context;
}

+ (UIImage *)resizeImageIfNeeded:(UIImage *)image
                         srcSize:(CGSize)srcSize
                        destSize:(CGSize)destSize
                           scale:(CGFloat)scale
                      resizeMode:(RCTResizeMode)resizeMode
{
  if (CGSizeEqualToSize(destSize, CGSizeZero) ||
      CGSizeEqualToSize(srcSize, CGSizeZero) ||
      CGSizeEqualToSize(srcSize, destSize)) {
    return image;
  }
  
  CAKeyframeAnimation *animation = image.reactKeyframeAnimation;
  CGRect targetSize = RCTTargetRect(srcSize, destSize, scale, resizeMode);
  CGAffineTransform transform = RCTTransformFromTargetRect(srcSize, targetSize);
  image = RCTTransformImage(image, destSize, scale, transform);
  image.reactKeyframeAnimation = animation;
  
  return image;
}

@end
