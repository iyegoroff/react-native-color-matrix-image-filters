import { UpdateMap } from 'react-use-backlash'
import { ColorToneFilter } from '../../../domain'

type State = undefined

type Actions = {
  changeDesaturation: [amount: number]
  changeToned: [amount: number]
  selectLightColor: [lightColor: string]
  selectDarkColor: [darkColor: string]
}

export type Injects = ColorToneFilter & {
  update: (filter: ColorToneFilter) => void
}

export const init = () => [undefined] as const

export const updates: UpdateMap<State, Actions, Injects> = {
  changeDesaturation: (state, desaturation) => [
    state,
    (_, { update, ...props }) => update({ ...props, desaturation })
  ],

  changeToned: (state, toned) => [state, (_, { update, ...props }) => update({ ...props, toned })],

  selectDarkColor: (state, darkColor) => [
    state,
    (_, { update, ...props }) => update({ ...props, darkColor })
  ],

  selectLightColor: (state, lightColor) => [
    state,
    (_, { update, ...props }) => update({ ...props, lightColor })
  ]
}
