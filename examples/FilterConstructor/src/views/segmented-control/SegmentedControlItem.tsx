import React, { useMemo } from 'react'
import { Text, View } from 'react-native'
import { memo } from 'ts-react-memo'
import { styles } from './styles'

export type SegmentedControlItemProps<Item extends string> = {
  readonly variant: 'colors' | 'labels'
  readonly position: 'left' | 'middle' | 'right'
  readonly item: Item
  readonly selected: boolean
  readonly pressed: boolean
}

export const SegmentedControlItem = memo(function SegmentedControlItem<Item extends string>({
  item,
  selected,
  position,
  variant,
  pressed
}: SegmentedControlItemProps<Item>) {
  const checkMarkStyle = useMemo(() => styles.colorMark(selected, item), [selected, item])

  const colorContainerStyle = useMemo(
    () => styles.colorContainer[position](pressed, item),
    [position, pressed, item]
  )

  const labelContainerStyle = useMemo(
    () => styles.labelContainer[position](pressed, selected),
    [position, pressed, selected]
  )

  return variant === 'labels' ? (
    <View removeClippedSubviews={true} style={labelContainerStyle}>
      <Text style={selected || pressed ? styles.selectedLabel : styles.label}>{item}</Text>
    </View>
  ) : (
    <View style={colorContainerStyle}>
      <Text style={checkMarkStyle}>●</Text>
    </View>
  )
})
