import React from 'react'
import { Pressable, Text, View } from 'react-native'
import { memo } from 'ts-react-memo'
import { usePipe } from 'use-pipe-ts'
import { styles } from './styles'

type Props<Item extends string> = {
  readonly variant: 'colors' | 'labels'
  readonly position: 'left' | 'middle' | 'right'
  readonly item: Item
  readonly onSelect: (item: Item) => void
  readonly selected: boolean
}

export const SegmentedControlItem = memo(function SegmentedControlItem<Item extends string>({
  onSelect,
  item,
  selected,
  position,
  variant
}: Props<Item>) {
  const select = usePipe([onSelect, item])

  return variant === 'labels' ? (
    <Pressable style={styles.item[position]} disabled={selected} onPress={select}>
      {({ pressed }) => (
        <View
          removeClippedSubviews={true}
          style={styles.labelContainer[position](pressed, selected)}
        >
          <Text style={styles.label(selected || pressed)}>{item}</Text>
        </View>
      )}
    </Pressable>
  ) : (
    <Pressable style={styles.item[position]} disabled={selected} onPress={select}>
      {({ pressed }) => (
        <View style={styles.colorContainer[position](pressed, item)}>
          <Text style={styles.colorMark(selected, item)}>●</Text>
        </View>
      )}
    </Pressable>
  )
})
