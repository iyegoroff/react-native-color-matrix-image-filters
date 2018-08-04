import filters from './matrix-filters';
import invariant from 'fbjs/lib/invariant';

// based on android sdk sources: https://goo.gl/MMDopQ

export const concatTwoColorMatrices = (matB, matA) => {
  invariant(matB.length === 20, `Color matrix matB should have 20 elements.`);
  invariant(matA.length === 20, `Color matrix matA should have 20 elements.`);

  const tmp = Array(20);

  let index = 0;
  for (let j = 0; j < 20; j += 5) {
    for (let i = 0; i < 4; i++) {
      tmp[index++] = matA[j + 0] * matB[i + 0] + matA[j + 1] * matB[i + 5] +
        matA[j + 2] * matB[i + 10] + matA[j + 3] * matB[i + 15];
    }
    tmp[index++] = matA[j + 0] * matB[4] + matA[j + 1] * matB[9] +
      matA[j + 2] * matB[14] + matA[j + 3] * matB[19] + matA[j + 4];
  }

  return tmp;
};

export const concatColorMatrices = (matrices) => (
  (matrices || []).length === 0 ? filters.normal() : matrices.reduce(concatTwoColorMatrices)
);
