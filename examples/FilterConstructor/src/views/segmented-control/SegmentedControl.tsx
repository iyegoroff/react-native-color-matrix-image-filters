import React, { Fragment } from 'react'
import { View } from 'react-native'
import { memo } from 'ts-react-memo'
import { SegmentedControlPressable } from './SegmentedControlPressable'
import { styles } from './styles'

export type SegmentedControlProps<Item extends string> = {
  readonly variant: 'colors' | 'labels'
  readonly items: readonly [Item, Item, ...(readonly Item[])]
  readonly selectedItem: Item
  readonly onSelect: (item: Item) => void
}

const separator = <View style={styles.separator} />

export const SegmentedControl = memo(function SegmentedControl<Item extends string>({
  items,
  selectedItem,
  onSelect,
  variant
}: SegmentedControlProps<Item>) {
  return (
    <View style={styles.container}>
      {items.map((item, index) => {
        const position = index === 0 ? 'left' : index === items.length - 1 ? 'right' : 'middle'

        return (
          <Fragment key={item}>
            <SegmentedControlPressable<Item>
              variant={variant}
              item={item}
              position={position}
              onSelect={onSelect}
              selected={selectedItem === item}
            />
            {position !== 'right' && separator}
          </Fragment>
        )
      })}
    </View>
  )
})
