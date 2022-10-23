package iyegoroff.RNColorMatrixImageFilters;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.facebook.react.bridge.ReadableArray;
import com.facebook.react.bridge.ReactApplicationContext;
import com.facebook.react.module.annotations.ReactModule;
import com.facebook.react.views.view.ReactViewManager;
import com.facebook.react.uimanager.ThemedReactContext;
import com.facebook.react.uimanager.ViewManagerDelegate;
import com.facebook.react.uimanager.annotations.ReactProp;
import com.facebook.react.viewmanagers.CMIFColorMatrixImageFilterManagerDelegate;
import com.facebook.react.viewmanagers.CMIFColorMatrixImageFilterManagerInterface;

@ReactModule(name = ColorMatrixImageFilterManagerImpl.NAME)
public class ColorMatrixImageFilterManager extends ReactViewManager
        implements CMIFColorMatrixImageFilterManagerInterface<ColorMatrixImageFilter> {

    private final ViewManagerDelegate<ColorMatrixImageFilter> mDelegate;

    public ColorMatrixImageFilterManager(ReactApplicationContext context) {
        mDelegate = new CMIFColorMatrixImageFilterManagerDelegate(this);
    }

    @Nullable
    @Override
    protected ViewManagerDelegate getDelegate() {
        return mDelegate;
    }

    @NonNull
    @Override
    public String getName() {
        return ColorMatrixImageFilterManagerImpl.NAME;
    }

    @NonNull
    @Override
    public ColorMatrixImageFilter createViewInstance(@NonNull ThemedReactContext context) {
        return ColorMatrixImageFilterManagerImpl.createViewInstance(context);
    }

    @Override
    @ReactProp(name = ColorMatrixImageFilterManagerImpl.MATRIX_PROP)
    public void setMatrix(ColorMatrixImageFilter view, @Nullable ReadableArray matrix) {
        ColorMatrixImageFilterManagerImpl.setMatrix(view, matrix);
    }
}
