import React from 'react'
import { View, StyleSheet, Image, ImageBackground, Text, ImageRequireSource } from 'react-native'
import { DuoTone } from 'react-native-color-matrix-image-filters'

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
            <Image style={styles.innerImage} source={this.mood} />
          </ImageBackground>
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
