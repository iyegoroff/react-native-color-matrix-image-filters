import React from 'react'
import { useBacklash } from 'react-use-backlash'
import { Filters } from '../../../domain'
import { SegmentedColorControl } from '../../segmented-control'
import { separator } from '../separator'

import { init, updates, Injects as Props } from './state'

export const DuoToneFilterControl = React.memo(function DuoToneFilterControl(props: Props) {
  const [, { selectFirst, selectSecond }] = useBacklash(init, updates, props)

  const { tag, first, second } = props

  const {
    first: { variants: firstVariants },
    second: { variants: secondVariants }
  } = Filters.filterControlConstraints[tag]

  return (
    <>
      <SegmentedColorControl items={firstVariants} selectedItem={first} onSelect={selectFirst} />
      {separator}
      <SegmentedColorControl items={secondVariants} selectedItem={second} onSelect={selectSecond} />
    </>
  )
})
