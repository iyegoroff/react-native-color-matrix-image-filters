import React from 'react'
import { View } from 'react-native'

type Props = {
  readonly size: number
}

export const Gap = React.memo(function Gap({ size }: Props) {
  return <View style={{ width: size, height: size }} />
})
