import React from 'react'
import { Pressable, Text, View } from 'react-native'
import { usePipe } from 'use-pipe-ts'
import { Item } from './SegmentedControl'
import { styles } from './styles'

type Props = Item & {
  readonly position: 'left' | 'middle' | 'right'
  readonly index: number
  readonly selected: boolean
  readonly onSelect: (index: number) => void
}

export const SegmentedControlItem = React.memo(function SegmentedControlItem({
  onSelect,
  index,
  selected,
  position,
  ...props
}: Props) {
  const select = usePipe([onSelect, index])

  if ('label' in props) {
    const { label } = props

    return (
      <Pressable style={styles.item[position]} disabled={selected} onPress={select}>
        {({ pressed }) => (
          <View style={styles.labelContainer[position](pressed, selected)}>
            <Text style={styles.label(selected || pressed)}>{label}</Text>
          </View>
        )}
      </Pressable>
    )
  }

  const { color } = props

  return (
    <Pressable style={styles.item[position]} disabled={selected} onPress={select}>
      {({ pressed }) => (
        <View style={styles.colorContainer[position](pressed, color)}>
          <Text style={styles.colorMark(selected, color)}>●</Text>
        </View>
      )}
    </Pressable>
  )
})
