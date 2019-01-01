package iyegoroff.RNColorMatrixImageFilters;

import com.facebook.react.views.view.ReactViewGroup;

import android.content.Context;
import android.graphics.ColorMatrix;
import android.graphics.ColorMatrixColorFilter;
import android.graphics.Canvas;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.facebook.react.bridge.ReadableArray;

public class ColorMatrixImageFilter extends ReactViewGroup {

  private ColorMatrixColorFilter mFilter = new ColorMatrixColorFilter(new ColorMatrix());

  public ColorMatrixImageFilter(Context context) {
    super(context);
  }

  public void setMatrix(ReadableArray matrix) {
    float[] m = new float[matrix.size()];

    for (int i = 0; i < m.length; i++) {
      m[i] = (float) matrix.getDouble(i);
    }

    mFilter = new ColorMatrixColorFilter(m);

    invalidate();
  }

  @Override
  public void draw(Canvas canvas) {
    for (int i = 0; i < this.getChildCount(); i++) {
      View child = this.getChildAt(i);

      while (!(child instanceof ImageView) && (child instanceof ViewGroup)) {
        child = ((ViewGroup) child).getChildAt(0);
      }

      if (child instanceof ImageView) {
        ((ImageView) child).setColorFilter(mFilter);
        break;
      }
    }

    super.draw(canvas);
  }
}
