import { cleanup, renderHook, act } from '@testing-library/react'
import { useBacklash } from 'react-use-backlash'
import { TestUtil } from '../../util'
import { init, updates } from './state'

const { getActions, getState, delay } = TestUtil

const noopInjects = {
  takePhotoFromCamera: () => Promise.resolve('canceled' as const),
  pickPhotoFromLibrary: () => Promise.resolve('canceled' as const)
}

const initialState = {
  selectedResizeMode: 'center',
  isAddingFilter: false,
  filters: [],
  nextId: 0,
  image: { static: 0 }
} as const

describe('App', () => {
  afterEach(cleanup)

  test('init', () => {
    const hook = renderHook(() => useBacklash(() => init(0), updates, noopInjects))

    expect(getState(hook)).toEqual(initialState)
  })

  test('should select resize mode', async () => {
    const hook = renderHook(() => useBacklash(() => init(0), updates, noopInjects))

    await act(() => {
      getActions(hook).selectResizeMode('contain')
    })

    expect(getState(hook).selectedResizeMode).toEqual('contain')
  })

  test('should keep same state when selecting same resize mode', async () => {
    const hook = renderHook(() => useBacklash(() => init(0), updates, noopInjects))

    await act(() => {
      getActions(hook).selectResizeMode('center')
    })

    expect(getState(hook)).toEqual(initialState)
  })

  test('should start adding filter', async () => {
    const hook = renderHook(() => useBacklash(() => init(0), updates, noopInjects))

    await act(() => {
      getActions(hook).startAddFilter()
    })

    expect(getState(hook).isAddingFilter).toEqual(true)
  })

  test('should cancel adding filter', async () => {
    const hook = renderHook(() => useBacklash(() => init(0), updates, noopInjects))

    await act(() => {
      getActions(hook).cancelAddFilter()
    })

    expect(getState(hook).isAddingFilter).toEqual(false)
  })

  test('should confirm adding filter', async () => {
    const hook = renderHook(() => useBacklash(() => init(0), updates, noopInjects))

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
    const hook = renderHook(() => useBacklash(() => init(0), updates, noopInjects))

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
    const hook = renderHook(() =>
      useBacklash(
        () => [{ ...initialState, nextId: 1, filters: [{ tag: 'Browni', id: '0' } as const] }],
        updates,
        noopInjects
      )
    )

    await act(() => {
      getActions(hook).removeFilter('0')
    })

    expect(getState(hook)).toEqual({ ...initialState, nextId: 1, filters: [] })
  })

  test('should keep same state if filter not exist', async () => {
    const state = { ...initialState, nextId: 1, filters: [{ tag: 'Browni', id: '0' } as const] }
    const hook = renderHook(() => useBacklash(() => [state], updates, noopInjects))

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

    const hook = renderHook(() => useBacklash(() => [state], updates, noopInjects))

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

  test('should move filter down', async () => {
    const state = {
      ...initialState,
      filters: [
        { tag: 'Browni', id: '0' },
        { tag: 'Nightvision', id: '1' }
      ] as const
    }

    const hook = renderHook(() => useBacklash(() => [state], updates, noopInjects))

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

  test('should update filter', async () => {
    const state = {
      ...initialState,
      filters: [{ tag: 'Brightness', amount: 0.5, id: '0' }] as const
    }

    const hook = renderHook(() => useBacklash(() => [state], updates, noopInjects))

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

    const hook = renderHook(() => useBacklash(() => [state], updates, noopInjects))

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

    const hook = renderHook(() => useBacklash(() => [state], updates, noopInjects))

    await act(() => {
      getActions(hook).updateFilter('1', { tag: 'Browni' })
    })

    expect(getState(hook)).toBe(state)
  })

  test('should take photo', async () => {
    const injects = {
      ...noopInjects,
      takePhotoFromCamera: () => Promise.resolve({ uri: 'It is a photo!' })
    }

    const hook = renderHook(() => useBacklash(() => init(0), updates, injects))

    await act(() => {
      getActions(hook).takePhoto('camera')

      return delay(1)
    })

    expect(getState(hook)).toEqual({
      ...initialState,
      image: { uri: 'It is a photo!' }
    })
  })

  test('should keep same state when takePhoto was canceled', async () => {
    const injects = {
      ...noopInjects,
      takePhotoFromCamera: () => Promise.resolve('canceled' as const)
    }

    const hook = renderHook(() => useBacklash(() => [initialState], updates, injects))

    await act(() => {
      getActions(hook).takePhoto('camera')

      return delay(1)
    })

    expect(getState(hook)).toBe(initialState)
  })
})
