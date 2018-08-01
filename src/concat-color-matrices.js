import filters from './matrix-filters';

// based on android sdk sources: https://goo.gl/MMDopQ

export const concatTwoColorMatrices = (matB, matA) => {
  invariant(matB.length === 20, `Color matrix matB should have 20 elements.`);
  invariant(matA.length === 20, `Color matrix matA should have 20 elements.`);
  
  const a = [...matA];
  const b = [...matB];
  const tmp = Array(20);

  let index = 0;
  for (let j = 0; j < 20; j += 5) {
    for (let i = 0; i < 4; i++) {
      tmp[index++] = a[j + 0] * b[i + 0] + a[j + 1] * b[i + 5] +
        a[j + 2] * b[i + 10] + a[j + 3] * b[i + 15];
    }
    tmp[index++] = a[j + 0] * b[4] + a[j + 1] * b[9] +
      a[j + 2] * b[14] + a[j + 3] * b[19] + a[j + 4];
  }

  return tmp;
};

export const concatColorMatrices = (matrices) => (
  (matrices || []).length === 0 ? filters.normal() : matrices.reduce(concatTwoColorMatrices)
);
