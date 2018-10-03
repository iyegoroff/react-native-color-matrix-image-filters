import * as React from 'react';
import * as ReactNative from 'react-native';

export type Matrix = [
  number, number, number, number, number, number, number, number, number, number,
  number, number, number, number, number, number, number, number, number, number
];

interface FilterProps extends ReactNative.ViewProps { }

export interface ValueFilterProps extends FilterProps {
  readonly value?: number;
}

export interface ColorMatrixProps extends FilterProps {
  readonly matrix: Readonly<Matrix> | ReadonlyArray<Readonly<Matrix>>;
}

export interface ColorToneProps extends FilterProps {
  readonly desaturation?: number;
  readonly toned?: number;
  readonly lightColor?: string;
  readonly darkColor?: string;
}

export interface RGBAProps extends FilterProps {
  readonly red?: number;
  readonly green?: number;
  readonly blue?: number;
  readonly alpha?: number;
}

export interface DuoToneProps extends FilterProps {
  readonly firstColor?: string;
  readonly secondColor?: string;
}

export class ColorMatrix extends React.Component<ColorMatrixProps> { }
export class Normal extends React.Component<FilterProps> { }
export class RGBA extends React.Component<RGBAProps> {}
export class Saturate extends React.Component<ValueFilterProps> { }
export class HueRotate extends React.Component<ValueFilterProps> { }
export class LuminanceToAlpha extends React.Component<FilterProps> { }
export class Invert extends React.Component<FilterProps> { }
export class BlackAndWhite extends React.Component<FilterProps> { }
export class Grayscale extends React.Component<ValueFilterProps> { }
export class Sepia extends React.Component<FilterProps> { }
export class Nightvision extends React.Component<FilterProps> { }
export class Warm extends React.Component<FilterProps> { }
export class Cool extends React.Component<FilterProps> { }
export class Brightness extends React.Component<ValueFilterProps> { }
export class Exposure extends React.Component<ValueFilterProps> { }
export class Contrast extends React.Component<ValueFilterProps> { }
export class Temperature extends React.Component<ValueFilterProps> { }
export class Tint extends React.Component<ValueFilterProps> { }
export class Threshold extends React.Component<ValueFilterProps> { }
export class Technicolor extends React.Component<FilterProps> { }
export class Polaroid extends React.Component<FilterProps> { }
export class ToBGR extends React.Component<FilterProps> { }
export class Kodachrome extends React.Component<FilterProps> { }
export class Browni extends React.Component<FilterProps> { }
export class Vintage extends React.Component<FilterProps> { }
export class Night extends React.Component<ValueFilterProps> { }
export class Predator extends React.Component<ValueFilterProps> { }
export class Lsd extends React.Component<FilterProps> { }
export class ColorTone extends React.Component<ColorToneProps> { }
export class DuoTone extends React.Component<DuoToneProps> { }
export class Protanomaly extends React.Component<FilterProps> { }
export class Deuteranomaly extends React.Component<FilterProps> { }
export class Tritanomaly extends React.Component<FilterProps> { }
export class Protanopia extends React.Component<FilterProps> { }
export class Deuteranopia extends React.Component<FilterProps> { }
export class Tritanopia extends React.Component<FilterProps> { }
export class Achromatopsia extends React.Component<FilterProps> { }
export class Achromatomaly extends React.Component<FilterProps> { }


export function concatColorMatrices(matrices: Matrix[]): Matrix;

export function normal(): Matrix;
export function rgba(red?: number, green?: number, blue?: number, alpha?: number): Matrix;
export function saturate(value?: number): Matrix;
export function hueRotate(value?: number): Matrix;
export function luminanceToAlpha(): Matrix;
export function invert(): Matrix;
export function blackAndWhite(): Matrix;
export function grayscale(value?: number): Matrix;
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
export function technicolor(): Matrix;
export function polaroid(): Matrix;
export function toBGR(): Matrix;
export function kodachrome(): Matrix;
export function browni(): Matrix;
export function vintage(): Matrix;
export function night(value?: number): Matrix;
export function predator(value?: number): Matrix;
export function lsd(): Matrix;
export function colorTone(
  desaturation?: number,
  toned?: number,
  lightColor?: string,
  darkColor?: string
): Matrix;
export function duoTone(firstColor?: string, secondColor?: string): Matrix;
export function protanomaly(): Matrix;
export function deuteranomaly(): Matrix;
export function tritanomaly(): Matrix;
export function protanopia(): Matrix;
export function deuteranopia(): Matrix;
export function tritanopia(): Matrix;
export function achromatopsia(): Matrix;
export function achromatomaly(): Matrix;
