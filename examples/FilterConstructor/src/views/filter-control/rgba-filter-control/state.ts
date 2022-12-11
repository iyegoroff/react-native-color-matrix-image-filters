import { UpdateMap } from 'react-use-backlash'
import { RGBAFilter } from '../../../domain'

type State = undefined

type Actions = {
  changeR: [amount: number]
  changeG: [amount: number]
  changeB: [amount: number]
  changeA: [amount: number]
}

export type Injects = RGBAFilter & {
  update: (filter: RGBAFilter) => void
}

export const init = () => [undefined] as const

export const updates: UpdateMap<State, Actions, Injects> = {
  changeR: (state, r) => [state, (_, { update, ...props }) => update({ ...props, r })],

  changeG: (state, g) => [state, (_, { update, ...props }) => update({ ...props, g })],

  changeB: (state, b) => [state, (_, { update, ...props }) => update({ ...props, b })],

  changeA: (state, a) => [state, (_, { update, ...props }) => update({ ...props, a })]
}
