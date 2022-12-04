import React from 'react'
import { SegmentedControl, SegmentedControlProps } from './SegmentedControl'

export const SegmentedColorControl = <Item extends string>(
  props: Omit<SegmentedControlProps<Item>, 'variant'>
) => <SegmentedControl variant='colors' {...props} />
