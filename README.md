
# react-native-color-matrix-image-filters

## Getting started

`$ npm install react-native-color-matrix-image-filters --save`

### Mostly automatic installation

`$ react-native link react-native-color-matrix-image-filters`

### Manual installation


#### iOS

1. In XCode, in the project navigator, right click `Libraries` ➜ `Add Files to [your project's name]`
2. Go to `node_modules` ➜ `react-native-color-matrix-image-filters` and add `RNColorMatrixImageFilters.xcodeproj`
3. In XCode, in the project navigator, select your project. Add `libRNColorMatrixImageFilters.a` to your project's `Build Phases` ➜ `Link Binary With Libraries`
4. Run your project (`Cmd+R`)<

#### Android

1. Open up `android/app/src/main/java/[...]/MainActivity.java`
  - Add `import com.reactlibrary.RNColorMatrixImageFiltersPackage;` to the imports at the top of the file
  - Add `new RNColorMatrixImageFiltersPackage()` to the list returned by the `getPackages()` method
2. Append the following lines to `android/settings.gradle`:
  	```
  	include ':react-native-color-matrix-image-filters'
  	project(':react-native-color-matrix-image-filters').projectDir = new File(rootProject.projectDir, 	'../node_modules/react-native-color-matrix-image-filters/android')
  	```
3. Insert the following lines inside the dependencies block in `android/app/build.gradle`:
  	```
      compile project(':react-native-color-matrix-image-filters')
  	```

#### Windows
[Read it! :D](https://github.com/ReactWindows/react-native)

1. In Visual Studio add the `RNColorMatrixImageFilters.sln` in `node_modules/react-native-color-matrix-image-filters/windows/RNColorMatrixImageFilters.sln` folder to their solution, reference from their app.
2. Open up your `MainPage.cs` app
  - Add `using Color.Matrix.Image.Filters.RNColorMatrixImageFilters;` to the usings at the top of the file
  - Add `new RNColorMatrixImageFiltersPackage()` to the `List<IReactPackage>` returned by the `Packages` method


## Usage
```javascript
import RNColorMatrixImageFilters from 'react-native-color-matrix-image-filters';

// TODO: What to do with the module?
RNColorMatrixImageFilters;
```
  