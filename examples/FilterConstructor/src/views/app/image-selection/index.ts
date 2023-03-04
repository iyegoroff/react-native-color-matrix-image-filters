import { Command, UpdateMap } from 'react-use-backlash'
import { ResizeMode } from '../../../domain'
import { Alert, ImagePicker } from '../../../services'
import { errorMessage } from '../../../utils'

type State = {
  selectedResizeMode: ResizeMode
  image: { static: number } | { uri: string }
  isFullScreen: boolean
  showFullScreenNotice: boolean
}

type Actions = {
  selectResizeMode: [resizeMode: ResizeMode]
  takePhotoFromCamera: []
  pickPhotoFromLibrary: []
  updatePhoto: [image: { uri: string }]
  enterFullScreen: []
  leaveFullScreen: []
}

type Injects = ImagePicker & Alert

const init = (image: State['image']): Command<State, Actions, Injects> => [
  {
    selectedResizeMode: 'center',
    image,
    isFullScreen: false,
    showFullScreenNotice: true
  }
]

const takePhoto =
  (source: 'camera' | 'library') =>
  (state: State): Command<State, Actions, Injects> =>
    [
      state,
      async ({ updatePhoto }, { pickPhotoFromLibrary, takePhotoFromCamera, showAlert }) => {
        try {
          const photo = await (source === 'camera' ? takePhotoFromCamera : pickPhotoFromLibrary)()
          if (photo !== 'canceled') {
            updatePhoto(photo)
          }
        } catch (e) {
          showAlert('Failed retrieving photo', errorMessage(e))
        }
      }
    ]

const updates: UpdateMap<State, Actions, Injects> = {
  selectResizeMode: (state, selectedResizeMode) =>
    selectedResizeMode === state.selectedResizeMode ? [state] : [{ ...state, selectedResizeMode }],

  takePhotoFromCamera: takePhoto('camera'),

  pickPhotoFromLibrary: takePhoto('library'),

  updatePhoto: (state, image) => [{ ...state, image }],

  enterFullScreen: (state) => [
    state.isFullScreen ? state : { ...state, isFullScreen: true, showFullScreenNotice: false }
  ],

  leaveFullScreen: (state) => [!state.isFullScreen ? state : { ...state, isFullScreen: false }]
}

export const ImageSelection = { init, updates } as const
