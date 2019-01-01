import * as React from 'react';
import * as ReactNative from 'react-native';

export type Matrix = [
  number, number, number, number, number, number, number, number, number, number,
  number, number, number, number, number, number, number, number, number, number
];

interface FilterProps extends ReactNative.ViewProps { }

export interface ValueFilterProps extends FilterProps {
  readonly amount?: number;
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

export declare class ColorMatrix extends React.Component<ColorMatrixProps> { }
export declare class Normal extends React.Component<FilterProps> { }
export declare class RGBA extends React.Component<RGBAProps> { }
export declare class Saturate extends React.Component<ValueFilterProps> { }
export declare class HueRotate extends React.Component<ValueFilterProps> { }
export declare class LuminanceToAlpha extends React.Component<FilterProps> { }
export declare class Invert extends React.Component<FilterProps> { }
export declare class Grayscale extends React.Component<ValueFilterProps> { }
export declare class Sepia extends React.Component<ValueFilterProps> { }
export declare class Nightvision extends React.Component<FilterProps> { }
export declare class Warm extends React.Component<FilterProps> { }
export declare class Cool extends React.Component<FilterProps> { }
export declare class Brightness extends React.Component<ValueFilterProps> { }
export declare class Contrast extends React.Component<ValueFilterProps> { }
export declare class Temperature extends React.Component<ValueFilterProps> { }
export declare class Tint extends React.Component<ValueFilterProps> { }
export declare class Threshold extends React.Component<ValueFilterProps> { }
export declare class Technicolor extends React.Component<FilterProps> { }
export declare class Polaroid extends React.Component<FilterProps> { }
export declare class ToBGR extends React.Component<FilterProps> { }
export declare class Kodachrome extends React.Component<FilterProps> { }
export declare class Browni extends React.Component<FilterProps> { }
export declare class Vintage extends React.Component<FilterProps> { }
export declare class Night extends React.Component<ValueFilterProps> { }
export declare class Predator extends React.Component<ValueFilterProps> { }
export declare class Lsd extends React.Component<FilterProps> { }
export declare class ColorTone extends React.Component<ColorToneProps> { }
export declare class DuoTone extends React.Component<DuoToneProps> { }
export declare class Protanomaly extends React.Component<FilterProps> { }
export declare class Deuteranomaly extends React.Component<FilterProps> { }
export declare class Tritanomaly extends React.Component<FilterProps> { }
export declare class Protanopia extends React.Component<FilterProps> { }
export declare class Deuteranopia extends React.Component<FilterProps> { }
export declare class Tritanopia extends React.Component<FilterProps> { }
export declare class Achromatopsia extends React.Component<FilterProps> { }
export declare class Achromatomaly extends React.Component<FilterProps> { }


export function concatColorMatrices(matrices: Matrix[]): Matrix;

export function normal(): Matrix;
export function rgba(red?: number, green?: number, blue?: number, alpha?: number): Matrix;
export function saturate(amount?: number): Matrix;
export function hueRotate(amount?: number): Matrix;
export function luminanceToAlpha(): Matrix;
export function invert(): Matrix;
export function grayscale(amount?: number): Matrix;
export function sepia(amount?: number): Matrix;
export function nightvision(): Matrix;
export function warm(): Matrix;
export function cool(): Matrix;
export function brightness(amount?: number): Matrix;
export function contrast(amount?: number): Matrix;
export function temperature(amount?: number): Matrix;
export function tint(amount?: number): Matrix;
export function threshold(amount?: number): Matrix;
export function technicolor(): Matrix;
export function polaroid(): Matrix;
export function toBGR(): Matrix;
export function kodachrome(): Matrix;
export function browni(): Matrix;
export function vintage(): Matrix;
export function night(amount?: number): Matrix;
export function predator(amount?: number): Matrix;
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
