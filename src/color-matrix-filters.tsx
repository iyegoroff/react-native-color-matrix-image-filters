import React from 'react'
import { ColorMatrixImageFilter } from './color-matrix-filter'
import filters from 'rn-color-matrices'
import { View, ViewProps } from 'react-native'

export const ColorMatrix = ColorMatrixImageFilter

type ColorToneProps = ViewProps & {
  readonly desaturation?: number
  readonly toned?: number
  readonly lightColor?: string
  readonly darkColor?: string
}

export const ColorTone = React.forwardRef(
  (
    { desaturation, toned, lightColor, darkColor, ...props }: ColorToneProps,
    ref: React.Ref<View>
  ) => (
    <ColorMatrixImageFilter
      matrix={filters.colorTone(desaturation, toned, lightColor, darkColor)}
      ref={ref}
      {...props}
    />
  )
)

type RGBAProps = ViewProps & {
  readonly red?: number
  readonly green?: number
  readonly blue?: number
  readonly alpha?: number
}

export const RGBA = React.forwardRef(
  ({ red, green, blue, alpha, ...props }: RGBAProps, ref: React.Ref<View>) => (
    <ColorMatrixImageFilter matrix={filters.rgba(red, green, blue, alpha)} ref={ref} {...props} />
  )
)

type DuoToneProps = ViewProps & {
  readonly firstColor?: string
  readonly secondColor?: string
}

export const DuoTone = React.forwardRef(
  ({ firstColor, secondColor, ...props }: DuoToneProps, ref: React.Ref<View>) => (
    <ColorMatrixImageFilter
      matrix={filters.duoTone(firstColor, secondColor)}
      ref={ref}
      {...props}
    />
  )
)

export const Normal = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.normal()} ref={ref} {...props} />
))

export const Invert = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.invert()} ref={ref} {...props} />
))

export const Nightvision = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.nightvision()} ref={ref} {...props} />
))

export const Warm = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.warm()} ref={ref} {...props} />
))

export const Cool = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.cool()} ref={ref} {...props} />
))

export const Technicolor = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.technicolor()} ref={ref} {...props} />
))

export const Polaroid = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.polaroid()} ref={ref} {...props} />
))

export const ToBGR = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.toBGR()} ref={ref} {...props} />
))

export const Kodachrome = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.kodachrome()} ref={ref} {...props} />
))

export const Browni = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.browni()} ref={ref} {...props} />
))

export const Vintage = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.vintage()} ref={ref} {...props} />
))

export const LuminanceToAlpha = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.luminanceToAlpha()} ref={ref} {...props} />
))

export const Lsd = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.lsd()} ref={ref} {...props} />
))

export const Protanomaly = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.protanomaly()} ref={ref} {...props} />
))

export const Deuteranomaly = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.deuteranomaly()} ref={ref} {...props} />
))

export const Tritanomaly = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.tritanomaly()} ref={ref} {...props} />
))

export const Protanopia = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.protanopia()} ref={ref} {...props} />
))

export const Deuteranopia = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.deuteranopia()} ref={ref} {...props} />
))

export const Tritanopia = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.tritanopia()} ref={ref} {...props} />
))

export const Achromatopsia = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.achromatopsia()} ref={ref} {...props} />
))

export const Achromatomaly = React.forwardRef((props: ViewProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.achromatomaly()} ref={ref} {...props} />
))

type FilterProps = ViewProps & {
  readonly amount?: number
}

export const Saturate = React.forwardRef(
  ({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
    <ColorMatrixImageFilter matrix={filters.saturate(amount)} ref={ref} {...props} />
  )
)

export const HueRotate = React.forwardRef(
  ({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
    <ColorMatrixImageFilter matrix={filters.hueRotate(amount)} ref={ref} {...props} />
  )
)

export const Grayscale = React.forwardRef(
  ({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
    <ColorMatrixImageFilter matrix={filters.grayscale(amount)} ref={ref} {...props} />
  )
)

export const Sepia = React.forwardRef(({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.sepia(amount)} ref={ref} {...props} />
))

export const Brightness = React.forwardRef(
  ({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
    <ColorMatrixImageFilter matrix={filters.brightness(amount)} ref={ref} {...props} />
  )
)

export const Contrast = React.forwardRef(
  ({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
    <ColorMatrixImageFilter matrix={filters.contrast(amount)} ref={ref} {...props} />
  )
)

export const Temperature = React.forwardRef(
  ({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
    <ColorMatrixImageFilter matrix={filters.temperature(amount)} ref={ref} {...props} />
  )
)

export const Tint = React.forwardRef(({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.tint(amount)} ref={ref} {...props} />
))

export const Threshold = React.forwardRef(
  ({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
    <ColorMatrixImageFilter matrix={filters.threshold(amount)} ref={ref} {...props} />
  )
)

export const Night = React.forwardRef(({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
  <ColorMatrixImageFilter matrix={filters.night(amount)} ref={ref} {...props} />
))

export const Predator = React.forwardRef(
  ({ amount, ...props }: FilterProps, ref: React.Ref<View>) => (
    <ColorMatrixImageFilter matrix={filters.predator(amount)} ref={ref} {...props} />
  )
)
