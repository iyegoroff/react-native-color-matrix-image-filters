#import "RCTImageUtils.h"
#import "CMIFColorMatrixImageFilter.h"
#import "CMIFResizable.h"

static CIContext* context;

@interface CMIFColorMatrixImageFilter ()

@property (nonatomic, strong) CIFilter* filter;
@property (nonatomic, strong) UIImage *inputImage;
@property (nonatomic, weak) NSObject<CMIFResizable> *target;

@end


@implementation CMIFColorMatrixImageFilter

- (instancetype)initWithFrame:(CGRect)frame
{
  if ((self = [super initWithFrame:frame])) {
    static dispatch_once_t onceToken;

    dispatch_once(&onceToken, ^{
      NSDictionary *options = @{kCIImageColorSpace: [NSNull null],
                                kCIImageProperties: [NSNull null],
                                kCIContextWorkingColorSpace: [NSNull null]};

      context = [CMIFColorMatrixImageFilter createContextWithOptions:options];
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
  UIView* parent = self;

  while (!_target && parent.subviews.count > 0) {
    UIView* child = parent.subviews[0];
    if ([child respondsToSelector:@selector(resizeMode)] &&
        [child respondsToSelector:@selector(image)] &&
        [child respondsToSelector:@selector(setImage:)]) {
      _target = (NSObject<CMIFResizable> *)child;
      _inputImage = [_target.image copy];

      [child addObserver:self
              forKeyPath:@"image"
                 options:NSKeyValueObservingOptionNew
                 context:NULL];

      [self renderFilteredImage:YES];
    } else {
      parent = child;
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
    [self renderFilteredImage:YES];
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

    [self renderFilteredImage:NO];
  }
}

- (void)renderFilteredImage:(BOOL)shouldInvalidate
{
  CIFilter *filter = [_filter copy];
  __weak CMIFColorMatrixImageFilter *weakSelf = self;

  if (shouldInvalidate) {
    [self updateTargetImage: nil];
  }

  dispatch_async(dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0), ^{
    CMIFColorMatrixImageFilter *innerSelf = weakSelf;

    if (innerSelf && innerSelf.target && innerSelf.inputImage) {
      RCTResizeMode resizeMode = ((id <CMIFResizable>)innerSelf.target).resizeMode;
      UIImage *image = [CMIFColorMatrixImageFilter filteredImage:innerSelf.inputImage
                                                          filter:filter
                                                      resizeMode:resizeMode];

      dispatch_async(dispatch_get_main_queue(), ^{
        [innerSelf updateTargetImage:image];
      });
    }
  });
}

- (void)updateTargetImage:(UIImage *)image {
    [self.target removeObserver:self forKeyPath:@"image"];
    [self.target setImage:image];
    [self.target addObserver:self
                  forKeyPath:@"image"
                     options:NSKeyValueObservingOptionNew
                     context:NULL];
}

+ (UIImage *)filteredImage:(UIImage *)image
                    filter:(CIFilter *)filter
                resizeMode:(RCTResizeMode)resizeMode
{
  if (image != nil) {
    CIImage *tmp = [[CIImage alloc] initWithImage:image];
    [filter setValue:tmp forKey:@"inputImage"];

    CGRect outputRect = tmp.extent;

    CGImageRef cgim = [context createCGImage:filter.outputImage fromRect:outputRect];

    UIImage *filteredImage = [UIImage imageWithCGImage:cgim scale:image.scale orientation:image.imageOrientation];

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

@end
