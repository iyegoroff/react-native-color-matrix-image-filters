import Slider from '@react-native-community/slider'
import React from 'react'
import { Text, View } from 'react-native'
import { styles } from './styles'

type Props = {
  readonly min: number
  readonly max: number
  readonly name: string
  readonly onChange: (value: number) => void
}

export const SliderControl = React.memo(function SliderControl({
  min,
  max,
  name,
  onChange
}: Props) {
  return (
    <View style={styles.container}>
      <Text style={styles.label}>{name}</Text>
      <Slider
        minimumValue={min}
        maximumValue={max}
        value={(max - min) / 2}
        step={Math.pow(10, Math.log10(max - min) - 2)}
        onValueChange={onChange}
      />
      <View style={styles.bottom}>
        <Text style={styles.label}>{min}</Text>
        <Text style={styles.label}>{max}</Text>
      </View>
    </View>
  )
})
