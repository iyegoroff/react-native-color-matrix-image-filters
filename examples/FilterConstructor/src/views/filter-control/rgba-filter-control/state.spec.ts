import { cleanup, renderHook, act } from '@testing-library/react'
import { useBacklash } from 'react-use-backlash'
import { RGBAFilter } from '../../../domain/filters/types'
import { Util } from '../../../util'
import { init, updates } from './state'

const { getState, getActions } = Util.TestUtil

describe('RGBAFilterControl', () => {
  afterEach(cleanup)

  test('state', async () => {
    const filter = {
      tag: 'RGBA' as const,
      r: 1,
      g: 1,
      b: 1,
      a: 1
    }

    const update = ({ r, g, b, a }: RGBAFilter) => {
      filter.a = a
      filter.r = r
      filter.g = g
      filter.b = b
    }

    const hook = renderHook(() => useBacklash(init, updates, { ...filter, update }))

    const actions = getActions(hook)

    expect(getState(hook)).toEqual(undefined)

    await act(() => {
      actions.changeA(10)
    })

    expect(filter.a).toEqual(10)

    await act(() => {
      actions.changeB(15)
    })

    expect(filter.b).toEqual(15)

    await act(() => {
      actions.changeG(20)
    })

    expect(filter.g).toEqual(20)

    await act(() => {
      actions.changeR(25)
    })

    expect(filter.r).toEqual(25)
  })
})
