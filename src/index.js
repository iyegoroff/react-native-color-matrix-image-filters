import matrixFilters from './color-matrix-filter';
import filters from './matrix-filters';
import { concatColorMatrices } from 'concat-color-matrices';

module.exports = {
  ...matrixFilters,
  ...filters,
  concatColorMatrices
};
