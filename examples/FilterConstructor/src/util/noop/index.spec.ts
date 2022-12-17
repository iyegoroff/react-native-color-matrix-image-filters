import { noop } from '.'

describe('noop', () => {
  test('should do nothing', () => {
    expect(noop()).toEqual(undefined)
  })
})
