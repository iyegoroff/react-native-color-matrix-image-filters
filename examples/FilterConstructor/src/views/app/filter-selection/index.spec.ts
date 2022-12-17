import { renderHook } from 'react-hook-testing'
import { act } from 'react-test-renderer'
import { useBacklash } from 'react-use-backlash'
import { TestUtil } from '../../../utils'
import { FilterSelection } from '.'

const { init, updates } = FilterSelection

const { getActions, getState } = TestUtil

const initialState = {
  isAddingFilter: false,
  filters: [],
  nextId: 0
} as const

describe('FilterSelection', () => {
  test('init', async () => {
    const hook = await renderHook(() => useBacklash(init, updates))

    expect(getState(hook)).toEqual(initialState)
  })

  test('should start adding filter', async () => {
    const hook = await renderHook(() => useBacklash(init, updates))

    await act(() => {
      getActions(hook).startAddFilter()
    })

    expect(getState(hook).isAddingFilter).toEqual(true)
  })

  test('should cancel adding filter', async () => {
    const hook = await renderHook(() => useBacklash(init, updates))

    await act(() => {
      getActions(hook).cancelAddFilter()
    })

    expect(getState(hook).isAddingFilter).toEqual(false)
  })

  test('should confirm adding filter', async () => {
    const hook = await renderHook(() => useBacklash(init, updates))

    await act(() => {
      getActions(hook).confirmAddFilter({ tag: 'Browni' })
    })

    expect(getState(hook)).toEqual({
      ...initialState,
      nextId: 1,
      filters: [{ tag: 'Browni', id: '0' }]
    })
  })

  test('should confirm adding filter', async () => {
    const hook = await renderHook(() => useBacklash(init, updates))

    await act(() => {
      getActions(hook).confirmAddFilter({ tag: 'Browni' })
    })

    expect(getState(hook)).toEqual({
      ...initialState,
      nextId: 1,
      filters: [{ tag: 'Browni', id: '0' }]
    })
  })

  test('should remove existing filter', async () => {
    const hook = await renderHook(() =>
      useBacklash(
        () => [{ ...initialState, nextId: 1, filters: [{ tag: 'Browni', id: '0' } as const] }],
        updates
      )
    )

    await act(() => {
      getActions(hook).removeFilter('0')
    })

    expect(getState(hook)).toEqual({ ...initialState, nextId: 1, filters: [] })
  })

  test('should keep same state if filter not exist', async () => {
    const state = { ...initialState, nextId: 1, filters: [{ tag: 'Browni', id: '0' } as const] }
    const hook = await renderHook(() => useBacklash(() => [state], updates))

    await act(() => {
      getActions(hook).removeFilter('1')
    })

    expect(getState(hook)).toBe(state)
  })

  test('should move filter up', async () => {
    const state = {
      ...initialState,
      filters: [
        { tag: 'Browni', id: '0' },
        { tag: 'Nightvision', id: '1' }
      ] as const
    }

    const hook = await renderHook(() => useBacklash(() => [state], updates))

    await act(() => {
      getActions(hook).moveFilterUp('1')
    })

    expect(getState(hook)).toEqual({
      ...initialState,
      filters: [
        { tag: 'Nightvision', id: '1' },
        { tag: 'Browni', id: '0' }
      ]
    })
  })

  test('should keep same state when moving nonexistent filter up', async () => {
    const state = {
      ...initialState,
      filters: [
        { tag: 'Browni', id: '0' },
        { tag: 'Nightvision', id: '1' }
      ] as const
    }

    const hook = await renderHook(() => useBacklash(() => [state], updates))

    await act(() => {
      getActions(hook).moveFilterUp('2')
    })

    expect(getState(hook)).toBe(state)
  })

  test('should move filter down', async () => {
    const state = {
      ...initialState,
      filters: [
        { tag: 'Browni', id: '0' },
        { tag: 'Nightvision', id: '1' }
      ] as const
    }

    const hook = await renderHook(() => useBacklash(() => [state], updates))

    await act(() => {
      getActions(hook).moveFilterDown('0')
    })

    expect(getState(hook)).toEqual({
      ...initialState,
      filters: [
        { tag: 'Nightvision', id: '1' },
        { tag: 'Browni', id: '0' }
      ]
    })
  })

  test('should keep same state when moving nonexistent filter down', async () => {
    const state = {
      ...initialState,
      filters: [
        { tag: 'Browni', id: '0' },
        { tag: 'Nightvision', id: '1' }
      ] as const
    }

    const hook = await renderHook(() => useBacklash(() => [state], updates))

    await act(() => {
      getActions(hook).moveFilterDown('2')
    })

    expect(getState(hook)).toBe(state)
  })

  test('should update filter', async () => {
    const state = {
      ...initialState,
      filters: [{ tag: 'Brightness', amount: 0.5, id: '0' }] as const
    }

    const hook = await renderHook(() => useBacklash(() => [state], updates))

    await act(() => {
      getActions(hook).updateFilter('0', { tag: 'Brightness', amount: 1 })
    })

    expect(getState(hook)).toEqual({
      ...initialState,
      filters: [{ tag: 'Brightness', amount: 1, id: '0' }]
    })
  })

  test('should keep same state if filters are equal', async () => {
    const state = {
      ...initialState,
      filters: [{ tag: 'Brightness', amount: 0.5, id: '0' }] as const
    }

    const hook = await renderHook(() => useBacklash(() => [state], updates))

    await act(() => {
      getActions(hook).updateFilter('0', { tag: 'Brightness', amount: 0.5 })
    })

    expect(getState(hook)).toBe(state)
  })

  test('should keep same state if filter is not found', async () => {
    const state = {
      ...initialState,
      filters: [{ tag: 'Brightness', amount: 0.5, id: '0' }] as const
    }

    const hook = await renderHook(() => useBacklash(() => [state], updates))

    await act(() => {
      getActions(hook).updateFilter('1', { tag: 'Browni' })
    })

    expect(getState(hook)).toBe(state)
  })
})
