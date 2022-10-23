package iyegoroff.RNColorMatrixImageFilters;

import com.facebook.react.bridge.ReadableArray;
import com.facebook.react.uimanager.ThemedReactContext;

public class ColorMatrixImageFilterManagerImpl {

  public static final String NAME = "CMIFColorMatrixImageFilter";
  public static final String MATRIX_PROP = "matrix";

  public static ColorMatrixImageFilter createViewInstance(ThemedReactContext reactContext) {
    return new ColorMatrixImageFilter(reactContext);
  }

  public static void setMatrix(ColorMatrixImageFilter view, ReadableArray matrix) {
    view.setMatrix(matrix);
  }
}
