import React, { Fragment } from 'react'
import { View } from 'react-native'
import { SegmentedControlItem } from './SegmentedControlItem'
import { styles } from './styles'

export type Item = { readonly color: string } | { readonly label: string }

type Props = {
  readonly items: readonly [Item, Item, ...(readonly Item[])]
  readonly selectedIndex: number
  readonly onSelect: (selectedIndex: number) => void
}

const separator = <View style={styles.separator} />

export const SegmentedControl = React.memo(function SegmentedControl({
  items,
  selectedIndex,
  onSelect
}: Props) {
  return (
    <View style={styles.container}>
      {items.map((item, index) => {
        const position = index === 0 ? 'left' : index === items.length - 1 ? 'right' : 'middle'

        return (
          <Fragment key={index}>
            <SegmentedControlItem
              {...item}
              position={position}
              index={index}
              onSelect={onSelect}
              selected={selectedIndex === index}
            />
            {position !== 'right' && separator}
          </Fragment>
        )
      })}
    </View>
  )
})
