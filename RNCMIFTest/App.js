import React, { Component } from 'react'
import {
  StyleSheet,
  StatusBar,
  View,
  Image,
  TouchableOpacity,
  ImageBackground,
  ActivityIndicator,
  Platform
} from 'react-native'
import {
  ColorMatrix,
  Normal,
  RGBA,
  Saturate,
  HueRotate,
  LuminanceToAlpha,
  Invert,
  Grayscale,
  Sepia,
  Nightvision,
  Warm,
  Cool,
  Brightness,
  Contrast,
  Temperature,
  Tint,
  Threshold,
  Technicolor,
  Polaroid,
  ToBGR,
  Kodachrome,
  Browni,
  Vintage,
  Night,
  Predator,
  Lsd,
  ColorTone,
  DuoTone,
  Protanomaly,
  Deuteranomaly,
  Tritanomaly,
  Protanopia,
  Deuteranopia,
  Tritanopia,
  Achromatopsia,
  Achromatomaly,
  concatColorMatrices,
  invert,
  temperature,
  hueRotate
} from 'react-native-color-matrix-image-filters'
import FastImage from 'react-native-fast-image'

const TVTestCard = () => (
  <Image
    testID={'image'}
    style={styles.image}
    source={require('./PM5544_with_non-PAL_signals.png')}
    resizeMode={'contain'}
  />
)

const TVTestCardNested = () => (
  <View>
    <>
      <View>
        <Image
          testID={'image'}
          style={styles.image}
          source={require('./PM5544_with_non-PAL_signals.png')}
          resizeMode={'contain'}
        />
      </View>
    </>
  </View>
)

const TVTestCardFast = () => (
  <View testID={'image'}>
    <FastImage
      style={styles.image}
      source={require('./PM5544_with_non-PAL_signals.png')}
      resizeMode={'contain'}
    />
  </View>
)

const TVTestCardBackground = () => (
  <ImageBackground
    testID={'image'}
    style={styles.image}
    source={require('./PM5544_with_non-PAL_signals.png')}
    resizeMode={'contain'}
  >
    <Image
      style={styles.auxImage}
      source={require('./PM5544_with_non-PAL_signals.png')}
    />
  </ImageBackground>
)

