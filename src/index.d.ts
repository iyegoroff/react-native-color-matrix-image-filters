import * as React from 'react';
import * as ReactNative from 'react-native';

export type Matrix = [
  number, number, number, number, number, number, number, number, number, number,
  number, number, number, number, number, number, number, number, number, number
];

interface FilterProps extends ReactNative.ViewProps { }

export interface ColorMatrixProps extends FilterProps {
  readonly matrix: Readonly<Matrix> | ReadonlyArray<Readonly<Matrix>>;
}

export class ColorMatrix extends React.Component<ColorMatrixProps> { }


export interface NormalProps extends FilterProps { }

export class Normal extends React.Component<NormalProps> { }


export interface SaturateProps extends FilterProps {
  readonly value?: number;
}

export class Saturate extends React.Component<SaturateProps> { }


export interface HueRotateProps extends FilterProps {
  readonly value?: number;
}

export class HueRotate extends React.Component<HueRotateProps> { }


export interface LuminanceToAlphaProps extends FilterProps { }

export class LuminanceToAlpha extends React.Component<LuminanceToAlphaProps> { }


export interface InvertProps extends FilterProps { }

export class Invert extends React.Component<InvertProps> { }


export interface GrayscaleProps extends FilterProps { }

export class Grayscale extends React.Component<GrayscaleProps> { }


export interface SepiaProps extends FilterProps { }

export class Sepia extends React.Component<SepiaProps> { }


export interface NightvisionProps extends FilterProps { }

export class Nightvision extends React.Component<NightvisionProps> { }


export interface WarmProps extends FilterProps { }

export class Warm extends React.Component<WarmProps> { }


export interface CoolProps extends FilterProps { }

export class Cool extends React.Component<CoolProps> { }


export interface BrightnessProps extends FilterProps {
  readonly value?: number;
}

export class Brightness extends React.Component<BrightnessProps> { }


export interface ExposureProps extends FilterProps {
  readonly value?: number;
}

export class Exposure extends React.Component<ExposureProps> { }


export interface ContrastProps extends FilterProps {
  readonly value?: number;
}

export class Contrast extends React.Component<ContrastProps> { }


export interface TemperatureProps extends FilterProps {
  readonly value?: number;
}

export class Temperature extends React.Component<TemperatureProps> { }


export interface TintProps extends FilterProps {
  readonly value?: number;
}

export class Tint extends React.Component<TintProps> { }


export interface ThresholdProps extends FilterProps {
  readonly value?: number;
}

export class Threshold extends React.Component<ThresholdProps> { }


export interface ProtanomalyProps extends FilterProps { }

export class Protanomaly extends React.Component<ProtanomalyProps> { }


export interface DeuteranomalyProps extends FilterProps { }

export class Deuteranomaly extends React.Component<DeuteranomalyProps> { }


export interface TritanomalyProps extends FilterProps { }

export class Tritanomaly extends React.Component<TritanomalyProps> { }


export interface ProtanopiaProps extends FilterProps { }

export class Protanopia extends React.Component<ProtanopiaProps> { }


export interface DeuteranopiaProps extends FilterProps { }

export class Deuteranopia extends React.Component<DeuteranopiaProps> { }


export interface TritanopiaProps extends FilterProps { }

export class Tritanopia extends React.Component<TritanopiaProps> { }


export interface AchromatopsiaProps extends FilterProps { }

export class Achromatopsia extends React.Component<AchromatopsiaProps> { }


export interface AchromatomalyProps extends FilterProps { }

export class Achromatomaly extends React.Component<AchromatomalyProps> { }


export function concatColorMatrices(matrices: Matrix[]): Matrix;

export function normal(): Matrix;
export function saturate(value?: number): Matrix;
export function hueRotate(value?: number): Matrix;
export function luminanceToAlpha(): Matrix;
export function invert(): Matrix;
export function grayscale(): Matrix;
export function sepia(): Matrix;
export function nightvision(): Matrix;
export function warm(): Matrix;
export function cool(): Matrix;
export function brightness(value?: number): Matrix;
export function exposure(value?: number): Matrix;
export function contrast(value?: number): Matrix;
export function temperature(value?: number): Matrix;
export function tint(value?: number): Matrix;
export function threshold(value?: number): Matrix;
export function protanomaly(): Matrix;
export function deuteranomaly(): Matrix;
export function tritanomaly(): Matrix;
export function protanopia(): Matrix;
export function deuteranopia(): Matrix;
export function tritanopia(): Matrix;
export function achromatopsia(): Matrix;
export function achromatomaly(): Matrix;
