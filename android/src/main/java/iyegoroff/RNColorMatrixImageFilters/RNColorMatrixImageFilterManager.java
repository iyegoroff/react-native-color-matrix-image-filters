package iyegoroff.RNColorMatrixImageFilters;

import com.facebook.react.bridge.ReadableArray;
import com.facebook.react.module.annotations.ReactModule;
import com.facebook.react.uimanager.annotations.ReactProp;
import com.facebook.react.views.view.ReactViewManager;
import com.facebook.react.uimanager.ThemedReactContext;

@ReactModule(name = RNColorMatrixImageFilterManager.REACT_CLASS)
public class RNColorMatrixImageFilterManager extends ReactViewManager {

  protected static final String REACT_CLASS = "RNColorMatrixImageFilter";
  protected static final String PROP_MATRIX = "matrix";

  @Override
  public String getName() {
    return REACT_CLASS;
  }

  @Override
  public RNColorMatrixImageFilter createViewInstance(ThemedReactContext reactContext) {
    return new RNColorMatrixImageFilter(reactContext);
  }

  @ReactProp(name = PROP_MATRIX)
  public void setMatrix(RNColorMatrixImageFilter view, ReadableArray matrix) {
    view.setMatrix(matrix);
  }
}