const tests = [
  {
    id: 'Grayscale(Nested)',
    Component: Grayscale,
    props: {
      amount: 0.5
    },
    Target: TVTestCardNested
  },
  {
    id: 'Invert(FastImage)',
    Component: Invert,
    props: {},
    Target: TVTestCardFast
  },
  {
    id: 'DuoTone(ImageBackground)',
    Component: DuoTone,
    props: {},
    Target: TVTestCardBackground
  },
  {
    id: 'ColorMatrix',
    Component: ColorMatrix,
    props: {
      matrix: [
        1.4, -0.02, -0.02, 0, 0,
        -0.2, 1.3, -0.2, 0, 0,
        -0.6, -0.1, 1.83, 0, 0,
        0, 0, 0, 1, 0
      ]
    }
  },
  {
    id: 'ColorMatrix(concatColorMatrices)',
    Component: ColorMatrix,
    props: {
      matrix: concatColorMatrices([hueRotate(1.5), temperature(12.5), invert()])
    }
  },
  {
    id: 'Normal',
    Component: Normal,
    props: {}
  },
  {
    id: 'RGBA',
    Component: RGBA,
    props: {
      red: 0.5,
      green: 0.25,
      blue: 0.75,
      alpha: 0.5
    }
  },
  {
    id: 'Saturate',
    Component: Saturate,
    props: {
      amount: 5
    }
  },
  {
    id: 'HueRotate',
    Component: HueRotate,
    props: {
      amount: Math.PI / 2
    }
  },
  {
    id: 'LuminanceToAlpha',
    Component: LuminanceToAlpha,
    props: {}
  },
  {
    id: 'Invert',
    Component: Invert,
    props: {}
  },
  {
    id: 'Grayscale',
    Component: Grayscale,
    props: {
      amount: 1
    }
  },
  {
    id: 'Sepia',
    Component: Sepia,
    props: {
      amount: 0.75
    }
  },
  {
    id: 'Nightvision',
    Component: Nightvision,
    props: {}
  },
  {
    id: 'Warm',
    Component: Warm,
    props: {}
  },
  {
    id: 'Cool',
    Component: Cool,
    props: {}
  },
  {
    id: 'Brightness',
    Component: Brightness,
    props: {
      amount: 2
    }
  },
  {
    id: 'Contrast',
    Component: Contrast,
    props: {
      amount: 5
    }
  },
  {
    id: 'Temperature',
    Component: Temperature,
    props: {
      amount: 5
    }
  },
  {
    id: 'Tint',
    Component: Tint,
    props: {
      amount: 3
    }
  },
  {
    id: 'Threshold',
    Component: Threshold,
    props: {}
  },
  {
    id: 'Technicolor',
    Component: Technicolor,
    props: {}
  },
  {
    id: 'Polaroid',
    Component: Polaroid,
    props: {}
  },
  {
    id: 'ToBGR',
    Component: ToBGR,
    props: {}
  },
  {
    id: 'Kodachrome',
    Component: Kodachrome,
    props: {}
  },
  {
    id: 'Browni',
    Component: Browni,
    props: {}
  },
  {
    id: 'Vintage',
    Component: Vintage,
    props: {}
  },
  {
    id: 'Night',
    Component: Night,
    props: {}
  },
  {
    id: 'Predator',
    Component: Predator,
    props: {}
  },
  {
    id: 'Lsd',
    Component: Lsd,
    props: {}
  },
  {
    id: 'ColorTone',
    Component: ColorTone,
    props: {}
  },
  {
    id: 'DuoTone',
    Component: DuoTone,
    props: {
      firstColor: 'red',
      secondColor: 'green'
    }
  },
  {
    id: 'Protanomaly',
    Component: Protanomaly,
    props: {}
  },
  {
    id: 'Deuteranomaly',
    Component: Deuteranomaly,
    props: {}
  },
  {
    id: 'Tritanomaly',
    Component: Tritanomaly,
    props: {}
  },
  {
    id: 'Protanopia',
    Component: Protanopia,
    props: {}
  },
  {
    id: 'Deuteranopia',
    Component: Deuteranopia,
    props: {}
  },
  {
    id: 'Tritanopia',
    Component: Tritanopia,
    props: {}
  },
  {
    id: 'Achromatopsia',
    Component: Achromatopsia,
    props: {}
  },
  {
    id: 'Achromatomaly',
    Component: Achromatomaly,
    props: {}
  }
]

export default class App extends Component {
  constructor (props) {
    super(props)

    this.state = {
      Component: React.Fragment,
      props: [],
      Target: TVTestCard
    }

    StatusBar.setHidden(true);
  }

  render () {
    const { Component, props, Target } = this.state

    return (
      <View
        testID={'container'}
        style={styles.container}
      >
        <Component {...props}>
          <Target />
        </Component>
        <View style={styles.controls}>
          {Platform.OS === 'ios' && <ActivityIndicator color={'white'} />}
          {tests.map(({ id, Component, props, Target = TVTestCard }) => (
            <TouchableOpacity
              testID={id}
              key={id}
              onPress={() => { this.setState({ Component, props, Target }) }}
            >
              <View style={styles.button} />
            </TouchableOpacity>
          ))}
        </View>
      </View>
    )
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    padding: 5,
    backgroundColor: 'white'
  },
  button: {
    backgroundColor: 'white',
    height: 25,
    width: 25
  },
  controls: {
    width: '100%',
    flexDirection: 'row',
    flexWrap: 'wrap',
    position: 'absolute',
    top: 350,
    left: 0
  },
  image: {
    width: 320,
    height: 320,
    alignItems: 'center',
    justifyContent: 'center'
  },
  auxImage: {
    width: 160,
    height: 160
  }
})
