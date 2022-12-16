import matrices from 'rn-color-matrices'
import { concatColorMatrices } from 'react-native-color-matrix-image-filters'

export const ColorMatrices = {
  matrices,
  concatColorMatrices
} as const

export type ColorMatrices = typeof ColorMatrices
