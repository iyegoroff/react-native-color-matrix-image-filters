import React from 'react'
import { Pressable, Text, View } from 'react-native'
import { styles } from './style'

type Props = {
  readonly label: string
  readonly onPress?: () => void
}

export const Button = React.memo(function Button({ label, onPress }: Props) {
  const disabled = onPress === undefined

  return disabled ? (
    <View style={styles.disabledContainer}>
      <View style={styles.background(false)}>
        <Text style={styles.disabledLabel}>{label}</Text>
      </View>
    </View>
  ) : (
    <Pressable style={styles.container} onPress={onPress} disabled={disabled}>
      {({ pressed }) => (
        <View style={styles.background(pressed)}>
          <Text style={styles.label(pressed)}>{label}</Text>
        </View>
      )}
    </Pressable>
  )
})
