import { swap } from '.'

describe('swap items', () => {
  test('should swap items inside array', () => {
    const arr = [10, 20, 30, 40, 50]
    const exp = [10, 20, 40, 30, 50]

    expect(swap(arr, 2, 3)).toEqual(exp)
  })

  test('should return the same array if at least one index is out of bounds', () => {
    const arr = [10, 20, 30, 40, 50]

    expect(swap(arr, 20, 3)).toBe(arr)
  })
})
