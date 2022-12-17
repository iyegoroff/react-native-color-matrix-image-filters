import { ColorMatrices } from '../../services'
import { Filter } from './types'

export const filterControlConstraints = {
  Achromatomaly: {},
  Achromatopsia: {},
  Brightness: {
    amount: { min: 0, max: 3 }
  },
  Browni: {},
  ColorTone: {
    desaturation: { min: -3, max: 3 },
    toned: { min: -3, max: 3 },
    darkColor: {
      variants: ['#000000', '#FFFFFF', '#FF0000', '#00FF00', '#0000FF']
    },
    lightColor: {
      variants: ['#000000', '#FFFFFF', '#FF0000', '#00FF00', '#0000FF']
    }
  },
  Contrast: {
    amount: { min: 0, max: 3 }
  },
  Cool: {},
  Deuteranomaly: {},
  Deuteranopia: {},
  DuoTone: {
    first: {
      variants: ['#000000', '#FFFFFF', '#FF0000', '#00FF00', '#0000FF']
    },
    second: {
      variants: ['#000000', '#FFFFFF', '#FF0000', '#00FF00', '#0000FF']
    }
  },
  Grayscale: {
    amount: { min: 0, max: 1 }
  },
  HueRotate: {
    amount: { min: -3, max: 3 }
  },
  Invert: {},
  Kodachrome: {},
  Lsd: {},
  LuminanceToAlpha: {},
  Night: {
    amount: { min: 0, max: 1 }
  },
  Nightvision: {},
  Normal: {},
  Polaroid: {},
  Predator: {
    amount: { min: 0, max: 1 }
  },
  Protanomaly: {},
  Protanopia: {},
  RGBA: {
    r: { min: 0, max: 1 },
    g: { min: 0, max: 1 },
    b: { min: 0, max: 1 },
    a: { min: 0, max: 1 }
  },
  Saturate: {
    amount: { min: -3, max: 3 }
  },
  Sepia: {
    amount: { min: 0, max: 1 }
  },
  Technicolor: {},
  Temperature: {
    amount: { min: -3, max: 3 }
  },
  Threshold: {
    amount: { min: 0, max: 20 }
  },
  Tint: {
    amount: { min: -1, max: 2 }
  },
  ToBGR: {},
  Tritanomaly: {},
  Tritanopia: {},
  Vintage: {},
  Warm: {}
} as const satisfies Record<Filter['tag'], unknown>

export const matrix =
  (matrices: ColorMatrices['matrices'], concat: ColorMatrices['concatColorMatrices']) =>
  (filters: readonly Filter[]) => {
    const iter = (filter: Filter) => {
      switch (filter.tag) {
        case 'Achromatomaly':
          return matrices.achromatomaly()

        case 'Achromatopsia':
          return matrices.achromatopsia()

        case 'Brightness':
          return matrices.brightness(filter.amount)

        case 'Browni':
          return matrices.browni()

        case 'ColorTone': {
          const { darkColor, desaturation, lightColor, toned } = filter
          return matrices.colorTone(desaturation, toned, lightColor, darkColor)
        }

        case 'Contrast':
          return matrices.contrast(filter.amount)

        case 'Cool':
          return matrices.cool()

        case 'Deuteranomaly':
          return matrices.deuteranomaly()

        case 'Deuteranopia':
          return matrices.deuteranopia()

        case 'DuoTone': {
          const { first, second } = filter
          return matrices.duoTone(first, second)
        }

        case 'Grayscale':
          return matrices.grayscale(filter.amount)

        case 'HueRotate':
          return matrices.hueRotate(filter.amount)

        case 'Invert':
          return matrices.invert()

        case 'Kodachrome':
          return matrices.kodachrome()

        case 'Lsd':
          return matrices.lsd()

        case 'LuminanceToAlpha':
          return matrices.luminanceToAlpha()

        case 'Night':
          return matrices.night(filter.amount)

        case 'Nightvision':
          return matrices.nightvision()

        case 'Normal':
          return matrices.normal()

        case 'Polaroid':
          return matrices.polaroid()

        case 'Predator':
          return matrices.predator(filter.amount)

        case 'Protanomaly':
          return matrices.protanomaly()

        case 'Protanopia':
          return matrices.protanopia()

        case 'RGBA': {
          const { r, g, b, a } = filter
          return matrices.rgba(r, g, b, a)
        }

        case 'Saturate':
          return matrices.saturate(filter.amount)

        case 'Sepia':
          return matrices.sepia(filter.amount)

        case 'Technicolor':
          return matrices.technicolor()

        case 'Temperature':
          return matrices.temperature(filter.amount)

        case 'Threshold':
          return matrices.threshold(filter.amount)

        case 'Tint':
          return matrices.tint(filter.amount)

        case 'ToBGR':
          return matrices.toBGR()

        case 'Tritanomaly':
          return matrices.tritanomaly()

        case 'Tritanopia':
          return matrices.tritanopia()

        case 'Vintage':
          return matrices.vintage()

        case 'Warm':
          return matrices.warm()
      }
    }

    return concat(...filters.map(iter))
  }

export const filters = [
  { tag: 'Achromatomaly' },
  { tag: 'Achromatopsia' },
  { tag: 'Brightness', amount: Number(1) },
  { tag: 'Browni' },
  {
    tag: 'ColorTone',
    desaturation: Number(1),
    toned: Number(1),
    lightColor: String('#FFFFFF'),
    darkColor: String('#000000')
  },
  { tag: 'Contrast', amount: Number(1) },
  { tag: 'Cool' },
  { tag: 'Deuteranomaly' },
  { tag: 'Deuteranopia' },
  { tag: 'DuoTone', first: String('#000000'), second: String('#FFFFFF') },
  { tag: 'Grayscale', amount: Number(1) },
  { tag: 'HueRotate', amount: Number(1) },
  { tag: 'Invert' },
  { tag: 'Kodachrome' },
  { tag: 'Lsd' },
  { tag: 'LuminanceToAlpha' },
  { tag: 'Night', amount: Number(1) },
  { tag: 'Nightvision' },
  { tag: 'Normal' },
  { tag: 'Polaroid' },
  { tag: 'Predator', amount: Number(1) },
  { tag: 'Protanomaly' },
  { tag: 'Protanopia' },
  { tag: 'RGBA', r: Number(1), g: Number(1), b: Number(1), a: Number(1) },
  { tag: 'Saturate', amount: Number(1) },
  { tag: 'Sepia', amount: Number(1) },
  { tag: 'Technicolor' },
  { tag: 'Temperature', amount: Number(1) },
  { tag: 'Threshold', amount: Number(10) },
  { tag: 'Tint', amount: Number(1) },
  { tag: 'ToBGR' },
  { tag: 'Tritanomaly' },
  { tag: 'Tritanopia' },
  { tag: 'Vintage' },
  { tag: 'Warm' }
] as const
