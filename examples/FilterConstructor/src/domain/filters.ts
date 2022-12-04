import matrices from 'rn-color-matrices'

const {
  achromatomaly,
  achromatopsia,
  brightness,
  browni,
  colorTone,
  contrast,
  cool,
  deuteranomaly,
  deuteranopia,
  duoTone,
  grayscale,
  hueRotate,
  invert,
  kodachrome,
  lsd,
  luminanceToAlpha,
  night,
  nightvision,
  normal,
  polaroid,
  predator,
  protanomaly,
  protanopia,
  rgba,
  saturate,
  sepia,
  technicolor,
  temperature,
  threshold,
  tint,
  toBGR,
  tritanomaly,
  tritanopia,
  vintage,
  warm
} = matrices

const filters = [
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

export type Filter = typeof filters[number]

export type AmountFilter = Extract<Filter, { amount: number }>
export type ColorToneFilter = Extract<Filter, { tag: 'ColorTone' }>
export type RGBAFilter = Extract<Filter, { tag: 'RGBA' }>
export type DuoToneFilter = Extract<Filter, { tag: 'DuoTone' }>
export type NoControlsFilter = Exclude<
  Filter,
  AmountFilter | ColorToneFilter | RGBAFilter | DuoToneFilter
>

const filterControlConstraints = {
  Achromatomaly: {},
  Achromatopsia: {},
  Brightness: {
    amount: { min: 0, max: 1 }
  },
  Browni: {},
  ColorTone: {
    desaturation: { min: 0, max: 1 },
    toned: { min: 0, max: 1 },
    darkColor: {
      variants: ['#000000', '#FFFFFF', '#FF0000', '#00FF00', '#0000FF']
    },
    lightColor: {
      variants: ['#000000', '#FFFFFF', '#FF0000', '#00FF00', '#0000FF']
    }
  },
  Contrast: {
    amount: { min: 0, max: 1 }
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
    amount: { min: 0, max: 1 }
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
    amount: { min: 0, max: 1 }
  },
  Sepia: {
    amount: { min: 0, max: 1 }
  },
  Technicolor: {},
  Temperature: {
    amount: { min: 0, max: 1 }
  },
  Threshold: {
    amount: { min: 0, max: 10 }
  },
  Tint: {
    amount: { min: 0, max: 1 }
  },
  ToBGR: {},
  Tritanomaly: {},
  Tritanopia: {},
  Vintage: {},
  Warm: {}
} as const satisfies Record<Filter['tag'], unknown>

const matrix = (filter: Filter) => {
  switch (filter.tag) {
    case 'Achromatomaly':
      return achromatomaly()

    case 'Achromatopsia':
      return achromatopsia()

    case 'Brightness':
      return brightness(filter.amount)

    case 'Browni':
      return browni()

    case 'ColorTone': {
      const { darkColor, desaturation, lightColor, toned } = filter
      return colorTone(desaturation, toned, lightColor, darkColor)
    }

    case 'Contrast':
      return contrast(filter.amount)

    case 'Cool':
      return cool()

    case 'Deuteranomaly':
      return deuteranomaly()

    case 'Deuteranopia':
      return deuteranopia()

    case 'DuoTone': {
      const { first, second } = filter
      return duoTone(first, second)
    }

    case 'Grayscale':
      return grayscale(filter.amount)

    case 'HueRotate':
      return hueRotate(filter.amount)

    case 'Invert':
      return invert()

    case 'Kodachrome':
      return kodachrome()

    case 'Lsd':
      return lsd()

    case 'LuminanceToAlpha':
      return luminanceToAlpha()

    case 'Night':
      return night(filter.amount)

    case 'Nightvision':
      return nightvision()

    case 'Normal':
      return normal()

    case 'Polaroid':
      return polaroid()

    case 'Predator':
      return predator(filter.amount)

    case 'Protanomaly':
      return protanomaly()

    case 'Protanopia':
      return protanopia()

    case 'RGBA': {
      const { r, g, b, a } = filter
      return rgba(r, g, b, a)
    }

    case 'Saturate':
      return saturate(filter.amount)

    case 'Sepia':
      return sepia(filter.amount)

    case 'Technicolor':
      return technicolor()

    case 'Temperature':
      return temperature(filter.amount)

    case 'Threshold':
      return threshold(filter.amount)

    case 'Tint':
      return tint(filter.amount)

    case 'ToBGR':
      return toBGR()

    case 'Tritanomaly':
      return tritanomaly()

    case 'Tritanopia':
      return tritanopia()

    case 'Vintage':
      return vintage()

    case 'Warm':
      return warm()
  }
}

export const Filters = {
  filterControlConstraints,
  filters,
  matrix
} as const
