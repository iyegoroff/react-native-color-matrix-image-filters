import React from 'react'
import { Image, SafeAreaView } from 'react-native'
import { useBacklash } from 'use-backlash'
import { SegmentedControl } from '../segmented-control'
import { SliderControl } from '../slider-control'
import { init, resizeModes, update } from './state'
import { styles } from './styles'

declare const require: (name: string) => number

export const App = () => {
  const [{ selectedIndex, selectedMode }, { select }] = useBacklash(init, update)

  return (
    <SafeAreaView style={styles.container}>
      <Image source={require('../../parrot.jpg')} style={styles.image} resizeMode={selectedMode} />
      <SegmentedControl items={resizeModes} selectedIndex={selectedIndex} onSelect={select} />
      <SliderControl min={0} max={1} name={'matrix'} onChange={(x) => console.warn(x)} />
    </SafeAreaView>
  )
}
