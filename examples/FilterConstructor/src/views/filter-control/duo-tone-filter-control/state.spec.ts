import { cleanup, renderHook, act } from '@testing-library/react'
import { useBacklash } from 'react-use-backlash'
import { DuoToneFilter } from '../../../domain/filters/types'
import { Util } from '../../../util'
import { init, updates } from './state'

const { getActions, getState } = Util.TestUtil

describe('DuoToneFilterControl', () => {
  afterEach(cleanup)

  test('state', async () => {
    const filter = {
      tag: 'DuoTone' as const,
      first: 'red',
      second: 'green'
    }

    const update = ({ first, second }: DuoToneFilter) => {
      filter.first = first
      filter.second = second
    }

    const hook = renderHook(() => useBacklash(init, updates, { ...filter, update }))

    const actions = getActions(hook)

    expect(getState(hook)).toEqual(undefined)

    await act(() => {
      actions.selectFirst('yellow')
    })

    expect(filter.first).toEqual('yellow')

    await act(() => {
      actions.selectSecond('blue')
    })

    expect(filter.second).toEqual('blue')
  })
})
