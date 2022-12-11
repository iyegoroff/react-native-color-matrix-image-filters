import { UpdateMap } from 'react-use-backlash'
import { DuoToneFilter } from '../../../domain'

type State = undefined

type Actions = {
  selectFirst: [first: string]
  selectSecond: [second: string]
}

export type Injects = DuoToneFilter & {
  update: (filter: DuoToneFilter) => void
}

export const init = () => [undefined] as const

export const updates: UpdateMap<State, Actions, Injects> = {
  selectFirst: (state, first) => [state, (_, { update, ...props }) => update({ ...props, first })],

  selectSecond: (state, second) => [
    state,
    (_, { update, ...props }) => update({ ...props, second })
  ]
}
