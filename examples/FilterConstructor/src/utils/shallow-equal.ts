import shallowequal from 'shallowequal'

export const shallowEqual = <A, B>(a: A extends B ? A : never, b: B extends A ? B : never) =>
  shallowequal(a, b)
