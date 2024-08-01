import React from 'react'
import { View, StyleSheet, Image, ImageBackground, Text, ImageRequireSource } from 'react-native'
import { DuoTone, Normal } from 'react-native-color-matrix-image-filters'
import { Image as ExpoImage } from 'expo-image'

declare const require: (name: string) => number

export default class App extends React.Component {
  mood: ImageRequireSource = require('../mood.png')

  render() {
    return (
      <View style={styles.container}>
        <Text>Image</Text>
        <DuoTone secondColor={'red'}>
          <Image style={styles.image} source={this.mood} resizeMode={'stretch'} />
        </DuoTone>
        <Text>ImageBackground</Text>
        <DuoTone secondColor={'green'}>
          <ImageBackground style={styles.image} source={this.mood} resizeMode={'stretch'}>
            <Normal><Image style={styles.innerImage} source={this.mood} /></Normal>
          </ImageBackground>
        </DuoTone>
        <Text>ExpoImage</Text>
        <DuoTone secondColor={'blue'}>
          <ExpoImage style={styles.image} source={this.mood} contentFit={'fill'} />
        </DuoTone>
      </View>
    )
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'white'
  },
  image: {
    width: 150,
    height: 100,
    justifyContent: 'center',
    alignItems: 'center'
  },
  innerImage: {
    width: 50,
    height: 50
  }
})
