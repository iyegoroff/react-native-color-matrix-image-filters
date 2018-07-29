package iyegoroff.RNColorMatrixImageFilters;

import com.facebook.react.views.view.ReactViewGroup;

import android.content.Context;
import android.graphics.ColorMatrix;
import android.graphics.ColorMatrixColorFilter;
import android.graphics.Canvas;
import android.util.Log;
import android.view.View;
import android.widget.ImageView;

import com.facebook.react.common.ReactConstants;
import com.facebook.react.bridge.ReadableArray;

public class RNColorMatrixImageFilter extends ReactViewGroup {

  private ColorMatrixColorFilter mFilter = new ColorMatrixColorFilter(new ColorMatrix());

  public RNColorMatrixImageFilter(Context context) {
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

      if (child instanceof ImageView) {
        ((ImageView) child).setColorFilter(mFilter);
        break;
      }
    }

    super.draw(canvas);
  }
}
