import { Services } from '../../services'
import { filterControlConstraints, filters, matrix } from './filters'

export const Filters = {
  filterControlConstraints,
  filters,
  matrix: matrix(Services.ColorMatrices)
} as const
