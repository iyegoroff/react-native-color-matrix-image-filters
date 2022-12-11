import React from 'react'
import { Text, View } from 'react-native'
import { styles } from './style'
import { AmountFilterControl } from './AmountFilterControl'
import { ColorToneFilterControl } from './color-tone-filter-control'
import { DuoToneFilterControl } from './duo-tone-filter-control'
import { RGBAFilterControl } from './rgba-filter-control'
import { Button } from '../button'
import { separator } from './separator'
import { Filter } from '../../domain'

type Props = Filter & {
  update: (filter: Filter) => void
  remove: () => void
  moveUp?: () => void
  moveDown?: () => void
}

export const FilterControl = React.memo(function FilterControl({
  remove,
  moveUp,
  moveDown,
  ...props
}: Props) {
  return (
    <View style={styles.container}>
      <View style={styles.header}>
        <Text style={styles.label}>{props.tag}</Text>
        <Button label={'up'} onPress={moveUp} />
        {separator}
        <Button label={'down'} onPress={moveDown} />
        {separator}
        <Button label={'remove'} onPress={remove} />
      </View>
      {separator}
      {(() => {
        switch (props.tag) {
          case 'Achromatomaly':
          case 'Achromatopsia':
          case 'Browni':
          case 'Cool':
          case 'Deuteranomaly':
          case 'Deuteranopia':
          case 'Invert':
          case 'Kodachrome':
          case 'Lsd':
          case 'LuminanceToAlpha':
          case 'Nightvision':
          case 'Normal':
          case 'Polaroid':
          case 'Protanomaly':
          case 'Protanopia':
          case 'Technicolor':
          case 'ToBGR':
          case 'Tritanomaly':
          case 'Tritanopia':
          case 'Vintage':
          case 'Warm':
            // eslint-disable-next-line no-null/no-null
            return null

          case 'Brightness':
          case 'Contrast':
          case 'Grayscale':
          case 'HueRotate':
          case 'Night':
          case 'Predator':
          case 'Saturate':
          case 'Sepia':
          case 'Temperature':
          case 'Threshold':
          case 'Tint':
            return <AmountFilterControl {...props} />

          case 'ColorTone':
            return <ColorToneFilterControl {...props} />

          case 'RGBA':
            return <RGBAFilterControl {...props} />

          case 'DuoTone':
            return <DuoToneFilterControl {...props} />
        }
      })()}
    </View>
  )
})
