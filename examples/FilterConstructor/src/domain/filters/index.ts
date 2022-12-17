import { ColorMatrices } from '../../services'
import { filterControlConstraints, filters, matrix } from './filters'

export const Filters = {
  filters,
  filterControlConstraints,
  matrix: matrix(ColorMatrices.matrices, ColorMatrices.concatColorMatrices)
} as const

export * from './types'
