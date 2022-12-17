import { renderHook } from 'react-hook-testing'
import { act } from 'react-test-renderer'
import { useBacklash } from 'react-use-backlash'
import { DuoToneFilter } from '../../../domain'
import { TestUtil } from '../../../utils'
import { init, updates } from './state'

const { getActions, getState } = TestUtil

describe('DuoToneFilterControl', () => {
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

    const hook = await renderHook(() => useBacklash(init, updates, { ...filter, update }))

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
