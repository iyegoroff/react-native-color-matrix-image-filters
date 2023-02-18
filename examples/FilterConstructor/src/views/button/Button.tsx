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
      <View style={styles.background}>
        <Text style={styles.disabledLabel}>{label}</Text>
      </View>
    </View>
  ) : (
    <Pressable style={styles.container} onPress={onPress} disabled={disabled}>
      {({ pressed }) => (
        <View style={pressed ? styles.pressedBackground : styles.background}>
          <Text style={pressed ? styles.pressedLabel : styles.label}>{label}</Text>
        </View>
      )}
    </Pressable>
  )
})
