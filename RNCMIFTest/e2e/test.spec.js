/* eslint-env detox/detox, jest */

import jestExpect from 'expect'
import screenshot from 'detox-take-screenshot'

const path = (name) => `${__dirname}/__snapshots__/${name}-${device.getPlatform()}.snap.png`

const tests = [
  'Grayscale(Nested)',
  'Invert(FastImage)',
  'DuoTone(ImageBackground)',
  'ColorMatrix',
  'ColorMatrix(concatColorMatrices)',
  'Normal',
  'RGBA',
  'Saturate',
  'HueRotate',
  'LuminanceToAlpha',
  'Invert',
  'Grayscale',
  'Sepia',
  'Nightvision',
  'Warm',
  'Cool',
  'Brightness',
  'Contrast',
  'Temperature',
  'Tint',
  'Threshold',
  'Technicolor',
  'Polaroid',
  'ToBGR',
  'Kodachrome',
  'Browni',
  'Vintage',
  'Night',
  'Predator',
  'Lsd',
  'ColorTone',
  'DuoTone',
  'Protanomaly',
  'Deuteranomaly',
  'Tritanomaly',
  'Protanopia',
  'Deuteranopia',
  'Tritanopia',
  'Achromatopsia',
  'Achromatomaly'
]

const delay = async (n) => (
  new Promise((resolve) => {
    setTimeout(resolve, n)
  })
)

describe('Test', () => {
  beforeEach(async () => {
    await device.reloadReactNative()
  })

  it('image should be visible', async () => {
    await expect(element(by.id('image'))).toBeVisible()
  })

  tests.forEach(test => {
    it(test, async () => {
      await element(by.id(test)).tap()
      await delay(250)
      await element(by.id(test)).tap()
      await delay(250)

      await jestExpect(await screenshot()).toMatchImageSnapshot({ path: path(test) })
    })
  })
})
