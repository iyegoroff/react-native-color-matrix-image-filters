import React from 'react'
import { SegmentedControl, SegmentedControlProps } from './SegmentedControl'

export const SegmentedLabelControl = <Item extends string>(
  props: Omit<SegmentedControlProps<Item>, 'variant'>
) => <SegmentedControl variant='labels' {...props} />
