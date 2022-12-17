import React, { useMemo, useState } from 'react'
import Slider from '@react-native-community/slider'
import { debounce } from 'debounce'
import { Text, View } from 'react-native'
import { styles } from './styles'

type Props = {
  readonly min: number
  readonly max: number
  readonly value: number
  readonly name: string
  readonly onChange: (value: number) => void
}

export const SliderControl = React.memo(function SliderControl({
  min,
  max,
  value,
  name,
  onChange
}: Props) {
  const [initial] = useState(value)
  const onChangeDebounced = useMemo(() => debounce(onChange, 25), [onChange])

  return (
    <View style={styles.container}>
      <Text style={styles.name}>
        {name} {value.toFixed(3).replace(/\.?0+$/, '')}
      </Text>
      <Slider
        minimumValue={min}
        maximumValue={max}
        value={initial}
        onValueChange={onChangeDebounced}
        style={styles.slider}
      />
      <View style={styles.bottom}>
        <Text style={styles.label}>{min}</Text>
        <Text style={styles.label}>{max}</Text>
      </View>
    </View>
  )
})
