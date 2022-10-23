import filters from 'rn-color-matrices'
export * from './color-matrix-filters'
import { concatColorMatrices as legacyConcat } from 'concat-color-matrices'

export const concatColorMatrices = (...matrices: Parameters<typeof legacyConcat>[0]) =>
  legacyConcat(matrices)

export const achromatomaly = filters.achromatomaly
export const achromatopsia = filters.achromatopsia
export const brightness = filters.brightness
export const browni = filters.browni
export const colorTone = filters.colorTone
export const contrast = filters.contrast
export const cool = filters.cool
export const deuteranomaly = filters.deuteranomaly
export const deuteranopia = filters.deuteranopia
export const duoTone = filters.duoTone
export const grayscale = filters.grayscale
export const hueRotate = filters.hueRotate
export const invert = filters.invert
export const kodachrome = filters.kodachrome
export const lsd = filters.lsd
export const luminanceToAlpha = filters.luminanceToAlpha
export const night = filters.night
export const nightvision = filters.nightvision
export const normal = filters.normal
export const polaroid = filters.polaroid
export const predator = filters.predator
export const protanomaly = filters.protanomaly
export const protanopia = filters.protanopia
export const rgba = filters.rgba
export const saturate = filters.saturate
export const sepia = filters.sepia
export const technicolor = filters.technicolor
export const temperature = filters.temperature
export const threshold = filters.threshold
export const tint = filters.tint
export const toBGR = filters.toBGR
export const tritanomaly = filters.tritanomaly
export const tritanopia = filters.tritanopia
export const vintage = filters.vintage
export const warm = filters.warm
