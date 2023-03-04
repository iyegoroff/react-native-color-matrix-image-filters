import { renderHook } from 'react-hook-testing'
import { act } from 'react-test-renderer'
import { useBacklash } from 'react-use-backlash'
import { noop, TestUtil } from '../../../utils'
import { ImageSelection } from '.'

const { init, updates } = ImageSelection

const { getActions, getState, delay } = TestUtil

const noopInjects = {
  takePhotoFromCamera: () => Promise.resolve('canceled' as const),
  pickPhotoFromLibrary: () => Promise.resolve('canceled' as const),
  showAlert: noop
}

const initialState = {
  selectedResizeMode: 'center',
  isFullScreen: false,
  showFullScreenNotice: true,
  image: { static: 0 }
} as const

describe('ImageSelection', () => {
  test('init', async () => {
    const hook = await renderHook(() =>
      useBacklash(() => init({ static: 0 }), updates, noopInjects)
    )

    expect(getState(hook)).toEqual(initialState)
  })

  test('should select resize mode', async () => {
    const hook = await renderHook(() => useBacklash(() => [initialState], updates, noopInjects))

    await act(() => {
      getActions(hook).selectResizeMode('contain')
    })

    expect(getState(hook).selectedResizeMode).toEqual('contain')
  })

  test('should keep same state when selecting same resize mode', async () => {
    const hook = await renderHook(() => useBacklash(() => [initialState], updates, noopInjects))

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

    const hook = await renderHook(() => useBacklash(() => [initialState], updates, injects))

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

    const hook = await renderHook(() => useBacklash(() => [initialState], updates, injects))

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

    const hook = await renderHook(() => useBacklash(() => [initialState], updates, injects))

    await act(() => {
      getActions(hook).takePhotoFromCamera()

      return delay(1)
    })

    expect(getState(hook)).toBe(initialState)
  })

  test('should handle error when takePhoto fails', async () => {
    const injects = {
      ...noopInjects,
      showAlert: jest.fn((_: string, message: string) => {
        expect(message).toEqual('rejected')
      }),
      takePhotoFromCamera: () => Promise.reject('rejected')
    }

    const hook = await renderHook(() => useBacklash(() => [initialState], updates, injects))

    await act(() => {
      getActions(hook).takePhotoFromCamera()

      return delay(1)
    })

    expect(injects.showAlert).toReturn()
    expect(getState(hook)).toBe(initialState)
  })

  test('should set `isFullScreen: true` and `showFullScreenNotice: false` on enterFullScreen', async () => {
    const hook = await renderHook(() => useBacklash(() => [initialState], updates, noopInjects))

    await act(() => {
      getActions(hook).enterFullScreen()
    })

    expect(getState(hook)).toEqual({
      ...initialState,
      isFullScreen: true,
      showFullScreenNotice: false
    })
  })

  test('should keep same state on enterFullScreen if isFullScreen is true', async () => {
    const state = { ...initialState, isFullScreen: true }
    const hook = await renderHook(() => useBacklash(() => [state], updates, noopInjects))

    await act(() => {
      getActions(hook).enterFullScreen()
    })

    expect(getState(hook)).toBe(state)
  })

  test('should set isFullScreen false on leaveFullScreen', async () => {
    const state = { ...initialState, isFullScreen: true }
    const hook = await renderHook(() => useBacklash(() => [state], updates, noopInjects))

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
    const hook = await renderHook(() => useBacklash(() => [state], updates, noopInjects))

    await act(() => {
      getActions(hook).leaveFullScreen()
    })

    expect(getState(hook)).toBe(state)
  })
})
