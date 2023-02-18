import React from 'react'
import { Pressable } from 'react-native'
import { memo } from 'ts-react-memo'
import { usePipe } from 'use-pipe-ts'
import { SegmentedControlItem, SegmentedControlItemProps } from './SegmentedControlItem'
import { styles } from './styles'

type Props<Item extends string> = Omit<SegmentedControlItemProps<Item>, 'pressed'> & {
  readonly onSelect: (item: Item) => void
}

export const SegmentedControlPressable = memo(function SegmentedControlPressable<
  Item extends string
>({ onSelect, ...restProps }: Props<Item>) {
  const { item, selected, position } = restProps
  const select = usePipe([onSelect, item])

  return (
    <Pressable style={styles.item[position]} disabled={selected} onPress={select}>
      {(pressed) => <SegmentedControlItem {...pressed} {...restProps} />}
    </Pressable>
  )
})
