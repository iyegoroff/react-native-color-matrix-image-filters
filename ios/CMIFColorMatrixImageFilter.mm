#import "CMIFColorMatrixImageFilter.h"
#import "CMIFImageView.h"

#ifdef RCT_NEW_ARCH_ENABLED

#import <react/renderer/components/CMIFColorMatrixImageFiltersSpec/ComponentDescriptors.h>
#import <react/renderer/components/CMIFColorMatrixImageFiltersSpec/EventEmitters.h>
#import <react/renderer/components/CMIFColorMatrixImageFiltersSpec/Props.h>
#import <react/renderer/components/CMIFColorMatrixImageFiltersSpec/RCTComponentViewHelpers.h>

#import "RCTFabricComponentsPlugins.h"

using namespace facebook::react;
#endif

static CIContext* context;

#ifdef RCT_NEW_ARCH_ENABLED
@interface CMIFColorMatrixImageFilter () <RCTCMIFColorMatrixImageFilterViewProtocol>
#else
@interface CMIFColorMatrixImageFilter ()
#endif

@property (nonatomic, strong) CIFilter* filter;
@property (nonatomic, strong) UIImage *inputImage;
@property (nonatomic, weak) NSObject<CMIFImageView> *target;

@end


@implementation CMIFColorMatrixImageFilter

- (instancetype)initWithFrame:(CGRect)frame
{
  if ((self = [super initWithFrame:frame])) {
#ifdef RCT_NEW_ARCH_ENABLED
    static const auto defaultProps = std::make_shared<const CMIFColorMatrixImageFilterProps>();
    _props = defaultProps;
#endif
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
    if ([child respondsToSelector:@selector(image)] &&
        [child respondsToSelector:@selector(setImage:)]) {
      _target = (NSObject<CMIFImageView> *)child;
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

#ifdef RCT_NEW_ARCH_ENABLED
- (void)updateProps:(Props::Shared const &)props oldProps:(Props::Shared const &)oldProps
{
  const auto &oldViewProps = *std::static_pointer_cast<CMIFColorMatrixImageFilterProps const>(_props);
  const auto &newViewProps = *std::static_pointer_cast<CMIFColorMatrixImageFilterProps const>(props);

  if (oldViewProps.matrix != newViewProps.matrix) {
      NSMutableArray* matrix = [NSMutableArray new];
      std::for_each(newViewProps.matrix.begin(), newViewProps.matrix.end(), ^(Float num) {
          [matrix addObject:[NSNumber numberWithFloat:num]];
      });
      [self updateFilter:matrix];
  }

  [super updateProps:props oldProps:oldProps];
}
#else
- (void)didSetProps:(NSArray<NSString *> *)changedProps
{
  if ([changedProps containsObject:@"matrix"]) {
      [self updateFilter:_matrix];
  }
}
#endif

- (void)updateFilter:(NSArray<NSNumber *> *)matrix
{
  CGFloat m[20] = {
    [matrix[0] floatValue], [matrix[1] floatValue], [matrix[2] floatValue], [matrix[3] floatValue],
    [matrix[5] floatValue], [matrix[6] floatValue], [matrix[7] floatValue], [matrix[8] floatValue],
    [matrix[10] floatValue], [matrix[11] floatValue], [matrix[12] floatValue], [matrix[13] floatValue],
    [matrix[15] floatValue], [matrix[16] floatValue], [matrix[17] floatValue], [matrix[18] floatValue],
    [matrix[4] floatValue], [matrix[9] floatValue], [matrix[14] floatValue], [matrix[19] floatValue]
  };

  [_filter setValue:[CIVector vectorWithValues:&m[0] count:4] forKey:@"inputRVector"];
  [_filter setValue:[CIVector vectorWithValues:&m[4] count:4] forKey:@"inputGVector"];
  [_filter setValue:[CIVector vectorWithValues:&m[8] count:4] forKey:@"inputBVector"];
  [_filter setValue:[CIVector vectorWithValues:&m[12] count:4] forKey:@"inputAVector"];
  [_filter setValue:[CIVector vectorWithValues:&m[16] count:4] forKey:@"inputBiasVector"];

  [self renderFilteredImage:NO];
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
      UIImage *image = [CMIFColorMatrixImageFilter filteredImage:innerSelf.inputImage
                                                          filter:filter];

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

+ (UIImage *)filteredImage:(UIImage *)image filter:(CIFilter *)filter
{
  if (image != nil) {
    CIImage *tmp = [[CIImage alloc] initWithImage:image];
    [filter setValue:tmp forKey:@"inputImage"];

    CGRect outputRect = tmp.extent;

    CGImageRef cgim = [context createCGImage:filter.outputImage fromRect:outputRect];

    UIImage *filteredImage = [UIImage imageWithCGImage:cgim scale:image.scale orientation:image.imageOrientation];

    CGImageRelease(cgim);

#ifdef RCT_NEW_ARCH_ENABLED
    return [NSStringFromClass([image class]) isEqual:@"_UIResizableImage"]
      ? [filteredImage resizableImageWithCapInsets:image.capInsets resizingMode:UIImageResizingModeTile]
      : filteredImage;
#else
    return filteredImage;
#endif
  }

  return nil;
}

+ (CIContext *)createContextWithOptions:(nullable NSDictionary<NSString *, id> *)options
{
  EAGLContext *eaglContext = [[EAGLContext alloc] initWithAPI:kEAGLRenderingAPIOpenGLES3];
  eaglContext = eaglContext ?: [[EAGLContext alloc] initWithAPI:kEAGLRenderingAPIOpenGLES2];

  return [CIContext contextWithEAGLContext:eaglContext options:options];
}

#ifdef RCT_NEW_ARCH_ENABLED
+ (ComponentDescriptorProvider)componentDescriptorProvider
{
  return concreteComponentDescriptorProvider<CMIFColorMatrixImageFilterComponentDescriptor>();
}

Class<RCTComponentViewProtocol> CMIFColorMatrixImageFilterCls(void)
{
  return CMIFColorMatrixImageFilter.class;
}
#endif

@end
