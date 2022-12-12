import { cleanup, renderHook, act } from '@testing-library/react'
import { useBacklash } from 'react-use-backlash'
import { TestUtil } from '../../../util'
import { ImageSelection } from '.'

const { init, updates } = ImageSelection

const { getActions, getState, delay } = TestUtil

const noopInjects = {
  takePhotoFromCamera: () => Promise.resolve('canceled' as const),
  pickPhotoFromLibrary: () => Promise.resolve('canceled' as const)
}

const initialState = {
  selectedResizeMode: 'center',
  isFullScreen: false,
  image: { static: 0 }
} as const

describe('ImageSelection', () => {
  afterEach(cleanup)

  test('init', () => {
    const hook = renderHook(() => useBacklash(() => init(0), updates, noopInjects))

    expect(getState(hook)).toEqual(initialState)
  })

  test('should select resize mode', async () => {
    const hook = renderHook(() => useBacklash(() => [initialState], updates, noopInjects))

    await act(() => {
      getActions(hook).selectResizeMode('contain')
    })

    expect(getState(hook).selectedResizeMode).toEqual('contain')
  })

  test('should keep same state when selecting same resize mode', async () => {
    const hook = renderHook(() => useBacklash(() => [initialState], updates, noopInjects))

    await act(() => {
      getActions(hook).selectResizeMode('center')
    })

    expect(getState(hook)).toBe(initialState)
  })

  test('should take photo from camera', async () => {
    const injects = {
      ...noopInjects,
      takePhotoFromCamera: () => Promise.resolve({ uri: 'It is a photo!' })
    }

    const hook = renderHook(() => useBacklash(() => [initialState], updates, injects))

    await act(() => {
      getActions(hook).takePhotoFromCamera()

      return delay(1)
    })

    expect(getState(hook)).toEqual({
      ...initialState,
      image: { uri: 'It is a photo!' }
    })
  })

  test('should pick photo from library', async () => {
    const injects = {
      ...noopInjects,
      pickPhotoFromLibrary: () => Promise.resolve({ uri: 'It is a photo!' })
    }

    const hook = renderHook(() => useBacklash(() => [initialState], updates, injects))

    await act(() => {
      getActions(hook).pickPhotoFromLibrary()

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
      getActions(hook).takePhotoFromCamera()

      return delay(1)
    })

    expect(getState(hook)).toBe(initialState)
  })

  test('should set isFullScreen true on enterFullScreen', async () => {
    const hook = renderHook(() => useBacklash(() => [initialState], updates, noopInjects))

    await act(() => {
      getActions(hook).enterFullScreen()
    })

    expect(getState(hook)).toEqual({
      ...initialState,
      isFullScreen: true
    })
  })

  test('should keep same state on enterFullScreen if isFullScreen is true', async () => {
    const state = { ...initialState, isFullScreen: true }
    const hook = renderHook(() => useBacklash(() => [state], updates, noopInjects))

    await act(() => {
      getActions(hook).enterFullScreen()
    })

    expect(getState(hook)).toBe(state)
  })

  test('should set isFullScreen false on leaveFullScreen', async () => {
    const state = { ...initialState, isFullScreen: true }
    const hook = renderHook(() => useBacklash(() => [state], updates, noopInjects))

    await act(() => {
      getActions(hook).leaveFullScreen()
    })

    expect(getState(hook)).toEqual({
      ...state,
      isFullScreen: false
    })
  })

  test('should keep same state on leaveFullScreen if isFullScreen is false', async () => {
    const state = { ...initialState, isFullScreen: false }
    const hook = renderHook(() => useBacklash(() => [state], updates, noopInjects))

    await act(() => {
      getActions(hook).leaveFullScreen()
    })

    expect(getState(hook)).toBe(state)
  })
})
