import React from 'react'
import { Image, ImageStyle, ImageURISource } from 'react-native'
import { ColorMatrix, Matrix } from 'react-native-color-matrix-image-filters'
import { ResizeMode } from '../../domain'

type Props = {
  style: ImageStyle
  matrix: Matrix
  image: { static: number } | ImageURISource
  resizeMode: ResizeMode
}

export const FilteredImage = React.memo(function FilteredImage({
  style,
  matrix,
  image,
  resizeMode
}: Props) {
  return (
    <ColorMatrix style={style} matrix={matrix}>
      <Image
        source={'static' in image ? image.static : image}
        style={style}
        resizeMode={resizeMode}
        key={resizeMode}
      />
    </ColorMatrix>
  )
})
