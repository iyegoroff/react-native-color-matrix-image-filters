namespace MatrixFilterConstructor

module JSTemplateAnimated =

  let template = """import * as React from 'react';
import { Image } from 'react-native';
import {
  ColorMatrix,
  concatColorMatrices,
  __IMPORTS__
} from 'react-native-color-matrix-image-filters';

export default class FilteredImage extends React.Component {
  frameId = undefined;
  state = {};

  constructor(props) {
    super(props);

    this.state = {
      __INITSTATE__
    };
  }

  componentDidMount() {
    this.animate();
  }

  componentWillUnmount() {
    cancelAnimationFrame(this.frameId);
  }

  animate = () => {
    this.setState((state, props) => {
      __ANIMATE__
    });
    this.frameId = requestAnimationFrame(this.animate);
  }

  render() {
    const {
      __PROPS__
      ...imageProps
    } = this.props;

    const {
      __STATE__
    } = this.state;

    const matrix = concatColorMatrices([
      __MATRICES__
    ]);

    return (
      <ColorMatrix matrix={matrix}>
        <Image {...imageProps} />
      </ColorMatrix>
    );
  }
}
"""
