package iyegoroff.RNColorMatrixImageFilters;

import androidx.annotation.Nullable;
import com.facebook.react.module.annotations.ReactModule;
import com.facebook.react.bridge.ReadableArray;
import com.facebook.react.views.view.ReactViewManager;
import com.facebook.react.uimanager.ThemedReactContext;
import com.facebook.react.uimanager.annotations.ReactProp;
import com.facebook.react.bridge.ReactApplicationContext;

@ReactModule(name = ColorMatrixImageFilterManagerImpl.NAME)
public class ColorMatrixImageFilterManager extends ReactViewManager {

    ReactApplicationContext mCallerContext;

    public ColorMatrixImageFilterManager(ReactApplicationContext reactContext) {
        mCallerContext = reactContext;
    }

    @Override
    public String getName() {
        return ColorMatrixImageFilterManagerImpl.NAME;
    }

    @Override
    public ColorMatrixImageFilter createViewInstance(ThemedReactContext context) {
        return ColorMatrixImageFilterManagerImpl.createViewInstance(context);
    }

    @ReactProp(name = ColorMatrixImageFilterManagerImpl.MATRIX_PROP)
    public void setMatrix(ColorMatrixImageFilter view, ReadableArray matrix) {
        ColorMatrixImageFilterManagerImpl.setMatrix(view, matrix);
    }

}
