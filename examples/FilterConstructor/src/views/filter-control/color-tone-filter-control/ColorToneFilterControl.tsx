import React from 'react'
import { useBacklash } from 'react-use-backlash'
import { Filters } from '../../../domain'
import { SegmentedColorControl } from '../../segmented-control'
import { SliderControl } from '../../slider-control'
import { separator } from '../separator'
import { init, updates, Injects as Props } from './state'

export const ColorToneFilterControl = React.memo(function ColorToneFilterControl(props: Props) {
  const [, { changeDesaturation, changeToned, selectDarkColor, selectLightColor }] = useBacklash(
    init,
    updates,
    props
  )

  const { tag, desaturation, darkColor, lightColor, toned } = props

  const {
    desaturation: desaturationMinMax,
    toned: tonedMinMax,
    lightColor: { variants: lightColorVariants },
    darkColor: { variants: darkColorVariants }
  } = Filters.filterControlConstraints[tag]

  return (
    <>
      <SliderControl
        {...desaturationMinMax}
        name={'desaturation'}
        value={desaturation}
        onChange={changeDesaturation}
      />
      {separator}
      <SliderControl {...tonedMinMax} name={'toned'} value={toned} onChange={changeToned} />
      {separator}
      <SegmentedColorControl
        items={lightColorVariants}
        selectedItem={lightColor}
        onSelect={selectLightColor}
      />
      {separator}
      <SegmentedColorControl
        items={darkColorVariants}
        selectedItem={darkColor}
        onSelect={selectDarkColor}
      />
    </>
  )
})
