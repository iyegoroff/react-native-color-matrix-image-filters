FROM iyegoroff/fable-android:1

RUN mkdir /package
COPY . /package
WORKDIR /package/MatrixFilterConstructor

RUN npm i --unsafe-perm
RUN npm run generate:android:bundle
RUN rm -rf node_modules/.bin && rm -rf ../node_modules/.bin
RUN cd android && ./gradlew assembleRelease
