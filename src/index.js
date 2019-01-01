import matrixFilters from './color-matrix-filter'
import filters from 'rn-color-matrices'
import { concatColorMatrices } from 'concat-color-matrices'

module.exports = {
  ...matrixFilters,
  ...filters,
  concatColorMatrices
}
