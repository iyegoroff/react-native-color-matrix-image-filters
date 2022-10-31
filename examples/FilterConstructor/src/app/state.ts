import { UpdateMap } from 'use-backlash'

type State = {
  selectedMode: typeof resizeModes[number]['label']
  selectedIndex: number
}

type Action = [tag: 'select', selectedIndex: number]

export const resizeModes = [
  { label: 'center' },
  { label: 'contain' },
  { label: 'cover' },
  { label: 'repeat' },
  { label: 'stretch' }
] as const

export const init = () => [{ selectedMode: 'center', selectedIndex: 0 }] as const

export const update: UpdateMap<State, Action> = {
  select: (state, selectedIndex) => {
    const nextMode = resizeModes[selectedIndex]

    return state.selectedIndex === selectedIndex || nextMode === undefined
      ? [state]
      : [{ selectedIndex, selectedMode: nextMode.label }]
  }
}
