FROM nojaf/fable:latest as bundle

# Add the WebUpd8 Oracle Java PPA repository for OpenJDK8 and enable gradle daemon
RUN echo "deb http://ppa.launchpad.net/webupd8team/java/ubuntu xenial main" | tee /etc/apt/sources.list.d/webupd8team-java.list && \
    echo "deb-src http://ppa.launchpad.net/webupd8team/java/ubuntu xenial main" | tee -a /etc/apt/sources.list.d/webupd8team-java.list && \
    apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys EEA14886 && \
    echo "oracle-java8-installer shared/accepted-oracle-license-v1-1 select true" | debconf-set-selections && \
    mkdir -p ~/.gradle/ && \
    touch ~/.gradle/gradle.properties && \
    echo "org.gradle.daemon=true" >> ~/.gradle/gradle.properties

# Enable multiarch i386, install OpenJDK, ADB & AAPT
RUN dpkg --add-architecture i386 && \
    apt-get -yqq update && \
    apt-get -yqq --no-install-recommends install oracle-java8-installer libc6:i386 libncurses5:i386 libstdc++6:i386 lib32z1 unzip && \
    apt-get -yqq autoremove && \
    apt-get -yqq clean && \
    rm -rf /var/lib/apt/lists/* /var/cache/* /tmp/* /var/tmp/*

ENV SDK_URL="https://dl.google.com/android/repository/sdk-tools-linux-4333796.zip" \
    ANDROID_HOME="/usr/local/android-sdk" \
    ANDROID_VERSION=28 \
    ANDROID_BUILD_TOOLS_VERSION=28.0.3

# Download Android SDK
RUN mkdir "$ANDROID_HOME" .android \
    && cd "$ANDROID_HOME" \
    && curl -o sdk.zip $SDK_URL \
    && unzip sdk.zip \
    && rm sdk.zip \
    && yes | $ANDROID_HOME/tools/bin/sdkmanager --licenses

# Install Android Build Tool and Libraries
RUN $ANDROID_HOME/tools/bin/sdkmanager --update
RUN $ANDROID_HOME/tools/bin/sdkmanager "build-tools;${ANDROID_BUILD_TOOLS_VERSION}" \
    "platforms;android-${ANDROID_VERSION}" \
    "platform-tools"

RUN mkdir /package
COPY . /package
WORKDIR /package/MatrixFilterConstructor
RUN npm i npm@6.4.1 -g
RUN npm i --unsafe-perm
RUN npm run paket:install
RUN npm run generate:android:bundle
RUN rm -rf node_modules/.bin && rm -rf ../node_modules/.bin
RUN cd android && ./gradlew assembleRelease
