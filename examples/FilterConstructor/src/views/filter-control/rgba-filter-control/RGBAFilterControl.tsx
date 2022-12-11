import React from 'react'
import { useBacklash } from 'react-use-backlash'
import { Filters } from '../../../domain'
import { SliderControl } from '../../slider-control'
import { separator } from '../separator'
import { init, updates, Injects as Props } from './state'

export const RGBAFilterControl = React.memo(function RGBAFilterControl(props: Props) {
  const [, { changeR, changeG, changeB, changeA }] = useBacklash(init, updates, props)

  const { tag, r, g, b, a } = props

  const { r: rMinMax, g: gMinMax, b: bMinMax, a: aMinMax } = Filters.filterControlConstraints[tag]

  return (
    <>
      <SliderControl {...rMinMax} name={'r'} value={r} onChange={changeR} />
      {separator}
      <SliderControl {...gMinMax} name={'g'} value={g} onChange={changeG} />
      {separator}
      <SliderControl {...bMinMax} name={'b'} value={b} onChange={changeB} />
      {separator}
      <SliderControl {...aMinMax} name={'a'} value={a} onChange={changeA} />
    </>
  )
})
