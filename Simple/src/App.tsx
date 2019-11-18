import React from 'react'
import {
  View,
  StyleSheet,
  Image,
  ImageBackground,
  Text
} from 'react-native'
import { DuoTone } from 'react-native-color-matrix-image-filters'
import FastImage from 'react-native-fast-image'

export default class App extends React.Component<{}> {

  render() {

    return (
      <View style={styles.container}>
        <Text>Image</Text>
        <DuoTone secondColor={'red'}>
          <Image
            style={styles.image}
            source={require('../mood.png')}
            resizeMode={'stretch'}
          />
        </DuoTone>
        <Text>ImageBackground</Text>
        <DuoTone secondColor={'green'}>
          <ImageBackground
            style={styles.image}
            source={require('../mood.png')}
            resizeMode={'stretch'}
          >
            <Image
              style={styles.innerImage}
              source={require('../mood.png')}
            />
          </ImageBackground>
        </DuoTone>
        <Text>FastImage</Text>
        <DuoTone secondColor={'blue'}>
          <FastImage
            style={styles.image}
            source={require('../mood.png')}
            resizeMode={'stretch'}
          />
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
