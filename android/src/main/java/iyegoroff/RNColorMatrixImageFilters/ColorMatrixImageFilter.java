package iyegoroff.RNColorMatrixImageFilters;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.ColorMatrix;
import android.graphics.ColorMatrixColorFilter;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import androidx.annotation.NonNull;
import com.facebook.react.bridge.ReadableArray;
import com.facebook.react.views.view.ReactViewGroup;

public class ColorMatrixImageFilter extends ReactViewGroup {

  private ColorMatrixColorFilter mFilter =
      new ColorMatrixColorFilter(new ColorMatrix());

  private final OnLayoutChangeListener mChildLayoutListener = (view, i, i1, i2, i3, i4, i5, i6, i7) -> {
    if (view instanceof ImageView) ((ImageView)view).setColorFilter(mFilter);
  };

  public ColorMatrixImageFilter(Context context) { super(context); }

  public void setMatrix(ReadableArray matrix) {
    float[] m = new float[matrix.size()];

    for (int i = 0; i < m.length; i++) {
      m[i] = (float)matrix.getDouble(i);
    }

    mFilter = new ColorMatrixColorFilter(m);

    invalidate();
  }

  @Override
  public void draw(@NonNull Canvas canvas) {
    this.walkChildren(this);

    super.draw(canvas);
  }

  private void walkChildren(ViewGroup view) {
    for (int i = 0; i < view.getChildCount(); i++) {
      View child = view.getChildAt(i);

      if (child instanceof ImageView) {
        ((ImageView)child).setColorFilter(mFilter);
        child.removeOnLayoutChangeListener(mChildLayoutListener);
        child.addOnLayoutChangeListener(mChildLayoutListener);
      } else if (child instanceof ViewGroup) {
        this.walkChildren((ViewGroup)child);
      }
    }
  }
}
