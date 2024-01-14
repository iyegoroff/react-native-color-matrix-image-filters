import { filters } from './filters'

export type Filter = (typeof filters)[number]

export type AmountFilter = Extract<Filter, { amount: number }>
export type ColorToneFilter = Extract<Filter, { tag: 'ColorTone' }>
export type RGBAFilter = Extract<Filter, { tag: 'RGBA' }>
export type DuoToneFilter = Extract<Filter, { tag: 'DuoTone' }>
export type NoControlsFilter = Exclude<
  Filter,
  AmountFilter | ColorToneFilter | RGBAFilter | DuoToneFilter
>
