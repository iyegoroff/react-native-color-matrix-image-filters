### Run debug version
```bash
$ npm i react-native-color-matrix-image-filters
$ cd node_modules/react-native-color-matrix-image-filters/MatrixFilterConstructor
$ npm i
$ npm start
$ npm run run:android
```

### Build signed release apk with Docker
- Clone the repo `git clone git@github.com:iyegoroff/react-native-color-matrix-image-filters.git` or get it from npm
- Go to example folder `cd react-native-color-matrix-image-filters/MatrixFilterConstructor`
- Generate keystore `npm run generate:android:signing-key`
- Open `MatrixFilterConstructor/android/gradle.properties` file and replace `qwerty`s with your passwords
- Run `npm run build:release:docker` - upon script completion apk will be copied to `MatrixFilterConstructor/mfc.apk` file

### Download
Open [Yandex.Store](https://store.yandex.com/) Android app and search for `MatrixFilterConstructor`

<img src="https://github.com/iyegoroff/react-native-color-matrix-image-filters/raw/master/img/demo.gif" height="600">
