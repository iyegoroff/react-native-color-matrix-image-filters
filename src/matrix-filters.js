import React from 'react';
import { Platform } from 'react-native';

// filters taken from here: https://github.com/skratchdot/color-matrix/blob/master/lib/filters.js

const isIos = Platform.OS === 'ios';

const staticFilters = {
  normal: [
    1, 0, 0, 0, 0,
    0, 1, 0, 0, 0,
    0, 0, 1, 0, 0,
    0, 0, 0, 1, 0
  ],

  luminanceToAlpha: [
    0, 0, 0, 0, 0,
    0, 0, 0, 0, 0,
    0, 0, 0, 0, 0,
    0.2125, 0.7154, 0.0721, 0, 0
  ],

  invert: [
    -1, 0, 0, 0, isIos ? 1 : 255,
    0, -1, 0, 0, isIos ? 1 : 255,
    0, 0, -1, 0, isIos ? 1 : 255,
    0, 0, 0, 1, 0
  ],

  grayscale: [
    0.299, 0.587, 0.114, 0, 0,
    0.299, 0.587, 0.114, 0, 0,
    0.299, 0.587, 0.114, 0, 0,
    0, 0, 0, 1, 0
  ],

  sepia: [
    0.393, 0.769, 0.189, 0, 0,
    0.349, 0.686, 0.168, 0, 0,
    0.272, 0.534, 0.131, 0, 0,
    0, 0, 0, 1, 0
  ],

  nightvision: [
    0.1, 0.4, 0, 0, 0,
    0.3, 1, 0.3, 0, 0,
    0, 0.4, 0.1, 0, 0,
    0, 0, 0, 1, 0
  ],

  warm: [
    1.06, 0, 0, 0, 0,
    0, 1.01, 0, 0, 0,
    0, 0, 0.93, 0, 0,
    0, 0, 0, 1, 0
  ],

  cool: [
    0.99, 0, 0, 0, 0,
    0, 0.93, 0, 0, 0,
    0, 0, 1.08, 0, 0,
    0, 0, 0, 1, 0
  ],

  protanomaly: [
    0.817, 0.183, 0, 0, 0,
    0.333, 0.667, 0, 0, 0,
    0, 0.125, 0.875, 0, 0,
    0, 0, 0, 1, 0
  ],

  deuteranomaly: [
    0.8, 0.2, 0, 0, 0,
    0.258, 0.742, 0, 0, 0,
    0, 0.142, 0.858, 0, 0,
    0, 0, 0, 1, 0
  ],

  tritanomaly: [
    0.967, 0.033, 0, 0, 0,
    0, 0.733, 0.267, 0, 0,
    0, 0.183, 0.817, 0, 0,
    0, 0, 0, 1, 0
  ],

  protanopia: [
    0.567, 0.433, 0, 0, 0,
    0.558, 0.442, 0, 0, 0,
    0, 0.242, 0.758, 0, 0,
    0, 0, 0, 1, 0
  ],

  deuteranopia: [
    0.625, 0.375, 0, 0, 0,
    0.7, 0.3, 0, 0, 0,
    0, 0.3, 0.7, 0, 0,
    0, 0, 0, 1, 0
  ],

  tritanopia: [
    0.95, 0.05, 0, 0, 0,
    0, 0.433, 0.567, 0, 0,
    0, 0.475, 0.525, 0, 0,
    0, 0, 0, 1, 0
  ],

  achromatopsia: [
    0.299, 0.587, 0.114, 0, 0,
    0.299, 0.587, 0.114, 0, 0,
    0.299, 0.587, 0.114, 0, 0,
    0, 0, 0, 1, 0
  ],

  achromatomaly: [
    0.618, 0.320, 0.062, 0, 0,
    0.163, 0.775, 0.062, 0, 0,
    0.163, 0.320, 0.516, 0, 0,
    0, 0, 0, 1, 0
  ]
};

