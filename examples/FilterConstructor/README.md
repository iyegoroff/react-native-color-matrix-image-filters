Run all scripts from `examples/FilterConstructor` folder.

### Install

- run `npm i`

### Configure to run old arch version

- open `examples/FilterConstructor/android/gradle.properties` and set `newArchEnabled` to `false`
- run `npm run clean && npx pod-install `

### Configure to run new arch version

- open `examples/FilterConstructor/android/gradle.properties` and set `newArchEnabled` to `true`
- run `npm run clean && RCT_NEW_ARCH_ENABLED=1 npx pod-install `