export default {
  normal: () => staticFilters.normal,

  saturate: (v = 1) => [
    0.213 + 0.787 * v, 0.715 - 0.715 * v, 0.072 - 0.072 * v, 0, 0,
    0.213 - 0.213 * v, 0.715 + 0.285 * v, 0.072 - 0.072 * v, 0, 0,
    0.213 - 0.213 * v, 0.715 - 0.715 * v, 0.072 + 0.928 * v, 0, 0,
    0, 0, 0, 1, 0
  ],

  hueRotate: (v = 0) => {
    const a00 = (0.213) + (Math.cos(v) * 0.787) - (Math.sin(v) * 0.213);
    const a01 = (0.715) - (Math.cos(v) * 0.715) - (Math.sin(v) * 0.715);
    const a02 = (0.072) - (Math.cos(v) * 0.072) + (Math.sin(v) * 0.928);
    const a10 = (0.213) - (Math.cos(v) * 0.213) + (Math.sin(v) * 0.143);
    const a11 = (0.715) + (Math.cos(v) * 0.285) + (Math.sin(v) * 0.140);
    const a12 = (0.072) - (Math.cos(v) * 0.072) - (Math.sin(v) * 0.283);
    const a20 = (0.213) - (Math.cos(v) * 0.213) - (Math.sin(v) * 0.787);
    const a21 = (0.715) - (Math.cos(v) * 0.715) + (Math.sin(v) * 0.715);
    const a22 = (0.072) + (Math.cos(v) * 0.928) + (Math.sin(v) * 0.072);

    return [
      a00, a01, a02, 0, 0,
      a10, a11, a12, 0, 0,
      a20, a21, a22, 0, 0,
      0, 0, 0, 1, 0,
    ];
  },

  luminanceToAlpha: () => staticFilters.luminanceToAlpha,

  invert: () => staticFilters.invert,

  grayscale: () => staticFilters.grayscale,

  sepia: () => staticFilters.sepia,

  nightvision: () => staticFilters.nightvision,

  warm: () => staticFilters.warm,

  cool: () => staticFilters.cool,

  brightness: (v = 0) => {
    const n = (isIos ? 1 : 255) * (v / 100);

    return [
      1, 0, 0, 0, n,
      0, 1, 0, 0, n,
      0, 0, 1, 0, n,
      0, 0, 0, 1, 0
    ];
  },

  exposure: (v = 1) => {
    const n = Math.max(v, 0);

    return [
      n, 0, 0, 0, 0,
      0, n, 0, 0, 0,
      0, 0, n, 0, 0,
      0, 0, 0, 1, 0
    ];
  },

  contrast: (v = 1) => {
    const n = 0.5 * (1 - v);

    return [
      v, 0, 0, 0, (isIos ? 1 : 255) * n,
      0, v, 0, 0, (isIos ? 1 : 255) * n,
      0, 0, v, 0, (isIos ? 1 : 255) * n,
      0, 0, 0, 1, 0
    ];
  },

  temperature: (v = 0) => [
    1 + v, 0, 0, 0, 0,
    0, 1, 0, 0, 0,
    0, 0, 1 - v, 0, 0,
    0, 0, 0, 1, 0
  ],

  tint: (v = 0) => [
    1 + v, 0, 0, 0, 0,
    0, 1, 0, 0, 0,
    0, 0, 1 + v, 0, 0,
    0, 0, 0, 1, 0
  ],

  threshold: (v = 0) => {
    const r_lum = 0.3086;
    const g_lum = 0.6094;
    const b_lum = 0.0820;
    const r = r_lum * 256;
    const g = g_lum * 256;
    const b = b_lum * 256;

    return [
      r, g, b, 0, -(isIos ? 1 : 255) * v,
      r, g, b, 0, -(isIos ? 1 : 255) * v,
      r, g, b, 0, -(isIos ? 1 : 255) * v,
      0, 0, 0, 1, 0
    ];
  },

  protanomaly: () => staticFilters.protanomaly,

  deuteranomaly: () => staticFilters.deuteranomaly,

  tritanomaly: () => staticFilters.tritanomaly,

  protanopia: () => staticFilters.protanopia,

  deuteranopia: () => staticFilters.deuteranopia,

  tritanopia: () => staticFilters.tritanopia,

  achromatopsia: () => staticFilters.achromatopsia,

  achromatomaly: () => staticFilters.achromatomaly
};
