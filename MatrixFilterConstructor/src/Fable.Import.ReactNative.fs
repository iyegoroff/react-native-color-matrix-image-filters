namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

[<Erase>]
module ReactNative =
    module JSX =
        type Element = obj // added after import

    module NativeMethodsMixin =
        type MeasureOnSuccessCallback =
            (float -> float -> float -> float -> float -> float -> unit)

        and MeasureInWindowOnSuccessCallback =
            (float -> float -> float -> float -> unit)

        and MeasureLayoutOnSuccessCallback =
            (float -> float -> float -> float -> unit)

    module Animated =
        type AnimatedValue =
            Animated

        and AnimatedValueXY =
            ValueXY

        and Base =
            Animated

        and [<Import("Animated.Animated","react-native")>] Animated() =
            class end

        and [<Import("Animated.AnimatedWithChildren","react-native")>] AnimatedWithChildren() =
            inherit Animated()


        and [<Import("Animated.AnimatedInterpolation","react-native")>] AnimatedInterpolation() =
            inherit AnimatedWithChildren()
            member __.interpolate(config: InterpolationConfigType): AnimatedInterpolation = jsNative

        and [<StringEnum>] ExtrapolateType =
                | Extend | Identity | Clamp

        and InterpolationConfigType =
            obj

        and ValueListenerCallback =
            (obj -> unit)

        and [<Import("Animated.Value","react-native")>] Value(value: float) =
            inherit AnimatedWithChildren()
            member __.setValue(value: float): unit = jsNative
            member __.setOffset(offset: float): unit = jsNative
            member __.flattenOffset(): unit = jsNative
            member __.addListener(callback: ValueListenerCallback): string = jsNative
            member __.removeListener(id: string): unit = jsNative
            member __.removeAllListeners(): unit = jsNative
            member __.stopAnimation(?callback: (float -> unit)): unit = jsNative
            member __.interpolate(config: InterpolationConfigType): AnimatedInterpolation = jsNative

        and ValueXYListenerCallback =
            (obj -> unit)

        and [<Import("Animated.ValueXY","react-native")>] ValueXY(?valueIn: obj) =
            inherit AnimatedWithChildren()
            member __.x with get(): AnimatedValue = jsNative and set(v: AnimatedValue): unit = jsNative
            member __.y with get(): AnimatedValue = jsNative and set(v: AnimatedValue): unit = jsNative
            member __.setValue(value: obj): unit = jsNative
            member __.setOffset(offset: obj): unit = jsNative
            member __.flattenOffset(): unit = jsNative
            member __.stopAnimation(?callback: (float -> unit)): unit = jsNative
            member __.addListener(callback: ValueXYListenerCallback): string = jsNative
            member __.removeListener(id: string): unit = jsNative
            member __.getLayout(): obj = jsNative
            member __.getTranslateTransform(): ResizeArray<obj> = jsNative

        and EndResult =
            obj

        and EndCallback =
            (EndResult -> unit)

        and CompositeAnimation =
            abstract start: (EndCallback -> unit) with get, set
            abstract stop: (unit -> unit) with get, set

        and AnimationConfig =
            abstract isInteraction: bool option with get, set
            abstract useNativeDriver: bool option with get, set

        and DecayAnimationConfig =
            inherit AnimationConfig
            abstract velocity: U2<float, obj> with get, set
            abstract deceleration: float option with get, set

        and TimingAnimationConfig =
            inherit AnimationConfig
            abstract toValue: U4<float, AnimatedValue, obj, AnimatedValueXY> with get, set
            abstract easing: (float -> float) option with get, set
            abstract duration: float option with get, set
            abstract delay: float option with get, set

        and SpringAnimationConfig =
            inherit AnimationConfig
            abstract toValue: U4<float, AnimatedValue, obj, AnimatedValueXY> with get, set
            abstract overshootClamping: bool option with get, set
            abstract restDisplacementThreshold: float option with get, set
            abstract restSpeedThreshold: float option with get, set
            abstract velocity: U2<float, obj> option with get, set
            abstract bounciness: float option with get, set
            abstract speed: float option with get, set
            abstract tension: float option with get, set
            abstract friction: float option with get, set

        and [<Import("Animated.AnimatedAddition","react-native")>] AnimatedAddition() =
            inherit AnimatedInterpolation()


        and [<Import("Animated.AnimatedMultiplication","react-native")>] AnimatedMultiplication() =
            inherit AnimatedInterpolation()


        and [<Import("Animated.AnimatedModulo","react-native")>] AnimatedModulo() =
            inherit AnimatedInterpolation()


        and ParallelConfig =
            obj

        and Mapping =
            U2<obj, AnimatedValue>

        and EventConfig =
            abstract listener: Function option with get, set

        type [<Import("Animated","react-native")>] Globals =
            static member timing with get(): (U2<AnimatedValue, AnimatedValueXY> -> TimingAnimationConfig -> CompositeAnimation) = jsNative and set(v: (U2<AnimatedValue, AnimatedValueXY> -> TimingAnimationConfig -> CompositeAnimation)): unit = jsNative
            static member spring with get(): (U2<AnimatedValue, AnimatedValueXY> -> SpringAnimationConfig -> CompositeAnimation) = jsNative and set(v: (U2<AnimatedValue, AnimatedValueXY> -> SpringAnimationConfig -> CompositeAnimation)): unit = jsNative
            static member ``parallel`` with get(): (ResizeArray<CompositeAnimation> -> ParallelConfig -> CompositeAnimation) = jsNative and set(v: (ResizeArray<CompositeAnimation> -> ParallelConfig -> CompositeAnimation)): unit = jsNative
            static member ``event`` with get(): (ResizeArray<Mapping> -> EventConfig -> (obj -> unit)) = jsNative and set(v: (ResizeArray<Mapping> -> EventConfig -> (obj -> unit))): unit = jsNative
            static member View with get(): obj = jsNative and set(v: obj): unit = jsNative
            static member Image with get(): obj = jsNative and set(v: obj): unit = jsNative
            static member Text with get(): obj = jsNative and set(v: obj): unit = jsNative
            static member decay(value: U2<AnimatedValue, AnimatedValueXY>, config: DecayAnimationConfig): CompositeAnimation = jsNative
            static member add(a: Animated, b: Animated): AnimatedAddition = jsNative
            static member multiply(a: Animated, b: Animated): AnimatedMultiplication = jsNative
            static member modulo(a: Animated, modulus: float): AnimatedModulo = jsNative
            static member delay(time: float): CompositeAnimation = jsNative
            static member sequence(animations: ResizeArray<CompositeAnimation>): CompositeAnimation = jsNative
            static member stagger(time: float, animations: ResizeArray<CompositeAnimation>): CompositeAnimation = jsNative


    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module NavigatorStatic =
        type Route = obj // added after import
        type ViewStyle = obj // added after import

        type NavState =
            abstract routeStack: ResizeArray<Route> with get, set
            abstract idStack: ResizeArray<float> with get, set
            abstract presentedIndex: float with get, set

        and NavigationBarStyle =
            interface end

        and NavigationBarRouteMapper =
            abstract Title: (Route -> Navigator -> float -> NavState -> React.ReactElement) with get, set
            abstract LeftButton: (Route -> Navigator -> float -> NavState -> React.ReactElement) with get, set
            abstract RightButton: (Route -> Navigator -> float -> NavState -> React.ReactElement) with get, set

        and NavigationBarProperties =
            inherit React.Props<NavigationBarStatic>
            abstract navigator: Navigator option with get, set
            abstract routeMapper: NavigationBarRouteMapper option with get, set
            abstract navState: NavState option with get, set
            abstract style: ViewStyle option with get, set

        and NavigationBarStatic =
            inherit React.ComponentClass<NavigationBarProperties>
            abstract Styles: NavigationBarStyle with get, set

        and NavigationBar =
            NavigationBarStatic

        and BreadcrumbNavigationBarStyle =
            interface end

        and BreadcrumbNavigationBarRouteMapper =
            abstract rightContentForRoute: (Route -> Navigator -> React.ReactElement) with get, set
            abstract titleContentForRoute: (Route -> Navigator -> React.ReactElement) with get, set
            abstract iconForRoute: (Route -> Navigator -> React.ReactElement) with get, set
            abstract separatorForRoute: (Route -> Navigator -> React.ReactElement) with get, set

        and BreadcrumbNavigationBarProperties =
            inherit React.Props<BreadcrumbNavigationBarStatic>
            abstract navigator: Navigator option with get, set
            abstract routeMapper: BreadcrumbNavigationBarRouteMapper option with get, set
            abstract navState: NavState option with get, set
            abstract style: ViewStyle option with get, set

        and BreadcrumbNavigationBarStatic =
            inherit React.ComponentClass<BreadcrumbNavigationBarProperties>
            abstract Styles: BreadcrumbNavigationBarStyle with get, set

        and BreadcrumbNavigationBar =
            BreadcrumbNavigationBarStatic

        type [<Import("NavigatorStatic","react-native")>] Globals =
            static member NavigationBar with get(): NavigationBarStatic = jsNative and set(v: NavigationBarStatic): unit = jsNative
            static member BreadcrumbNavigationBar with get(): BreadcrumbNavigationBarStatic = jsNative and set(v: BreadcrumbNavigationBarStatic): unit = jsNative


    type NativeComponent =
        abstract refs: obj with get, set
        abstract ``measure``: callback: NativeMethodsMixin.MeasureOnSuccessCallback -> unit
        abstract measureInWindow: callback: NativeMethodsMixin.MeasureInWindowOnSuccessCallback -> unit
        abstract measureLayout: relativeToNativeNode: float * onSuccess: NativeMethodsMixin.MeasureLayoutOnSuccessCallback * onFail: (unit -> unit)
        abstract setNativeProps: nativeProps: obj -> unit
        abstract focus: unit -> unit
        abstract blur: unit -> unit

    and ReactClass<'D, 'P, 'S> =
        interface end

    and Runnable =
        (obj -> unit)

    and NativeSyntheticEvent<'T> =
        abstract bubbles: bool with get, set
        abstract cancelable: bool with get, set
        abstract currentTarget: EventTarget with get, set
        abstract defaultPrevented: bool with get, set
        abstract eventPhase: float with get, set
        abstract isTrusted: bool with get, set
        abstract nativeEvent: 'T with get, set
        abstract target: EventTarget with get, set
        abstract timeStamp: DateTime with get, set
        abstract ``type``: string with get, set
        abstract preventDefault: unit -> unit
        abstract stopPropagation: unit -> unit

    and NativeTouchEvent =
        abstract changedTouches: ResizeArray<NativeTouchEvent> with get, set
        abstract identifier: string with get, set
        abstract locationX: float with get, set
        abstract locationY: float with get, set
        abstract pageX: float with get, set
        abstract pageY: float with get, set
        abstract target: string with get, set
        abstract timestamp: float with get, set
        abstract touches: ResizeArray<NativeTouchEvent> with get, set

    and GestureResponderEvent =
        inherit NativeSyntheticEvent<NativeTouchEvent>


    and PointProperties =
        abstract x: float with get, set
        abstract y: float with get, set

    and Insets =
        abstract top: float option with get, set
        abstract left: float option with get, set
        abstract bottom: float option with get, set
        abstract right: float option with get, set

    and Touchable =
        abstract onTouchStart: (GestureResponderEvent -> unit) option with get, set
        abstract onTouchMove: (GestureResponderEvent -> unit) option with get, set
        abstract onTouchEnd: (GestureResponderEvent -> unit) option with get, set
        abstract onTouchCancel: (GestureResponderEvent -> unit) option with get, set
        abstract onTouchEndCapture: (GestureResponderEvent -> unit) option with get, set

    and AppConfig =
        obj

    and [<Import("AppRegistry","react-native")>] AppRegistry() =
        static member registerConfig(config: ResizeArray<AppConfig>): unit = jsNative
        static member registerComponent(appKey: string, getComponentFunc: (unit -> React.ComponentClass<obj>)): string = jsNative
        static member registerRunnable(appKey: string, func: Runnable): string = jsNative
        static member getAppKeys(): ResizeArray<string> = jsNative
        static member unmountApplicationComponentAtRootTag(rootTag: float): unit = jsNative
        static member runApplication(appKey: string, appParameters: obj): unit = jsNative

    and LayoutAnimationTypes =
        abstract spring: string with get, set
        abstract linear: string with get, set
        abstract easeInEaseOut: string with get, set
        abstract easeIn: string with get, set
        abstract easeOut: string with get, set

    and LayoutAnimationProperties =
        abstract opacity: string with get, set
        abstract scaleXY: string with get, set

    and LayoutAnimationAnim =
        abstract duration: float option with get, set
        abstract delay: float option with get, set
        abstract springDamping: float option with get, set
        abstract initialVelocity: float option with get, set
        abstract ``type``: string option with get, set
        abstract property: string option with get, set

    and LayoutAnimationConfig =
        abstract duration: float with get, set
        abstract create: LayoutAnimationAnim option with get, set
        abstract update: LayoutAnimationAnim option with get, set
        abstract delete: LayoutAnimationAnim option with get, set

    and LayoutAnimationStatic =
        abstract configureNext: (LayoutAnimationConfig -> (unit -> unit) -> (obj -> unit) -> unit) with get, set
        abstract create: (float -> string -> string -> LayoutAnimationConfig) with get, set
        abstract Types: LayoutAnimationTypes with get, set
        abstract Properties: LayoutAnimationProperties with get, set
        abstract configChecker: (obj -> string -> string -> unit) with get, set
        abstract Presets: obj with get, set

    and [<StringEnum>] FlexAlignType =
        | [<CompiledName("flex-start")>] FlexStart
        | [<CompiledName("flex-end")>] FlexEnd
        | Center
        | Stretch
        | Baseline

    and [<StringEnum>] FlexAlignSelfType =
        | Auto
        | [<CompiledName("flex-start")>] FlexStart
        | [<CompiledName("flex-end")>] FlexEnd
        | Center
        | Stretch
        | Baseline

    and [<StringEnum>] FlexJustifyType =
        | [<CompiledName("flex-start")>] FlexStart
        | [<CompiledName("flex-end")>] FlexEnd
        | Center
        | [<CompiledName("space-between")>] SpaceBetween
        | [<CompiledName("space-around")>] SpaceAround
        | [<CompiledName("space-evenly")>] SpaceEvenly

    and [<StringEnum>] FlexAlignContentType =
        | [<CompiledName("flex-start")>] FlexStart
        | [<CompiledName("flex-end")>] FlexEnd
        | Center
        | Stretch
        | [<CompiledName("space-between")>] SpaceBetween
        | [<CompiledName("space-around")>] SpaceAround

    and [<StringEnum; RequireQualifiedAccess>] FlexDisplayType =
        | None | Flex

    and [<StringEnum>] FlexDirectionType =
        | Row
        | [<CompiledName("row-reverse")>] RowReverse
        | Column
        | [<CompiledName("column-reverse")>] ColumnReverse

    and [<StringEnum>] FlexWrapType =
        | Wrap | Nowrap

    and [<StringEnum>] FlexOverflowType =
        | Visible | Hidden | Scroll

    and [<StringEnum>] FlexPositionType =
        | Absolute | Relative

    and FlexStyle =
        abstract alignContent: FlexAlignContentType option with get, set
        abstract alignItems: FlexAlignType option with get, set
        abstract alignSelf: FlexAlignSelfType option with get, set
        abstract aspectRatio: float option with get, set
        abstract borderBottomWidth: float option with get, set
        abstract borderEndWidth: float option with get, set
        abstract borderLeftWidth: float option with get, set
        abstract borderRightWidth: float option with get, set
        abstract borderStartWidth: float option with get, set
        abstract borderTopWidth: float option with get, set
        abstract borderWidth: float option with get, set
        abstract bottom: U2<string, float> option with get, set
        abstract display: FlexDisplayType option with get, set
        abstract ``end``: U2<string, float> option with get, set
        abstract flex: float option with get, set
        abstract flexBasis: U2<string, float> option with get, set
        abstract flexDirection: FlexDirectionType option with get, set
        abstract flexGrow: float option with get, set
        abstract flexShrink: float option with get, set
        abstract flexWrap: FlexWrapType option with get, set
        abstract height: U2<string, float> option with get, set
        abstract justifyContent: FlexJustifyType option with get, set
        abstract left: U2<string, float> option with get, set
        abstract margin: U2<string, float> option with get, set
        abstract marginBottom: U2<string, float> option with get, set
        abstract marginEnd: U2<string, float> option with get, set
        abstract marginHorizontal: U2<string, float> option with get, set
        abstract marginLeft: U2<string, float> option with get, set
        abstract marginRight: U2<string, float> option with get, set
        abstract marginStart: U2<string, float> option with get, set
        abstract marginTop: U2<string, float> option with get, set
        abstract marginVertical: U2<string, float> option with get, set
        abstract maxHeight: U2<string, float> option with get, set
        abstract maxWidth: U2<string, float> option with get, set
        abstract minHeight: U2<string, float> option with get, set
        abstract minWidth: U2<string, float> option with get, set
        abstract overflow: FlexOverflowType option with get, set
        abstract padding: U2<string, float> option with get, set
        abstract paddingBottom: U2<string, float> option with get, set
        abstract paddingEnd: U2<string, float> option with get, set
        abstract paddingHorizontal: U2<string, float> option with get, set
        abstract paddingLeft: U2<string, float> option with get, set
        abstract paddingRight: U2<string, float> option with get, set
        abstract paddingStart: U2<string, float> option with get, set
        abstract paddingTop: U2<string, float> option with get, set
        abstract paddingVertical: U2<string, float> option with get, set
        abstract position: FlexPositionType option with get, set
        abstract right: U2<string, float> option with get, set
        abstract start: U2<string, float> option with get, set
        abstract top: U2<string, float> option with get, set
        abstract width: U2<string, float> option with get, set
        abstract zIndex: float option with get, set

    and ShadowPropTypesIOSStatic =
        abstract shadowColor: string with get, set
        abstract shadowOffset: obj with get, set
        abstract shadowOpacity: float with get, set
        abstract shadowRadius: float with get, set

    and GetCurrentPositionOptions =
        obj

    and WatchPositionOptions =
        obj

    and PositionCoordinates =
        abstract latitude: float with get
        abstract longitude: float with get
        abstract altitude: float option with get
        abstract accuracy: float with get
        abstract heading: float option with get
        abstract speed: float option with get

    and GeolocationReturnType =
        abstract coords: PositionCoordinates with get
        abstract timestamp: int64 with get

    and TransformsStyle =
        abstract transform: obj * obj * obj * obj * obj * obj * obj * obj * obj * obj * obj * obj option with get, set
        abstract transformMatrix: ResizeArray<float> option with get, set
        abstract rotation: float option with get, set
        abstract scaleX: float option with get, set
        abstract scaleY: float option with get, set
        abstract translateX: float option with get, set
        abstract translateY: float option with get, set

    and StyleSheetProperties =
        abstract hairlineWidth: float with get, set
        abstract flatten: style: 'T -> 'T

    and LayoutRectangle =
        abstract x: float with get, set
        abstract y: float with get, set
        abstract width: float with get, set
        abstract height: float with get, set

    and LayoutChangeEvent =
        abstract nativeEvent: obj with get, set

    and TextStyleIOS =
        inherit ViewStyle
        abstract letterSpacing: float option with get, set
        abstract textDecorationColor: string option with get, set
        abstract textDecorationStyle: (* TODO StringEnum solid | double | dotted | dashed *) string option with get, set
        abstract writingDirection: (* TODO StringEnum auto | ltr | rtl *) string option with get, set

    and TextStyleAndroid =
        inherit ViewStyle
        abstract textAlignVertical: (* TODO StringEnum auto | top | bottom | center *) string option with get, set

    and TextStyle =
        inherit TextStyleIOS
        inherit TextStyleAndroid
        inherit ViewStyle
        abstract color: string option with get, set
        abstract fontFamily: string option with get, set
        abstract fontSize: float option with get, set
        abstract fontStyle: (* TODO StringEnum normal | italic *) string option with get, set
        abstract fontWeight: (* TODO StringEnum normal | bold | 100 | 200 | 300 | 400 | 500 | 600 | 700 | 800 | 900 *) string option with get, set
        abstract letterSpacing: float option with get, set
        abstract lineHeight: float option with get, set
        abstract textAlign: (* TODO StringEnum auto | left | right | center *) string option with get, set
        abstract textDecorationLine: (* TODO StringEnum none | underline | line-through | underline line-through *) string option with get, set
        abstract textDecorationStyle: (* TODO StringEnum solid | double | dotted | dashed *) string option with get, set
        abstract textDecorationColor: string option with get, set
        abstract textShadowColor: string option with get, set
        abstract textShadowOffset: obj option with get, set
        abstract textShadowRadius: float option with get, set
        abstract testID: string option with get, set

    and TextPropertiesIOS =
        abstract allowFontScaling: bool with get, set
        abstract suppressHighlighting: bool option with get, set

    and TextProperties =
        inherit React.Props<TextProperties>
        abstract allowFontScaling: bool option with get, set
        abstract lineBreakMode: (* TODO StringEnum head | middle | tail | clip *) string option with get, set
        abstract numberOfLines: float option with get, set
        abstract onLayout: (LayoutChangeEvent -> unit) option with get, set
        abstract onPress: (unit -> unit) option with get, set
        abstract style: TextStyle option with get, set
        abstract testID: string option with get, set

    and TextStatic =
        inherit React.ComponentClass<TextProperties>


    and TextInputIOSProperties =
        abstract clearButtonMode: string option with get, set
        abstract clearTextOnFocus: bool option with get, set
        abstract enablesReturnKeyAutomatically: bool option with get, set
        abstract onKeyPress: (obj -> unit) option with get, set
        abstract selectionState: obj option with get, set

    and TextInputAndroidProperties =
        abstract numberOfLines: float option with get, set
        abstract returnKeyLabel: string option with get, set
        abstract textAlign: string option with get, set
        abstract textAlignVertical: string option with get, set
        abstract underlineColorAndroid: string option with get, set

    and TextInputProperties =
        inherit TextInputIOSProperties
        inherit TextInputAndroidProperties
        inherit React.Props<TextInputStatic>
        abstract autoCapitalize: (* TODO StringEnum none | sentences | words | characters *) string option with get, set
        abstract autoCorrect: bool option with get, set
        abstract autoFocus: bool option with get, set
        abstract blurOnSubmit: bool option with get, set
        abstract defaultValue: string option with get, set
        abstract editable: bool option with get, set
        abstract keyboardType: (* TODO StringEnum default | email-address | numeric | phone-pad | ascii-capable | numbers-and-punctuation | url | number-pad | name-phone-pad | decimal-pad | twitter | web-search *) string option with get, set
        abstract maxLength: float option with get, set
        abstract multiline: bool option with get, set
        abstract onBlur: (obj -> unit) option with get, set
        abstract onChange: (obj -> unit) option with get, set
        abstract onChangeText: (string -> unit) option with get, set
        abstract onEndEditing: (obj -> unit) option with get, set
        abstract onFocus: (obj -> unit) option with get, set
        abstract onLayout: (obj -> unit) option with get, set
        abstract onSelectionChange: (obj -> unit) option with get, set
        abstract onSubmitEditing: (obj -> unit) option with get, set
        abstract password: bool option with get, set
        abstract placeholder: string option with get, set
        abstract placeholderTextColor: string option with get, set
        abstract returnKeyType: (* TODO StringEnum default | go | google | join | next | route | search | send | yahoo | done | emergency-call *) string option with get, set
        abstract secureTextEntry: bool option with get, set
        abstract selectTextOnFocus: bool option with get, set
        abstract selectionColor: string option with get, set
        abstract style: TextStyle option with get, set
        abstract testID: string option with get, set
        abstract value: string option with get, set

    and TextInputStatic =
        inherit NativeComponent
        inherit React.ComponentClass<TextInputProperties>
        abstract isFocused: (unit -> bool) with get, set
        abstract clear: (unit -> unit) with get, set
        abstract blur: (unit -> unit) with get, set
        abstract focus: (unit -> unit) with get, set

    and ToolbarAndroidAction =
        obj

    and ToolbarAndroidProperties =
        inherit ViewProperties
        inherit React.Props<ToolbarAndroidStatic>
        abstract actions: ResizeArray<ToolbarAndroidAction> option with get, set
        abstract contentInsetEnd: float option with get, set
        abstract contentInsetStart: float option with get, set
        abstract logo: obj option with get, set
        abstract navIcon: obj option with get, set
        abstract onActionSelected: (float -> unit) option with get, set
        abstract onIconClicked: (unit -> unit) option with get, set
        abstract overflowIcon: obj option with get, set
        abstract rtl: bool option with get, set
        abstract subtitle: string option with get, set
        abstract subtitleColor: string option with get, set
        abstract testID: string option with get, set
        abstract title: string option with get, set
        abstract titleColor: string option with get, set
        abstract ref: Ref<ToolbarAndroidStatic> option with get, set

    and ToolbarAndroidStatic =
        inherit React.ComponentClass<ToolbarAndroidProperties>


    and GestureResponderHandlers =
        abstract onStartShouldSetResponder: (GestureResponderEvent -> bool) option with get, set
        abstract onMoveShouldSetResponder: (GestureResponderEvent -> bool) option with get, set
        abstract onResponderGrant: (GestureResponderEvent -> unit) option with get, set
        abstract onResponderReject: (GestureResponderEvent -> unit) option with get, set
        abstract onResponderMove: (GestureResponderEvent -> unit) option with get, set
        abstract onResponderRelease: (GestureResponderEvent -> unit) option with get, set
        abstract onResponderTerminationRequest: (GestureResponderEvent -> bool) option with get, set
        abstract onResponderTerminate: (GestureResponderEvent -> unit) option with get, set
        abstract onStartShouldSetResponderCapture: (GestureResponderEvent -> bool) option with get, set
        abstract onMoveShouldSetResponderCapture: (GestureResponderEvent -> unit) option with get, set

    and [<StringEnum>] ViewBackfaceVisibilityType =
        | Visible | Hidden

    and [<StringEnum>] ViewBorderStyleType =
        | Solid | Dotted | Dashed

    and ViewStyle =
        inherit FlexStyle
        inherit TransformsStyle
        abstract backfaceVisibility: ViewBackfaceVisibilityType option with get, set
        abstract backgroundColor: string option with get, set
        abstract borderBottomColor: string option with get, set
        abstract borderBottomEndRadius: float option with get, set
        abstract borderBottomLeftRadius: float option with get, set
        abstract borderBottomRightRadius: float option with get, set
        abstract borderBottomStartRadius: float option with get, set
        abstract borderBottomWidth: float option with get, set
        abstract borderColor: string option with get, set
        abstract borderEndColor: string option with get, set
        abstract borderLeftColor: string option with get, set
        abstract borderRadius: float option with get, set
        abstract borderRightColor: string option with get, set
        abstract borderRightWidth: float option with get, set
        abstract borderStartColor: string option with get, set
        abstract borderStyle: ViewBorderStyleType option with get, set
        abstract borderTopColor: string option with get, set
        abstract borderTopEndRadius: float option with get, set
        abstract borderTopLeftRadius: float option with get, set
        abstract borderTopRightRadius: float option with get, set
        abstract borderTopStartRadius: float option with get, set
        abstract borderTopWidth: float option with get, set
        abstract borderWidth: float option with get, set
        abstract opacity: float option with get, set
        abstract shadowColor: string option with get, set
        abstract shadowOffset: obj option with get, set
        abstract shadowOpacity: float option with get, set
        abstract shadowRadius: float option with get, set
        abstract elevation: float option with get, set
        abstract testID: string option with get, set

    and ViewPropertiesIOS =
        abstract accessibilityTraits: U2<string, ResizeArray<string>> option with get, set
        abstract shouldRasterizeIOS: bool option with get, set

    and ViewPropertiesAndroid =
        abstract accessibilityComponentType: string option with get, set
        abstract accessibilityLiveRegion: string option with get, set
        abstract collapsable: bool option with get, set
        abstract importantForAccessibility: string option with get, set
        abstract needsOffscreenAlphaCompositing: bool option with get, set
        abstract renderToHardwareTextureAndroid: bool option with get, set

    and [<StringEnum; RequireQualifiedAccess>] PointerEvents =
        | [<CompiledName("box-none")>] BoxNone
        | None
        | [<CompiledName("box-only")>] BoxOnly
        | Auto

    and ViewProperties =
        inherit ViewPropertiesAndroid
        inherit ViewPropertiesIOS
        inherit GestureResponderHandlers
        inherit Touchable
//        inherit React.Props<ViewStatic>
        abstract accessibilityLabel: string option with get, set
        abstract accessible: bool option with get, set
        abstract hitSlop: obj option with get, set
        abstract onAcccessibilityTap: (unit -> unit) option with get, set
        abstract onLayout: (LayoutChangeEvent -> unit) option with get, set
        abstract onMagicTap: (unit -> unit) option with get, set
        abstract pointerEvents: PointerEvents option with get, set
        abstract removeClippedSubviews: bool option with get, set
        abstract style: ViewStyle option with get, set
        abstract testID: string option with get, set

    and ViewStatic =
        inherit NativeComponent
        inherit React.ComponentClass<ViewProperties>


    and ViewPagerAndroidOnPageScrollEventData =
        abstract position: float with get, set
        abstract offset: float with get, set

    and ViewPagerAndroidOnPageSelectedEventData =
        abstract position: float with get, set

    and ViewPagerAndroidProperties =
        inherit ViewProperties
        abstract initialPage: float option with get, set
        abstract scrollEnabled: bool option with get, set
        abstract onPageScroll: (NativeSyntheticEvent<ViewPagerAndroidOnPageScrollEventData> -> unit) option with get, set
        abstract onPageSelected: (NativeSyntheticEvent<ViewPagerAndroidOnPageSelectedEventData> -> unit) option with get, set
        abstract onPageScrollStateChanged: ((* TODO StringEnum Idle | Dragging | Settling *) string -> unit) option with get, set
        abstract keyboardDismissMode: (* TODO StringEnum none | on-drag *) string option with get, set
        abstract pageMargin: float option with get, set

    and ViewPagerAndroidStatic =
        inherit NativeComponent
        inherit React.ComponentClass<ViewPagerAndroidProperties>
        abstract setPage: (float -> unit) with get, set
        abstract setPageWithoutAnimation: (float -> unit) with get, set

    and KeyboardAvoidingViewStatic =
        inherit React.ComponentClass<KeyboardAvoidingViewProps>


    and KeyboardAvoidingViewProps =
        inherit ViewProperties
        inherit React.Props<KeyboardAvoidingViewStatic>
        abstract behavior: (* TODO StringEnum height | position | padding *) string option with get, set
        abstract keyboardVerticalOffset: float with get, set
        abstract ref: Ref<obj> option with get, set

    and NavState =
        abstract url: string option with get, set
        abstract title: string option with get, set
        abstract loading: bool option with get, set
        abstract canGoBack: bool option with get, set
        abstract canGoForward: bool option with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: key: string -> obj with get, set

    and WebViewPropertiesAndroid =
        abstract javaScriptEnabled: bool option with get, set
        abstract domStorageEnabled: bool option with get, set

    and WebViewIOSLoadRequestEvent =
        abstract target: float with get, set
        abstract canGoBack: bool with get, set
        abstract lockIdentifier: float with get, set
        abstract loading: bool with get, set
        abstract title: string with get, set
        abstract canGoForward: bool with get, set
        abstract navigationType: (* TODO StringEnum other | click *) string with get, set
        abstract url: string with get, set

    and WebViewPropertiesIOS =
        abstract allowsInlineMediaPlayback: bool option with get, set
        abstract bounces: bool option with get, set
        abstract decelerationRate: (* TODO StringEnum normal | fast |  *) string option with get, set
        abstract onShouldStartLoadWithRequest: (WebViewIOSLoadRequestEvent -> bool) option with get, set
        abstract scrollEnabled: bool option with get, set

    and WebViewUriSource =
        abstract uri: string option with get, set
        abstract ``method``: string option with get, set
        abstract headers: obj option with get, set
        abstract body: string option with get, set

    and WebViewHtmlSource =
        abstract html: string with get, set
        abstract baseUrl: string option with get, set

    and WebViewProperties =
        inherit ViewProperties
        inherit WebViewPropertiesAndroid
        inherit WebViewPropertiesIOS
        inherit React.Props<WebViewStatic>
        abstract automaticallyAdjustContentInsets: bool option with get, set
        abstract bounces: bool option with get, set
        abstract contentInset: Insets option with get, set
        abstract html: string option with get, set
        abstract injectedJavaScript: string option with get, set
        abstract onError: (NavState -> unit) option with get, set
        abstract onLoad: (NavState -> unit) option with get, set
        abstract onLoadEnd: (NavState -> unit) option with get, set
        abstract onLoadStart: (NavState -> unit) option with get, set
        abstract onNavigationStateChange: (NavState -> unit) option with get, set
        abstract onShouldStartLoadWithRequest: (obj -> bool) option with get, set
        abstract renderError: (unit ->React.ReactElement) option with get, set
        abstract renderLoading: (unit ->React.ReactElement) option with get, set
        abstract scrollEnabled: bool option with get, set
        abstract startInLoadingState: bool option with get, set
        abstract style: ViewStyle option with get, set
        abstract url: string option with get, set
        abstract source: U3<WebViewUriSource, WebViewHtmlSource, float> option with get, set
        abstract mediaPlaybackRequiresUserAction: bool option with get, set
        abstract scalesPageToFit: bool option with get, set
        abstract ref: Ref<obj> option with get, set

    and WebViewStatic =
        inherit React.ComponentClass<WebViewProperties>
        abstract goBack: (unit -> unit) with get, set
        abstract goForward: (unit -> unit) with get, set
        abstract reload: (unit -> unit) with get, set
        abstract getWebViewHandle: (unit -> obj) with get, set

    and NativeSegmentedControlIOSChangeEvent =
        abstract value: string with get, set
        abstract selectedSegmentIndex: int with get, set
        abstract target: float with get, set

    and SegmentedControlIOSProperties =
        inherit ViewProperties
        inherit React.Props<SegmentedControlIOSStatic>
        abstract enabled: bool option with get, set
        abstract momentary: bool option with get, set
        abstract onChange: (NativeSyntheticEvent<NativeSegmentedControlIOSChangeEvent> -> unit) option with get, set
        abstract onValueChange: (string -> unit) option with get, set
        abstract selectedIndex: float option with get, set
        abstract tintColor: string option with get, set
        abstract values: ResizeArray<string> option with get, set
        abstract ref: Ref<SegmentedControlIOSStatic> option with get, set

    and SegmentedControlIOSStatic =
        inherit React.ComponentClass<SegmentedControlIOSProperties>


    and NavigatorIOSProperties =
        inherit React.Props<NavigatorIOSStatic>
        abstract barTintColor: string option with get, set
        abstract initialRoute: Route option with get, set
        abstract itemWrapperStyle: ViewStyle option with get, set
        abstract navigationBarHidden: bool option with get, set
        abstract shadowHidden: bool option with get, set
        abstract tintColor: string option with get, set
        abstract titleTextColor: string option with get, set
        abstract translucent: bool option with get, set
        abstract style: ViewStyle option with get, set

    and NavigationIOS =
        abstract push: (Route -> unit) with get, set
        abstract pop: (unit -> unit) with get, set
        abstract popN: (float -> unit) with get, set
        abstract replace: (Route -> unit) with get, set
        abstract replacePrevious: (Route -> unit) with get, set
        abstract replacePreviousAndPop: (Route -> unit) with get, set
        abstract resetTo: (Route -> unit) with get, set
        abstract popToRoute: route: Route -> unit
        abstract popToTop: unit -> unit

    and NavigatorIOSStatic =
        inherit NavigationIOS
        inherit React.ComponentClass<NavigatorIOSProperties>


    and ActivityIndicatorProperties =
        inherit ViewProperties
        inherit React.Props<ActivityIndicatorStatic>
        abstract animating: bool option with get, set
        abstract color: string option with get, set
        abstract hidesWhenStopped: bool option with get, set
        abstract size: (* TODO StringEnum small | large *) string option with get, set
        abstract style: ViewStyle option with get, set
        abstract ref: Ref<ActivityIndicatorStatic> option with get, set

    and ActivityIndicatorStatic =
        inherit React.ComponentClass<ActivityIndicatorProperties>


    and ActivityIndicatorIOSProperties =
        inherit ViewProperties
        inherit React.Props<ActivityIndicatorIOSStatic>
        abstract animating: bool option with get, set
        abstract color: string option with get, set
        abstract hidesWhenStopped: bool option with get, set
        abstract onLayout: (obj -> unit) option with get, set
        abstract size: (* TODO StringEnum small | large *) string option with get, set
        abstract style: ViewStyle option with get, set
        abstract ref: Ref<ActivityIndicatorIOSStatic> option with get, set

    and ActivityIndicatorIOSStatic =
        inherit React.ComponentClass<ActivityIndicatorIOSProperties>


    and DatePickerIOSProperties =
        inherit ViewProperties
        inherit React.Props<DatePickerIOSStatic>
        abstract date: DateTime option with get, set
        abstract maximumDate: DateTime option with get, set
        abstract minimumDate: DateTime option with get, set
        abstract minuteInterval: float option with get, set
        abstract mode: (* TODO StringEnum date | time | datetime *) string option with get, set
        abstract onDateChange: (DateTime -> unit) option with get, set
        abstract timeZoneOffsetInMinutes: float option with get, set
        abstract ref: Ref<DatePickerIOSStatic> option with get, set

    and DatePickerIOSStatic =
        inherit React.ComponentClass<DatePickerIOSProperties>


    and DrawerSlideEvent =
        inherit NativeSyntheticEvent<NativeTouchEvent>

    and DrawerLayoutAndroidPosition =
        interface end

    and DrawerLayoutAndroidPositions =
        abstract member Left: DrawerLayoutAndroidPosition
        abstract member Right: DrawerLayoutAndroidPosition

    and DrawerLayoutAndroidProperties =
        inherit ViewProperties
        inherit React.Props<DrawerLayoutAndroidStatic>
        abstract drawerBackgroundColor: string option with get, set
        abstract drawerLockMode: (* TODO StringEnum unlocked | locked-closed | locked-open *) string option with get, set
        abstract drawerPosition: obj option with get, set
        abstract drawerWidth: float option with get, set
        abstract keyboardDismissMode: (* TODO StringEnum none | on-drag *) string option with get, set
        abstract onDrawerClose: (unit -> unit) option with get, set
        abstract onDrawerOpen: (unit -> unit) option with get, set
        abstract onDrawerSlide: (DrawerSlideEvent -> unit) option with get, set
        abstract onDrawerStateChanged: ((* TODO StringEnum Idle | Dragging | Settling *) string -> unit) option with get, set
        abstract renderNavigationView: (unit -> JSX.Element) option with get, set
        abstract statusBarBackgroundColor: obj option with get, set
        abstract ref: Ref<obj> option with get, set

    and DrawerLayoutAndroidStatic =
        inherit React.ComponentClass<DrawerLayoutAndroidProperties>
        abstract positions: obj with get, set
        abstract openDrawer: (unit -> unit)
        abstract closeDrawer: (unit -> unit)

    and PickerIOSItemProperties =
        inherit React.Props<PickerIOSItemStatic>
        abstract value: U2<string, float> option with get, set
        abstract label: string option with get, set

    and PickerIOSItemStatic =
        inherit React.ComponentClass<PickerIOSItemProperties>


    and PickerItemProperties =
        inherit React.Props<PickerItemStatic>
        abstract label: string with get, set
        abstract value: obj option with get, set
        abstract color: string option with get, set
        abstract testID: string option with get, set

    and PickerItemStatic =
        inherit React.ComponentClass<PickerItemProperties>


    and PickerPropertiesIOS =
        inherit ViewProperties
        inherit React.Props<PickerStatic>
        abstract itemStyle: ViewStyle option with get, set
        abstract ref: Ref<obj> option with get, set

    and PickerPropertiesAndroid =
        inherit ViewProperties
        inherit React.Props<PickerStatic>
        abstract enabled: bool option with get, set
        abstract mode: (* TODO StringEnum dialog | dropdown *) string option with get, set
        abstract prompt: string option with get, set
        abstract ref: Ref<obj> option with get, set

    and PickerProperties =
        inherit PickerPropertiesIOS
        inherit PickerPropertiesAndroid
        inherit React.Props<PickerStatic>
        abstract onValueChange: (obj -> float -> unit) option with get, set
        abstract selectedValue: obj option with get, set
        abstract style: ViewStyle option with get, set
        abstract testId: string option with get, set
        abstract ref: Ref<PickerStatic> option with get, set

    and PickerStatic =
        inherit React.ComponentClass<PickerProperties>
        abstract Item: PickerItemStatic with get, set

    and PickerIOSProperties =
        inherit React.Props<PickerIOSStatic>
        abstract itemStyle: ViewStyle option with get, set

    and PickerIOSStatic =
        inherit React.ComponentClass<PickerIOSProperties>
        abstract Item: PickerIOSItemStatic with get, set

    and ProgressBarAndroidProperties =
        inherit ViewProperties
        inherit React.Props<ProgressBarAndroidStatic>
        abstract style: ViewStyle option with get, set
        abstract styleAttr: (* TODO StringEnum Horizontal | Normal | Small | Large | Inverse | SmallInverse | LargeInverse *) string option with get, set
        abstract indeterminate: bool option with get, set
        abstract progress: float option with get, set
        abstract color: string option with get, set
        abstract testID: string option with get, set
        abstract ref: Ref<ProgressBarAndroidStatic> option with get, set

    and ProgressBarAndroidStatic =
        inherit React.ComponentClass<ProgressBarAndroidProperties>


    and ProgressViewIOSProperties =
        inherit ViewProperties
        inherit React.Props<ProgressViewIOSStatic>
        abstract style: ViewStyle option with get, set
        abstract progressViewStyle: (* TODO StringEnum default | bar *) string option with get, set
        abstract progress: float option with get, set
        abstract progressTintColor: string option with get, set
        abstract trackTintColor: string option with get, set
        abstract progressImage: obj option with get, set
        abstract trackImage: obj option with get, set
        abstract ref: Ref<ProgressViewIOSStatic> option with get, set

    and ProgressViewIOSStatic =
        inherit React.ComponentClass<ProgressViewIOSProperties>


    and RefreshControlPropertiesIOS =
        inherit ViewProperties
        inherit React.Props<RefreshControlStatic>
        abstract tintColor: string option with get, set
        abstract title: string option with get, set
        abstract titleColor: string option with get, set
        abstract ref: Ref<obj> option with get, set

    and RefreshControlPropertiesAndroid =
        inherit ViewProperties
        inherit React.Props<RefreshControlStatic>
        abstract colors: ResizeArray<string> option with get, set
        abstract enabled: bool option with get, set
        abstract progressBackgroundColor: string option with get, set
        abstract size: float option with get, set
        abstract progressViewOffset: float option with get, set
        abstract ref: Ref<obj> option with get, set

    and RefreshControlProperties =
        inherit RefreshControlPropertiesIOS
        inherit RefreshControlPropertiesAndroid
        inherit React.Props<RefreshControl>
        abstract onRefresh: (unit -> unit) option with get, set
        abstract refreshing: bool option with get, set
        abstract ref: Ref<RefreshControlStatic> option with get, set

    and RefreshControlStatic =
        inherit React.ComponentClass<RefreshControlProperties>
        abstract SIZE: obj with get, set

    and SliderIOSProperties =
        abstract trackImage: obj option with get, set
        abstract minimumTrackImage: obj option with get, set
        abstract maximumTrackImage: obj option with get, set
        abstract thumbImage: obj option with get, set

    and SliderAndroidProperties =
        abstract thumbTintColor: string option with get, set

    and SliderProperties =
        inherit ViewProperties
        inherit SliderIOSProperties
        inherit SliderAndroidProperties
        inherit React.Props<SliderStatic>
        abstract style: ViewStyle option with get, set
        abstract value: float option with get, set
        abstract step: float option with get, set
        abstract minimumValue: float option with get, set
        abstract maximumValue: float option with get, set
        abstract minimumTrackTintColor: string option with get, set
        abstract maximumTrackTintColor: string option with get, set
        abstract disabled: bool option with get, set
        abstract onValueChange: (float -> unit) option with get, set
        abstract onSlidingComplete: (float -> unit) option with get, set
        abstract testID: string option with get, set
        abstract ref: Ref<SliderStatic> option with get, set

    and SliderStatic =
        inherit React.ComponentClass<SliderProperties>

    and ImageResizeModeStatic =
        abstract contain: string with get, set
        abstract cover: string with get, set
        abstract stretch: string with get, set

    and ImageStyle =
        inherit FlexStyle
        inherit TransformsStyle
        abstract resizeMode: string option with get, set
        abstract backfaceVisibility: (* TODO StringEnum visible | hidden *) string option with get, set
        abstract borderBottomLeftRadius: float option with get, set
        abstract borderBottomRightRadius: float option with get, set
        abstract backgroundColor: string option with get, set
        abstract borderColor: string option with get, set
        abstract borderWidth: float option with get, set
        abstract borderRadius: float option with get, set
        abstract borderTopLeftRadius: float option with get, set
        abstract borderTopRightRadius: float option with get, set
        abstract overflow: (* TODO StringEnum visible | hidden *) string option with get, set
        abstract overlayColor: string option with get, set
        abstract tintColor: string option with get, set
        abstract opacity: float option with get, set

    and ImagePropertiesIOS =
        abstract accessibilityLabel: string option with get, set
        abstract accessible: bool option with get, set
        abstract capInsets: Insets option with get, set
        abstract defaultSource: U2<obj, float> option with get, set
        abstract onError: (obj -> unit) option with get, set
        abstract onProgress: (unit -> unit) option with get, set

    and ImageProperties =
        inherit ImagePropertiesIOS
        inherit React.Props<Image>
        abstract blurRadius: float option with get, set
        abstract onLayout: (LayoutChangeEvent -> unit) option with get, set
        abstract onLoad: (unit -> unit) option with get, set
        abstract onLoadEnd: (unit -> unit) option with get, set
        abstract onLoadStart: (unit -> unit) option with get, set
        abstract resizeMode: (* TODO StringEnum cover | contain | stretch *) string option with get, set
        abstract source: U2<obj, string> with get, set
        abstract style: ImageStyle option with get, set
        abstract testID: string option with get, set

    and ImageStatic =
        inherit React.ComponentClass<ImageProperties>
        abstract uri: string with get, set
        abstract resizeMode: ImageResizeModeStatic with get, set
        abstract getSize: uri: string * success: (float -> float -> unit) * failure: (obj -> unit) -> obj
        abstract prefetch: url: string -> obj

    and ListViewProperties<'a> =
        inherit ScrollViewProperties
        inherit React.Props<ListViewStatic<'a>>
        abstract dataSource: ListViewDataSource<'a> option with get, set
        abstract enableEmptySections: bool option with get, set
        abstract initialListSize: float option with get, set
        abstract onChangeVisibleRows: (ResizeArray<obj> -> ResizeArray<obj> -> unit) option with get, set
        abstract onEndReached: (unit -> unit) option with get, set
        abstract onEndReachedThreshold: float option with get, set
        abstract pageSize: float option with get, set
        abstract removeClippedSubviews: bool option with get, set
        abstract renderFooter: (unit -> React.ReactElement) option with get, set
        abstract renderHeader: (unit -> React.ReactElement) option with get, set
        abstract renderRow: (obj -> U2<string, float> -> U2<string, float> -> bool -> React.ReactElement) option with get, set
        abstract renderScrollComponent: (ScrollViewProperties -> React.ReactElement) option with get, set
        abstract renderSectionHeader: (obj -> U2<string, float> -> React.ReactElement) option with get, set
        abstract renderSeparator: (U2<string, float> -> U2<string, float> -> bool -> React.ReactElement) option with get, set
        abstract scrollRenderAheadDistance: float option with get, set
        abstract ref: Ref<obj> option with get, set

    and ListViewStatic<'a> =
        inherit React.ComponentClass<ListViewProperties<'a>>
        abstract DataSource: ListViewDataSource<'a> with get, set

    and FlatListProperties<'a> =
        inherit ScrollViewProperties
        inherit React.Props<FlatListStatic<'a>>
        abstract refreshing: bool with get, set
        abstract ref: Ref<obj> option with get, set

    and FlatListStatic<'a> =
        inherit React.ComponentClass<FlatListProperties<'a>>

    and MapViewAnnotation =
        abstract latitude: float option with get, set
        abstract longitude: float option with get, set
        abstract animateDrop: bool option with get, set
        abstract title: string option with get, set
        abstract subtitle: string option with get, set
        abstract hasLeftCallout: bool option with get, set
        abstract hasRightCallout: bool option with get, set
        abstract onLeftCalloutPress: (unit -> unit) option with get, set
        abstract onRightCalloutPress: (unit -> unit) option with get, set
        abstract id: string option with get, set

    and MapViewRegion =
        abstract latitude: float with get, set
        abstract longitude: float with get, set
        abstract latitudeDelta: float option with get, set
        abstract longitudeDelta: float option with get, set

    and MapViewOverlay =
        abstract coordinates: ResizeArray<obj> with get, set
        abstract lineWidth: float option with get, set
        abstract strokeColor: obj option with get, set
        abstract fillColor: obj option with get, set
        abstract id: string option with get, set

    and MapViewPropertiesIOS =
        abstract showsPointsOfInterest: bool option with get, set
        abstract annotations: ResizeArray<MapViewAnnotation> option with get, set
        abstract followUserLocation: bool option with get, set
        abstract legalLabelInsets: Insets option with get, set
        abstract mapType: string option with get, set
        abstract maxDelta: float option with get, set
        abstract minDelta: float option with get, set
        abstract overlays: ResizeArray<MapViewOverlay> with get, set
        abstract showsCompass: bool option with get, set

    and MapViewPropertiesAndroid =
        abstract active: bool option with get, set

    and MapViewProperties =
        inherit MapViewPropertiesIOS
        inherit MapViewPropertiesAndroid
        inherit Touchable
        inherit ViewProperties
        inherit React.Props<MapViewStatic>
        abstract onAnnotationPress: (unit -> unit) option with get, set
        abstract onRegionChange: (MapViewRegion -> unit) option with get, set
        abstract onRegionChangeComplete: (MapViewRegion -> unit) option with get, set
        abstract pitchEnabled: bool option with get, set
        abstract region: MapViewRegion option with get, set
        abstract rotateEnabled: bool option with get, set
        abstract scrollEnabled: bool option with get, set
        abstract showsUserLocation: bool option with get, set
        abstract style: ViewStyle option with get, set
        abstract zoomEnabled: bool option with get, set
        abstract ref: Ref<obj> option with get, set

    and MapViewStatic =
        inherit React.ComponentClass<MapViewProperties>


    and ModalProperties =
        inherit React.Props<ModalStatic>
        abstract animated: bool option with get, set
        abstract animationType: (* TODO StringEnum none | slide | fade *) string option with get, set
        abstract transparent: bool option with get, set
        abstract visible: bool option with get, set
        abstract onRequestClose: (unit -> unit) option with get, set
        abstract onShow: (NativeSyntheticEvent<obj> -> unit) option with get, set

    and ModalStatic =
        inherit React.ComponentClass<ModalProperties>


    and TouchableWithoutFeedbackAndroidProperties =
        abstract accessibilityComponentType: string option with get, set

    and TouchableWithoutFeedbackIOSProperties =
        abstract accessibilityTraits: U2<string, ResizeArray<string>> option with get, set

    and TouchableWithoutFeedbackProperties =
        inherit TouchableWithoutFeedbackAndroidProperties
        inherit TouchableWithoutFeedbackIOSProperties
        abstract accessible: bool option with get, set
        abstract delayLongPress: float option with get, set
        abstract delayPressIn: float option with get, set
        abstract delayPressOut: float option with get, set
        abstract disabled: bool option with get, set
        abstract hitSlop: obj option with get, set
        abstract onLayout: (LayoutChangeEvent -> unit) option with get, set
        abstract onLongPress: (unit -> unit) option with get, set
        abstract onPress: (unit -> unit) option with get, set
        abstract onPressIn: (unit -> unit) option with get, set
        abstract onPressOut: (unit -> unit) option with get, set
        abstract style: ViewStyle option with get, set
        abstract pressRetentionOffset: obj option with get, set

    and TouchableWithoutFeedbackProps =
        inherit TouchableWithoutFeedbackProperties
        inherit React.Props<TouchableWithoutFeedbackStatic>


    and TouchableWithoutFeedbackStatic =
        inherit React.ComponentClass<TouchableWithoutFeedbackProps>


    and TouchableHighlightProperties =
        inherit TouchableWithoutFeedbackProperties
        inherit React.Props<TouchableHighlightStatic>
        abstract activeOpacity: float option with get, set
        abstract onHideUnderlay: (unit -> unit) option with get, set
        abstract onShowUnderlay: (unit -> unit) option with get, set
        abstract style: ViewStyle option with get, set
        abstract underlayColor: string option with get, set

    and ButtonProperties =
        inherit React.Props<ButtonStatic>
        abstract title: string option with get, set
        abstract onPress: (unit -> unit) option with get, set
        abstract accessibilityLabel: string option with get, set
        abstract color: string option with get, set
        abstract disabled: bool option with get, set
        abstract testID: string option with get, set
        abstract hasTVPreferredFocus: Boolean option with get, set

    and ButtonStatic =
        inherit React.ComponentClass<ButtonProperties>


    and TouchableHighlightStatic =
        inherit React.ComponentClass<TouchableHighlightProperties>


    and TouchableOpacityProperties =
        inherit TouchableWithoutFeedbackProperties
        inherit React.Props<TouchableOpacityStatic>
        abstract activeOpacity: float option with get, set

    and TouchableOpacityStatic =
        inherit React.ComponentClass<TouchableOpacityProperties>
        abstract setOpacityTo: (float -> unit) with get, set

    and TouchableNativeFeedbackProperties =
        inherit TouchableWithoutFeedbackProperties
        inherit React.Props<TouchableNativeFeedbackStatic>
        abstract background: obj option with get, set

    and TouchableNativeFeedbackStatic =
        inherit React.ComponentClass<TouchableNativeFeedbackProperties>
        abstract SelectableBackground: (unit -> TouchableNativeFeedbackStatic) with get, set
        abstract SelectableBackgroundBorderless: (unit -> TouchableNativeFeedbackStatic) with get, set
        abstract Ripple: (string -> bool -> TouchableNativeFeedbackStatic) with get, set

    and LeftToRightGesture =
        interface end

    and AnimationInterpolator =
        interface end

    and SceneConfig =
        abstract gestures: obj with get, set
        abstract springFriction: float with get, set
        abstract springTension: float with get, set
        abstract defaultTransitionVelocity: float with get, set
        abstract animationInterpolators: obj with get, set

    and SceneConfigs =
        abstract PushFromRight: SceneConfig with get, set
        abstract FloatFromRight: SceneConfig with get, set
        abstract FloatFromLeft: SceneConfig with get, set
        abstract FloatFromBottom: SceneConfig with get, set
        abstract FloatFromBottomAndroid: SceneConfig with get, set
        abstract FadeAndroid: SceneConfig with get, set
        abstract HorizontalSwipeJump: SceneConfig with get, set
        abstract HorizontalSwipeJumpFromRight: SceneConfig with get, set
        abstract VerticalUpSwipeJump: SceneConfig with get, set
        abstract VerticalDownSwipeJump: SceneConfig with get, set

    and Route =
        abstract ``component``: React.ComponentClass<ViewProperties> option with get, set
        abstract id: string option with get, set
        abstract title: string option with get, set
        abstract passProps: obj option with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: key: string -> obj with get, set
        abstract backButtonTitle: string option with get, set
        abstract content: string option with get, set
        abstract message: string option with get, set
        abstract index: int option with get, set
        abstract onRightButtonPress: (unit -> unit) option with get, set
        abstract rightButtonTitle: string option with get, set
        abstract sceneConfig: SceneConfig option with get, set
        abstract wrapperStyle: obj option with get, set

    and NavigatorProperties =
        inherit React.Props<Navigator>
        abstract configureScene: (Route -> ResizeArray<Route> -> SceneConfig) option with get, set
        abstract initialRoute: Route option with get, set
        abstract initialRouteStack: ResizeArray<Route> option with get, set
        abstract navigationBar: React.ReactElement option with get, set
        abstract navigator: Navigator option with get, set
        abstract onDidFocus: Function option with get, set
        abstract onWillFocus: Function option with get, set
        abstract renderScene: (Route -> Navigator -> React.ReactElement) option with get, set
        abstract sceneStyle: ViewStyle option with get, set
        abstract debugOverlay: bool option with get, set

    and NavigationContext =
        abstract parent: NavigationContext with get, set
        abstract top: NavigationContext with get, set
        abstract currentRoute: obj with get, set
        abstract appendChild: childContext: NavigationContext -> unit
        abstract addListener: eventType: string * listener: (unit -> unit) * ?useCapture: bool -> NativeEventSubscription
        abstract emit: eventType: string * data: obj * ?didEmitCallback: (unit -> unit) -> unit
        abstract dispose: unit -> unit

    and NavigatorStatic =
        inherit React.ComponentClass<NavigatorProperties>
        abstract SceneConfigs: SceneConfigs with get, set
        abstract NavigationBar: NavigatorStatic.NavigationBarStatic with get, set
        abstract BreadcrumbNavigationBar: NavigatorStatic.BreadcrumbNavigationBarStatic with get, set
        abstract navigationContext: NavigationContext with get, set
        abstract getContext: self: obj -> NavigatorStatic
        abstract getCurrentRoutes: unit -> ResizeArray<Route>
        abstract jumpBack: unit -> unit
        abstract jumpForward: unit -> unit
        abstract jumpTo: route: Route -> unit
        abstract push: route: Route -> unit
        abstract pop: unit -> unit
        abstract replace: route: Route -> unit
        abstract replaceAtIndex: route: Route * index: float -> unit
        abstract replacePrevious: route: Route -> unit
        abstract immediatelyResetRouteStack: routes: ResizeArray<Route> -> unit
        abstract popToRoute: route: Route -> unit
        abstract popToTop: unit -> unit
        abstract replacePreviousAndPop: route: Route -> unit
        abstract resetTo: route: Route -> unit

    and StyleSheetStatic =
        inherit React.ComponentClass<StyleSheetProperties>
        abstract hairlineWidth: float with get, set
        abstract absoluteFill: float with get, set
        abstract absoluteFillObject: obj with get, set
        abstract create: styles: 'T -> 'T
        abstract flatten: style: obj -> obj

    and DataSourceAssetCallback =
        abstract rowHasChanged: (obj -> obj -> bool) option with get, set
        abstract sectionHeaderHasChanged: (obj -> obj -> bool) option with get, set
        abstract getRowData: (obj -> U2<float, string> -> U2<float, string> -> 'T) option with get, set
        abstract getSectionHeaderData: (obj -> U2<float, string> -> 'T) option with get, set

    and ListViewDataSource<'a> =
        [<Emit("new $0($1...)")>] abstract Create: onAsset: DataSourceAssetCallback -> ListViewDataSource<'a>
        abstract cloneWithRows: dataBlob: U2<ResizeArray<obj>, obj> * ?rowIdentities: ResizeArray<U2<string, float>> -> ListViewDataSource<'a>
        abstract cloneWithRowsAndSections: dataBlob: U2<ResizeArray<obj>, obj> * ?sectionIdentities: ResizeArray<U2<string, float>> * ?rowIdentities: ResizeArray<ResizeArray<U2<string, float>>> -> ListViewDataSource<'a>
        abstract getRowCount: unit -> int
        abstract getRowData: sectionIndex: float * rowIndex: float -> obj
        abstract getRowIDForFlatIndex: index: float -> string
        abstract getSectionIDForFlatIndex: index: float -> string
        abstract getSectionLengths: unit -> ResizeArray<float>
        abstract sectionHeaderShouldUpdate: sectionIndex: float -> bool
        abstract getSectionHeaderData: sectionIndex: float -> obj

    and TabBarItemProperties =
        inherit ViewProperties
        inherit React.Props<TabBarItemStatic>
        abstract badge: U2<string, float> option with get, set
        abstract icon: U2<obj, string> option with get, set
        abstract onPress: (unit -> unit) option with get, set
        abstract selected: bool option with get, set
        abstract selectedIcon: U2<obj, string> option with get, set
        abstract style: ViewStyle option with get, set
        abstract systemIcon: (* TODO StringEnum bookmarks | contacts | downloads | favorites | featured | history | more | most-recent | most-viewed | recents | search | top-rated *) string with get, set
        abstract title: string option with get, set
        abstract ref: Ref<obj> option with get, set

    and TabBarItemStatic =
        inherit React.ComponentClass<TabBarItemProperties>


    and TabBarIOSProperties =
        inherit ViewProperties
        inherit React.Props<TabBarIOSStatic>
        abstract barTintColor: string option with get, set
        abstract style: ViewStyle option with get, set
        abstract tintColor: string option with get, set
        abstract translucent: bool option with get, set
        abstract unselectedTintColor: string option with get, set
        abstract ref: Ref<obj> option with get, set

    and TabBarIOSStatic =
        inherit React.ComponentClass<TabBarIOSProperties>
        abstract Item: TabBarItemStatic with get, set

    and PixelRatioStatic =
        abstract get: unit -> float
        abstract getFontScale: unit -> float
        abstract getPixelSizeForLayoutSize: layoutSize: float -> float
        abstract roundToNearestPixel: layoutSize: float -> float
        abstract startDetecting: unit -> unit

    and [<StringEnum>] PlatformOSType =
        | Ios | Android | Macos | Windows | Web

    and PlatformStatic =
        abstract OS: PlatformOSType with get, set
        abstract Version: U2<float, string> with get, set
        abstract select: specifics: obj -> 'T

    and DeviceEventSubscriptionStatic =
        abstract remove: unit -> unit

    and DeviceEventEmitterStatic =
        abstract addListener: ``type``: string * onReceived: ('T -> unit) -> DeviceEventSubscription
        abstract removeListener: eventType: string * listener: Function -> unit

    and ScaledSize =
        abstract width: float with get, set
        abstract height: float with get, set
        abstract scale: float with get, set
        abstract fontScale: float with get, set

    and Dimensions =
        abstract get: dim: (* TODO StringEnum window | screen *) string -> ScaledSize
        abstract set: dims: ResizeArray<obj> -> unit

    and PromiseTask =
        obj

    and Handle =
        float

    and InteractionManagerStatic =
        abstract runAfterInteractions: fn: (unit -> U2<unit, PromiseTask>) -> obj
        abstract createInteractionHandle: unit -> Handle
        abstract clearInteractionHandle: handle: Handle -> unit
        abstract setDeadline: deadline: float -> unit

    and ScrollViewStyle =
        inherit FlexStyle
        inherit TransformsStyle
        abstract backfaceVisibility: (* TODO StringEnum visible | hidden *) string option with get, set
        abstract backgroundColor: string option with get, set
        abstract borderColor: string option with get, set
        abstract borderTopColor: string option with get, set
        abstract borderRightColor: string option with get, set
        abstract borderBottomColor: string option with get, set
        abstract borderLeftColor: string option with get, set
        abstract borderRadius: float option with get, set
        abstract borderTopLeftRadius: float option with get, set
        abstract borderTopRightRadius: float option with get, set
        abstract borderBottomLeftRadius: float option with get, set
        abstract borderBottomRightRadius: float option with get, set
        abstract borderStyle: (* TODO StringEnum solid | dotted | dashed *) string option with get, set
        abstract borderWidth: float option with get, set
        abstract borderTopWidth: float option with get, set
        abstract borderRightWidth: float option with get, set
        abstract borderBottomWidth: float option with get, set
        abstract borderLeftWidth: float option with get, set
        abstract opacity: float option with get, set
        abstract overflow: (* TODO StringEnum visible | hidden *) string option with get, set
        abstract shadowColor: string option with get, set
        abstract shadowOffset: obj option with get, set
        abstract shadowOpacity: float option with get, set
        abstract shadowRadius: float option with get, set
        abstract elevation: float option with get, set

    and ScrollViewPropertiesIOS =
        abstract alwaysBounceHorizontal: bool option with get, set
        abstract alwaysBounceVertical: bool option with get, set
        abstract automaticallyAdjustContentInsets: bool option with get, set
        abstract bounces: bool option with get, set
        abstract bouncesZoom: bool option with get, set
        abstract canCancelContentTouches: bool option with get, set
        abstract centerContent: bool option with get, set
        abstract contentInset: Insets option with get, set
        abstract contentOffset: PointProperties option with get, set
        abstract decelerationRate: (* TODO StringEnum fast | normal |  *) string option with get, set
        abstract directionalLockEnabled: bool option with get, set
        abstract indicatorStyle: (* TODO StringEnum default | black | white *) string option with get, set
        abstract maximumZoomScale: float option with get, set
        abstract minimumZoomScale: float option with get, set
        abstract onRefreshStart: (unit -> unit) option with get, set
        abstract onScrollAnimationEnd: (unit -> unit) option with get, set
        abstract scrollEnabled: bool option with get, set
        abstract scrollEventThrottle: float option with get, set
        abstract scrollIndicatorInsets: Insets option with get, set
        abstract scrollsToTop: bool option with get, set
        abstract snapToAlignment: string option with get, set
        abstract snapToInterval: float option with get, set
        abstract stickyHeaderIndices: ResizeArray<float> option with get, set
        abstract zoomScale: float option with get, set

    and ScrollViewPropertiesAndroid =
        abstract endFillColor: string option with get, set
        abstract scrollPerfTag: string option with get, set

    and ScrollViewProperties =
        inherit ViewProperties
        inherit ScrollViewPropertiesIOS
        inherit ScrollViewPropertiesAndroid
        inherit Touchable
//        inherit React.Props<ScrollViewStatic>
        abstract contentContainerStyle: ViewStyle option with get, set
        abstract horizontal: bool option with get, set
        abstract keyboardDismissMode: string option with get, set
        abstract keyboardShouldPersistTaps: bool option with get, set
        abstract onScroll: (obj -> unit) option with get, set
        abstract onScrollBeginDrag: (obj -> unit) option with get, set
        abstract onScrollEndDrag: (obj -> unit) option with get, set
        abstract onMomentumScrollBegin: (obj -> unit) option with get, set
        abstract onMomentumScrollEnd: (obj -> unit) option with get, set
        abstract pagingEnabled: bool option with get, set
        abstract removeClippedSubviews: bool option with get, set
        abstract showsHorizontalScrollIndicator: bool option with get, set
        abstract showsVerticalScrollIndicator: bool option with get, set
        abstract style: ScrollViewStyle option with get, set
        abstract refreshControl: React.ReactElement option with get, set
        abstract ref: Ref<obj> option with get, set

    and ScrollViewProps =
        // inherit ScrollViewProperties
        inherit React.Props<ScrollViewStatic>
        abstract ref: Ref<ScrollViewStatic> option with get, set

    and ScrollViewStatic =
        inherit React.ComponentClass<ScrollViewProps>
        abstract endRefreshing: (unit -> unit) option with get, set
        abstract scrollWithoutAnimationTo: (float -> float -> unit) option with get, set
        abstract scrollTo: ?y: U2<float, obj> * ?x: float * ?animated: bool -> unit
        abstract getScrollResponder: unit -> JSX.Element
        abstract getInnerViewNode: unit -> obj

    and NativeScrollRectangle =
        abstract left: float with get, set
        abstract top: float with get, set
        abstract bottom: float with get, set
        abstract right: float with get, set

    and NativeScrollPoint =
        abstract x: float with get, set
        abstract y: float with get, set

    and NativeScrollSize =
        abstract height: float with get, set
        abstract width: float with get, set

    and NativeScrollEvent =
        abstract contentInset: NativeScrollRectangle with get, set
        abstract contentOffset: NativeScrollPoint with get, set
        abstract contentSize: NativeScrollSize with get, set
        abstract layoutMeasurement: NativeScrollSize with get, set
        abstract zoomScale: float with get, set

    and SwipeableListViewDataSource<'a> =
        abstract cloneWithRowsAndSections: dataBlob: obj * sectionIdentities: ResizeArray<string> * rowIdentities: ResizeArray<ResizeArray<string>> -> SwipeableListViewDataSource<'a>
        abstract getDataSource: unit -> ListViewDataSource<'a>
        abstract getOpenRowID: unit -> string
        abstract setOpenRowID: rowID: string -> ListViewDataSource<'a>

    and SwipeableListViewProps<'a> =
        inherit React.Props<SwipeableListViewStatic<'a>>
        abstract dataSource: SwipeableListViewDataSource<'a> with get, set
        abstract maxSwipeDistance: float option with get, set
        abstract renderRow: (obj -> U2<string, float> -> U2<string, float> -> bool -> React.ReactElement) with get, set
        abstract renderQuickActions: rowData: obj * sectionID: string * rowID: string -> React.ReactElement

    and SwipeableListViewStatic<'a> =
        inherit React.ComponentClass<SwipeableListViewProps<'a>>
        abstract getNewDataSource: unit -> SwipeableListViewDataSource<'a>

    and ActionSheetIOSOptions =
        abstract title: string option with get, set
        abstract options: ResizeArray<string> option with get, set
        abstract cancelButtonIndex: float option with get, set
        abstract destructiveButtonIndex: float option with get, set
        abstract message: string option with get, set

    and ShareActionSheetIOSOptions =
        abstract message: string option with get, set
        abstract url: string option with get, set

    and ActionSheetIOSStatic =
        abstract showActionSheetWithOptions: (ActionSheetIOSOptions -> (float -> unit) -> unit) with get, set
        abstract showShareActionSheetWithOptions: (ShareActionSheetIOSOptions -> (Error -> unit) -> (bool -> string -> unit) -> unit) with get, set

    and AlertButton =
        abstract text: string option with get, set
        abstract onPress: (unit -> unit) option with get, set
        abstract style: (* TODO StringEnum default | cancel | destructive *) string option with get, set

    and AlertStatic =
        abstract alert: (string -> string -> ResizeArray<AlertButton> -> string -> unit) with get, set

    and AdSupportIOSStatic =
        abstract getAdvertisingId: ((string -> unit) -> (Error -> unit) -> unit) with get, set
        abstract getAdvertisingTrackingEnabled: ((bool -> unit) -> (Error -> unit) -> unit) with get, set

    and AlertIOSButton =
        abstract text: string with get, set
        abstract onPress: (unit -> unit) option with get, set
        abstract style: (* TODO StringEnum default | cancel | destructive *) string option with get, set

    and AlertIOSStatic =
        abstract alert: (string -> string -> (string -> U2<unit, ResizeArray<AlertIOSButton>>) -> string -> unit) with get, set
        abstract prompt: (string -> string -> (string -> U2<unit, ResizeArray<AlertIOSButton>>) -> string -> string -> unit) with get, set

    and [<StringEnum>] AppStateEvent =
        | Change | MemoryWarning

    and [<StringEnum>] AppStateStatus =
        | Active | Background | Inactive

    and AppStateStatic =
        abstract currentState: string with get, set
        abstract addEventListener: ``type``: AppStateEvent * listener: (AppStateStatus -> unit) -> unit
        abstract removeEventListener: ``type``: AppStateEvent * listener: (AppStateStatus -> unit) -> unit

    and AsyncStorageStatic =
        abstract getItem: key: string * ?callback: (Error -> string -> unit) -> Promise<string>
        abstract setItem: key: string * value: string * ?callback: (Error -> unit) -> Promise<string>
        abstract removeItem: key: string * ?callback: (Error -> unit) -> Promise<string>
        abstract mergeItem: key: string * value: string * ?callback: (Error -> unit) -> Promise<string>
        abstract clear: ?callback: (Error -> unit) -> Promise<string>
        abstract getAllKeys: ?callback: (Error -> ResizeArray<string> -> unit) -> Promise<string>
        abstract multiGet: keys: ResizeArray<string> * ?callback: (ResizeArray<Error> -> ResizeArray<ResizeArray<string>> -> unit) -> Promise<string>
        abstract multiSet: keyValuePairs: ResizeArray<ResizeArray<string>> * ?callback: (ResizeArray<Error> -> unit) -> Promise<string>
        abstract multiRemove: keys: ResizeArray<string> * ?callback: (ResizeArray<Error> -> unit) -> Promise<string>
        abstract multiMerge: keyValuePairs: ResizeArray<ResizeArray<string>> * ?callback: (ResizeArray<Error> -> unit) -> Promise<string>

    and BackAndroidStatic =
        abstract exitApp: unit -> unit
        abstract addEventListener: eventName: string * handler: (unit -> unit) -> unit
        abstract removeEventListener: eventName: string * handler: (unit -> unit) -> unit

    and CameraRollFetchParams =
        abstract first: float with get, set
        abstract after: string option with get, set
        abstract groupTypes: string with get, set
        abstract groupName: string option with get, set
        abstract assetType: string option with get, set

    and CameraRollNodeInfo =
        abstract image: Image with get, set
        abstract group_name: string with get, set
        abstract timestamp: float with get, set
        abstract location: obj with get, set

    and CameraRollEdgeInfo =
        abstract node: CameraRollNodeInfo with get, set

    and CameraRollAssetInfo =
        abstract edges: ResizeArray<CameraRollEdgeInfo> with get, set
        abstract page_info: obj with get, set

    and GetPhotosParamType =
        abstract first: float with get, set
        abstract after: string with get, set
        abstract groupTypes: (* TODO StringEnum Album | All | Event | Faces | Library | PhotoStream | SavedPhotos *) string with get, set
        abstract groupName: string with get, set
        abstract assetType: (* TODO StringEnum All | Videos | Photos *) string with get, set
        abstract mimeTypes: ResizeArray<string> with get, set

    and GetPhotosReturnType =
        abstract edges: ResizeArray<obj> with get, set
        abstract page_info: obj with get, set

    and CameraRollStatic =
        abstract GroupTypesOptions: ResizeArray<string> with get, set
        abstract saveImageWithTag: tag: string -> Promise<string>
        abstract saveToCameraRoll: tag: string * ?``type``: (* TODO StringEnum photo | video *) string -> Promise<string>
        abstract getPhotos: ``params``: GetPhotosParamType -> Promise<GetPhotosReturnType>

    and ClipboardStatic =
        abstract getString: unit -> Promise<string>
        abstract setString: content: string -> unit

    and DatePickerAndroidOpenOption =
        abstract date: U2<DateTime, float> option with get, set
        abstract minDate: U2<DateTime, float> option with get, set
        abstract maxDate: U2<DateTime, float> option with get, set

    and DatePickerAndroidOpenReturn =
        abstract action: string with get, set
        abstract year: float option with get, set
        abstract month: float option with get, set
        abstract day: float option with get, set

    and DatePickerAndroidStatic =
        abstract dateSetAction: string with get, set
        abstract dismissedAction: string with get, set
        abstract ``open``: ?options: DatePickerAndroidOpenOption -> Promise<DatePickerAndroidOpenReturn>

    and FetchableListenable<'T> =
        abstract fetch: (unit -> Promise<'T>) with get, set
        abstract addEventListener: (string -> ('T -> unit) -> unit) with get, set
        abstract removeEventListener: (string -> ('T -> unit) -> unit) with get, set

    and IntentAndroidStatic =
        abstract openURL: url: string -> unit
        abstract canOpenURL: url: string * callback: (bool -> unit) -> unit
        abstract getInitialURL: callback: (string -> unit) -> unit

    and LinkingStatic =
        abstract addEventListener: ``type``: string * handler: (obj -> unit) -> unit
        abstract removeEventListener: ``type``: string * handler: (obj -> unit) -> unit
        abstract openURL: url: string -> Promise<bool>
        abstract canOpenURL: url: string -> Promise<bool>
        abstract getInitialURL: unit -> Promise<string>

    and LinkingIOSStatic =
        abstract addEventListener: ``type``: string * handler: (obj -> unit) -> unit
        abstract removeEventListener: ``type``: string * handler: (obj -> unit) -> unit
        abstract openURL: url: string -> unit
        abstract canOpenURL: url: string * callback: (bool -> unit) -> unit
        abstract popInitialURL: unit -> string

    and [<StringEnum; RequireQualifiedAccess>] NetInfoReturnType =
        | None | Wifi | Cell | Unknown | [<CompiledName("NONE")>] NONE | [<CompiledName("MOBILE")>] MOBILE | [<CompiledName("WIFI")>] WIFI | [<CompiledName("MOBILE_MMS")>] MOBILE_MMS | [<CompiledName("MOBILE_SUPL")>] MOBILE_SUPL | [<CompiledName("MOBILE_DUN")>] MOBILE_DUN | [<CompiledName("MOBILE_HIPRI")>] MOBILE_HIPRI | [<CompiledName("WIMAX")>] WIMAX | [<CompiledName("BLUETOOTH")>] BLUETOOTH | [<CompiledName("DUMMY")>] DUMMY | [<CompiledName("ETHERNET")>] ETHERNET | [<CompiledName("MOBILE_FOTA")>] MOBILE_FOTA | [<CompiledName("MOBILE_IMS")>] MOBILE_IMS | [<CompiledName("MOBILE_CBS")>] MOBILE_CBS | [<CompiledName("WIFI_P2P")>] WIFI_P2P | [<CompiledName("MOBILE_IA")>] MOBILE_IA | [<CompiledName("MOBILE_EMERGENCY")>] MOBILE_EMERGENCY | [<CompiledName("PROXY")>] PROXY | [<CompiledName("VPN")>] VPN | [<CompiledName("UNKNOWN")>] UNKNOWN

    and NetInfoStatic =
        inherit FetchableListenable<NetInfoReturnType>
        abstract isConnected: FetchableListenable<bool> with get, set
        abstract isConnectionExpensive: FetchableListenable<bool> with get, set

    and PanResponderGestureState =
        abstract stateID: float with get, set
        abstract moveX: float with get, set
        abstract moveY: float with get, set
        abstract x0: float with get, set
        abstract y0: float with get, set
        abstract dx: float with get, set
        abstract dy: float with get, set
        abstract vx: float with get, set
        abstract vy: float with get, set
        abstract numberActiveTouches: float with get, set
        abstract _accountsForMovesUpTo: float with get, set

    and PanResponderCallbacks =
        abstract onMoveShouldSetPanResponder: (GestureResponderEvent -> PanResponderGestureState -> bool) option with get, set
        abstract onStartShouldSetPanResponder: (GestureResponderEvent -> PanResponderGestureState -> unit) option with get, set
        abstract onPanResponderGrant: (GestureResponderEvent -> PanResponderGestureState -> unit) option with get, set
        abstract onPanResponderMove: (GestureResponderEvent -> PanResponderGestureState -> unit) option with get, set
        abstract onPanResponderRelease: (GestureResponderEvent -> PanResponderGestureState -> unit) option with get, set
        abstract onPanResponderTerminate: (GestureResponderEvent -> PanResponderGestureState -> unit) option with get, set
        abstract onMoveShouldSetPanResponderCapture: (GestureResponderEvent -> PanResponderGestureState -> bool) option with get, set
        abstract onStartShouldSetPanResponderCapture: (GestureResponderEvent -> PanResponderGestureState -> bool) option with get, set
        abstract onPanResponderReject: (GestureResponderEvent -> PanResponderGestureState -> unit) option with get, set
        abstract onPanResponderStart: (GestureResponderEvent -> PanResponderGestureState -> unit) option with get, set
        abstract onPanResponderEnd: (GestureResponderEvent -> PanResponderGestureState -> unit) option with get, set
        abstract onPanResponderTerminationRequest: (GestureResponderEvent -> PanResponderGestureState -> bool) option with get, set

    and PanResponderInstance =
        abstract panHandlers: GestureResponderHandlers with get, set

    and PanResponderStatic =
        abstract create: config: PanResponderCallbacks -> PanResponderInstance

    and PushNotificationPermissions =
        abstract alert: bool option with get, set
        abstract badge: bool option with get, set
        abstract sound: bool option with get, set

    and PushNotification =
        abstract getMessage: unit -> U2<string, obj>
        abstract getSound: unit -> string
        abstract getAlert: unit -> U2<string, obj>
        abstract getBadgeCount: unit -> float
        abstract getData: unit -> obj

    and PresentLocalNotificationDetails =
        obj

    and ScheduleLocalNotificationDetails =
        obj

    and PushNotificationIOSStatic =
        abstract presentLocalNotification: details: PresentLocalNotificationDetails -> unit
        abstract scheduleLocalNotification: details: ScheduleLocalNotificationDetails -> unit
        abstract cancelAllLocalNotifications: unit -> unit
        abstract cancelLocalNotifications: userInfo: obj -> unit
        abstract setApplicationIconBadgeNumber: number: float -> unit
        abstract getApplicationIconBadgeNumber: callback: (float -> unit) -> unit
        abstract addEventListener: ``type``: string * handler: (PushNotification -> unit) -> unit
        abstract requestPermissions: ?permissions: ResizeArray<PushNotificationPermissions> -> Promise<PushNotificationPermissions>
        abstract abandonPermissions: unit -> unit
        abstract checkPermissions: callback: (PushNotificationPermissions -> unit) -> unit
        abstract removeEventListener: ``type``: string * handler: (PushNotification -> unit) -> unit
        abstract popInitialNotification: unit -> PushNotification

    and [<StringEnum>] StatusBarStyle =
        | Default
        | [<CompiledName("light-content")>] LightContent
        | [<CompiledName("dark-content")>] DarkContent

    and [<StringEnum; RequireQualifiedAccess>] StatusBarAnimation =
        | None | Fade | Slide

    and StatusBarPropertiesIOS =
        inherit React.Props<StatusBarStatic>
        abstract barStyle: StatusBarStyle option with get, set
        abstract networkActivityIndicatorVisible: bool option with get, set
        abstract showHideTransition: (* TODO StringEnum fade | slide *) string option with get, set

    and StatusBarPropertiesAndroid =
        inherit React.Props<StatusBarStatic>
        abstract backgroundColor: obj option with get, set
        abstract translucent: bool option with get, set

    and StatusBarProperties =
        inherit StatusBarPropertiesIOS
        inherit StatusBarPropertiesAndroid
        inherit React.Props<StatusBarStatic>
        abstract animated: bool option with get, set
        abstract hidden: bool option with get, set

    and StatusBarStatic =
        inherit React.ComponentClass<StatusBarProperties>
        abstract setHidden: (bool -> StatusBarAnimation -> unit) with get, set
        abstract setBarStyle: (StatusBarStyle -> bool -> unit) with get, set
        abstract setNetworkActivityIndicatorVisible: (bool -> unit) with get, set
        abstract setBackgroundColor: (string -> bool -> unit) with get, set
        abstract setTranslucent: (bool -> unit) with get, set
        /// Only available for Android
        abstract currentHeight: float with get

    and StatusBarIOSStatic =
        interface end

    and TimePickerAndroidOpenOptions =
        obj

    and TimePickerAndroidStatic =
        abstract timeSetAction: string with get, set
        abstract dismissedAction: string with get, set
        abstract ``open``: options: TimePickerAndroidOpenOptions -> Promise<obj>

    and ToastAndroidStatic =
        abstract SHORT: float with get, set
        abstract LONG: float with get, set
        abstract show: message: string * duration: float -> unit
        abstract showWithGravity: message: string * duration: float * gravity: float -> unit

    and SwitchProperties =
        inherit ViewProperties
        inherit React.Props<SwitchStatic>
        abstract value: bool option with get, set
        abstract disabled: bool option with get, set
        abstract onValueChange: (bool -> unit) option with get, set
        abstract testID: string option with get, set
        abstract tintColor: string option with get, set
        abstract onTintColor: string option with get, set
        abstract thumbTintColor: string option with get, set
        abstract ref: Ref<SwitchStatic> option with get, set

    and SwitchStatic =
        inherit React.ComponentClass<SwitchProperties>


    and VibrationIOSStatic =
        abstract vibrate: unit -> unit

    and VibrationStatic =
        abstract vibrate: pattern: U2<float, ResizeArray<float>> * repeat: bool -> unit
        abstract cancel: unit -> unit

    and EasingFunction =
        (float -> float)

    and EasingStatic =
        abstract step0: EasingFunction with get, set
        abstract step1: EasingFunction with get, set
        abstract linear: EasingFunction with get, set
        abstract ease: EasingFunction with get, set
        abstract quad: EasingFunction with get, set
        abstract cubic: EasingFunction with get, set
        abstract poly: EasingFunction with get, set
        abstract sin: EasingFunction with get, set
        abstract circle: EasingFunction with get, set
        abstract exp: EasingFunction with get, set
        abstract elastic: EasingFunction with get, set
        abstract bounce: EasingFunction with get, set
        abstract back: s: float -> EasingFunction
        abstract bezier: x1: float * y1: float * x2: float * y2: float -> EasingFunction
        abstract ``in``: easing: EasingFunction -> EasingFunction
        abstract out: easing: EasingFunction -> EasingFunction
        abstract inOut: easing: EasingFunction -> EasingFunction

    and GeolocationStatic =
        abstract getCurrentPosition: geo_success: (GeolocationReturnType -> unit) * ?geo_error: (Error -> unit) * ?geo_options: GetCurrentPositionOptions -> unit
        abstract watchPosition: success: (Geolocation -> unit) * ?error: (Error -> unit) * ?options: WatchPositionOptions -> unit
        abstract clearWatch: watchID: float -> unit
        abstract stopObserving: unit -> unit

    and fetch =
        (string -> obj -> Promise<obj>)

    and timedScheduler =
        (U2<string, Function> -> float -> float)

    and untimedScheduler =
        (U2<string, Function> -> float)

    and setTimeout =
        timedScheduler

    and setInterval =
        timedScheduler

    and setImmediate =
        untimedScheduler

    and requestAnimationFrame =
        untimedScheduler

    and schedulerCanceller =
        (float -> unit)

    and clearTimeout =
        schedulerCanceller

    and clearInterval =
        schedulerCanceller

    and clearImmediate =
        schedulerCanceller

    and cancelAnimationFrame =
        schedulerCanceller

    and TabsReducerStatic =
        abstract JumpToAction: index: float -> obj

    and TabsReducerFunction =
        (obj -> obj)

    and NavigationReducerStatic =
        abstract TabsReducer: obj with get, set

    and NavigationTab =
        abstract key: string with get, set

    and NavigationAction =
        abstract ``type``: string with get, set

    and NavigationRoute =
        abstract key: string with get, set
        abstract title: string option with get, set // added by hand, according to JS sources

    // added by hand, according to JS sources
    and NavigationLayout =
        abstract height: Animated.Value with get, set
        abstract width: Animated.Value with get, set
        abstract initHeight: float with get, set
        abstract initWidth: float with get, set
        abstract isMeasured: bool with get, set

    and NavigationState =
        inherit NavigationRoute
        abstract index: int with get, set
        abstract routes: Array<NavigationRoute> with get, set
        abstract isMeasured: bool with get, set

    and NavigationScene =
        abstract key: string with get, set
        abstract isActive: bool with get, set
        abstract isStale: bool with get, set
        abstract index: int with get, set
        abstract route: NavigationRoute with get, set

    and NavigationTransitionProps =
        abstract layout: NavigationLayout with get,set
        abstract navigationState: NavigationState with get,set
        abstract position: Animated.Value with get,set
        abstract progress: Animated.Value with get,set
        abstract scenes: NavigationScene [] with get,set
        abstract scene: NavigationScene with get,set
        abstract gestureResponseDistance: float option with get,set

    and NavigationRenderer =
        (NavigationState -> (NavigationAction -> bool) -> JSX.Element)

    and NavigationAnimatedViewStaticProps =
        abstract route: obj option with get, set
        abstract style: ViewStyle option with get, set
        abstract renderOverlay: props: obj -> JSX.Element
        abstract applyAnimation: pos: obj * navState: obj -> unit
        abstract renderScene: props: obj -> JSX.Element

    and NavigationAnimatedViewStatic =
        inherit React.ComponentClass<NavigationAnimatedViewStaticProps>


    and NavigationHeaderProps =
        abstract renderTitleComponent: props: obj -> JSX.Element
        abstract onNavigateBack: unit -> unit

    and NavigationHeaderStatic =
        inherit React.ComponentClass<NavigationHeaderProps>
        abstract Title: JSX.Element with get, set
        abstract HEIGHT: float with get, set

    and NavigationCardStackProps =
        abstract direction: (* TODO StringEnum horizontal | vertical *) string option with get, set
        abstract style: ViewStyle option with get, set
        abstract route: obj option with get, set
        abstract renderScene: props: obj -> JSX.Element
        abstract onNavigateBack: unit -> unit

    and NavigationCardStackStatic =
        inherit React.ComponentClass<NavigationCardStackProps>

    // added by hand from JS sources
    and NavigationStateUtilsStatic =
        abstract get: state: NavigationState*key: string -> NavigationRoute option
        abstract indexOf: state: NavigationState * key: string -> int
        abstract has: state: NavigationState * key: string -> bool
        abstract push: state: NavigationState * route: NavigationRoute -> NavigationState
        abstract pop: state: NavigationState -> NavigationState
        abstract jumpToIndex: state: NavigationState * index: int -> NavigationState
        abstract jumpTo: state: NavigationState * key: string -> NavigationState
        abstract forward: state: NavigationState -> NavigationState
        abstract replaceAt: state: NavigationState * key: string * route: NavigationRoute -> NavigationState
        abstract replaceAtIndex: state: NavigationState * index: int * route: NavigationRoute -> NavigationState
        abstract reset: state: NavigationState * routes: Array<NavigationRoute> * index: int option -> NavigationState

    and NavigationExperimentalStatic =
        abstract AnimatedView: NavigationAnimatedViewStatic with get, set
        abstract CardStack: NavigationCardStackStatic with get, set
        abstract Header: NavigationHeaderStatic with get, set
        abstract Reducer: NavigationReducerStatic with get, set
        abstract StateUtils: NavigationStateUtilsStatic with get, set

    and NavigationContainerProps =
        abstract tabs: ResizeArray<NavigationTab> with get, set
        abstract index: float with get, set

    and NavigationContainerStatic =
        inherit React.ComponentClass<NavigationContainerProps>
        abstract create: inClass: obj -> obj

    and NavigationRootContainerProps =
        inherit React.Props<NavigationRootContainerStatic>
        abstract renderNavigation: NavigationRenderer with get, set
        abstract reducer: NavigationReducerStatic with get, set
        abstract persistenceKey: string option with get, set

    and NavigationRootContainerStatic =
        inherit React.ComponentClass<NavigationRootContainerProps>
        abstract getBackAction: unit -> NavigationAction
        abstract handleNavigation: action: NavigationAction -> bool

    and NativeEventSubscription =
        abstract remove: unit -> unit

    and NativeAppEventEmitterStatic =
        abstract addListener: ``event``: string * handler: (obj -> unit) -> NativeEventSubscription

    and ActivityIndicator =
        ActivityIndicatorStatic

    and ActivityIndicatorIOS =
        ActivityIndicatorIOSStatic

    and DatePickerIOS =
        DatePickerIOSStatic

    and DrawerLayoutAndroid =
        DrawerLayoutAndroidStatic

    and Image =
        ImageStatic

    and LayoutAnimation =
        LayoutAnimationStatic

    and ListView<'a> =
        ListViewStatic<'a>

    and FlatList<'a> =
        FlatListStatic<'a>

    and MapView =
        MapViewStatic

    and Modal =
        ModalStatic

    and Navigator =
        NavigatorStatic

    and NavigatorIOS =
        NavigatorIOSStatic

    and Picker =
        PickerStatic

    and PickerIOS =
        PickerIOSStatic

    and ProgressBarAndroid =
        ProgressBarAndroidStatic

    and ProgressViewIOS =
        ProgressViewIOSStatic

    and RefreshControl =
        RefreshControlStatic

    and Slider =
        SliderStatic

    and StatusBar =
        StatusBarStatic

    and ScrollView =
        ScrollViewStatic

    and StyleSheet =
        StyleSheetStatic

    and SwipeableListView<'a> =
        SwipeableListViewStatic<'a>

    and Switch =
        SwitchStatic

    and TabBarIOS =
        TabBarIOSStatic

    and Text =
        TextStatic

    and TextInput =
        TextInputStatic

    and ToolbarAndroid =
        ToolbarAndroidStatic

    and Button =
        ButtonStatic

    and TouchableHighlight =
        TouchableHighlightStatic

    and TouchableNativeFeedback =
        TouchableNativeFeedbackStatic

    and TouchableOpacity =
        TouchableOpacityStatic

    and TouchableWithoutFeedback =
        TouchableWithoutFeedbackStatic

    and View =
        ViewStatic

    and ViewPagerAndroid =
        ViewPagerAndroidStatic

    and WebView =
        WebViewStatic

    and ActionSheetIOS =
        ActionSheetIOSStatic

    and AdSupportIOS =
        AdSupportIOSStatic

    and Alert =
        AlertStatic

    and AlertIOS =
        AlertIOSStatic

    and AppState =
        AppStateStatic

    and AppStateIOS =
        AppStateStatic

    and AsyncStorage =
        AsyncStorageStatic

    and BackAndroid =
        BackAndroidStatic

    and CameraRoll =
        CameraRollStatic

    and Clipboard =
        ClipboardStatic

    and DatePickerAndroid =
        DatePickerAndroidStatic

    and IntentAndroid =
        IntentAndroidStatic

    and KeyboardAvoidingView =
        KeyboardAvoidingViewStatic

    and Linking =
        LinkingStatic

    and LinkingIOS =
        LinkingIOSStatic

    and NetInfo =
        NetInfoStatic

    and PanResponder =
        PanResponderStatic

    and PushNotificationIOS =
        PushNotificationIOSStatic

    and StatusBarIOS =
        StatusBarIOSStatic

    and TimePickerAndroid =
        TimePickerAndroidStatic

    and ToastAndroid =
        ToastAndroidStatic

    and VibrationIOS =
        VibrationIOSStatic

    and Vibration =
        VibrationStatic

    and NavigationExperimental =
        NavigationExperimentalStatic

    and NavigationContainer =
        NavigationContainerStatic

    and NavigationRootContainer =
        NavigationRootContainerStatic

    and NavigationReducer =
        NavigationReducerStatic

    and Easing =
        EasingStatic

    and ComponentInterface<'P> =
        abstract name: string option with get, set
        abstract displayName: string option with get, set
        abstract propTypes: 'P with get, set

    and SegmentedControlIOS =
        SegmentedControlIOSStatic

    and DeviceEventSubscription =
        DeviceEventSubscriptionStatic

    and Geolocation =
        GeolocationStatic

    and GlobalStatic =
        abstract requestAnimationFrame: fn: (unit -> unit) -> unit

    type Globals =
        [<Import("ActivityIndicator", "react-native")>] static member ActivityIndicator with get(): ActivityIndicatorStatic = jsNative and set(v: ActivityIndicatorStatic): unit = jsNative
        [<Import("ActivityIndicatorIOS", "react-native")>] static member ActivityIndicatorIOS with get(): ActivityIndicatorIOSStatic = jsNative and set(v: ActivityIndicatorIOSStatic): unit = jsNative
        [<Import("DatePickerIOS", "react-native")>] static member DatePickerIOS with get(): DatePickerIOSStatic = jsNative and set(v: DatePickerIOSStatic): unit = jsNative
        [<Import("DrawerLayoutAndroid", "react-native")>] static member DrawerLayoutAndroid with get(): DrawerLayoutAndroidStatic = jsNative and set(v: DrawerLayoutAndroidStatic): unit = jsNative
        [<Import("Image", "react-native")>] static member Image with get(): ImageStatic = jsNative and set(v: ImageStatic): unit = jsNative
        [<Import("LayoutAnimation", "react-native")>] static member LayoutAnimation with get(): LayoutAnimationStatic = jsNative and set(v: LayoutAnimationStatic): unit = jsNative
        [<Import("ListView", "react-native")>] static member ListView with get(): ListViewStatic<obj> = jsNative and set(v: ListViewStatic<obj>): unit = jsNative
        [<Import("FlatList", "react-native")>] static member FlatList with get(): FlatListStatic<obj> = jsNative and set(v: FlatListStatic<obj>): unit = jsNative
        [<Import("MapView", "react-native")>] static member MapView with get(): MapViewStatic = jsNative and set(v: MapViewStatic): unit = jsNative
        [<Import("Modal", "react-native")>] static member Modal with get(): ModalStatic = jsNative and set(v: ModalStatic): unit = jsNative
        [<Import("Navigator", "react-native")>] static member Navigator with get(): NavigatorStatic = jsNative and set(v: NavigatorStatic): unit = jsNative
        [<Import("NavigatorIOS", "react-native")>] static member NavigatorIOS with get(): NavigatorIOSStatic = jsNative and set(v: NavigatorIOSStatic): unit = jsNative
        [<Import("Picker", "react-native")>] static member Picker with get(): PickerStatic = jsNative and set(v: PickerStatic): unit = jsNative
        [<Import("PickerIOS", "react-native")>] static member PickerIOS with get(): PickerIOSStatic = jsNative and set(v: PickerIOSStatic): unit = jsNative
        [<Import("ProgressBarAndroid", "react-native")>] static member ProgressBarAndroid with get(): ProgressBarAndroidStatic = jsNative and set(v: ProgressBarAndroidStatic): unit = jsNative
        [<Import("ProgressViewIOS", "react-native")>] static member ProgressViewIOS with get(): ProgressViewIOSStatic = jsNative and set(v: ProgressViewIOSStatic): unit = jsNative
        [<Import("RefreshControl", "react-native")>] static member RefreshControl with get(): RefreshControlStatic = jsNative and set(v: RefreshControlStatic): unit = jsNative
        [<Import("Slider", "react-native")>] static member Slider with get(): SliderStatic = jsNative and set(v: SliderStatic): unit = jsNative
        [<Import("StatusBar", "react-native")>] static member StatusBar with get(): StatusBarStatic = jsNative and set(v: StatusBarStatic): unit = jsNative
        [<Import("ScrollView", "react-native")>] static member ScrollView with get(): ScrollViewStatic = jsNative and set(v: ScrollViewStatic): unit = jsNative
        [<Import("StyleSheet", "react-native")>] static member StyleSheet with get(): StyleSheetStatic = jsNative and set(v: StyleSheetStatic): unit = jsNative
        [<Import("SwipeableListView", "react-native")>] static member SwipeableListView with get(): SwipeableListViewStatic<obj> = jsNative and set(v: SwipeableListViewStatic<obj>): unit = jsNative
        [<Import("Switch", "react-native")>] static member Switch with get(): SwitchStatic = jsNative and set(v: SwitchStatic): unit = jsNative
        [<Import("TabBarIOS", "react-native")>] static member TabBarIOS with get(): TabBarIOSStatic = jsNative and set(v: TabBarIOSStatic): unit = jsNative
        [<Import("Text", "react-native")>] static member Text with get(): TextStatic = jsNative and set(v: TextStatic): unit = jsNative
        [<Import("TextInput", "react-native")>] static member TextInput with get(): TextInputStatic = jsNative and set(v: TextInputStatic): unit = jsNative
        [<Import("ToolbarAndroid", "react-native")>] static member ToolbarAndroid with get(): ToolbarAndroidStatic = jsNative and set(v: ToolbarAndroidStatic): unit = jsNative
        [<Import("TouchableHighlight", "react-native")>] static member TouchableHighlight with get(): TouchableHighlightStatic = jsNative and set(v: TouchableHighlightStatic): unit = jsNative
        [<Import("Button", "react-native")>] static member Button with get(): ButtonStatic = jsNative and set(v: ButtonStatic): unit = jsNative
        [<Import("TouchableNativeFeedback", "react-native")>] static member TouchableNativeFeedback with get(): TouchableNativeFeedbackStatic = jsNative and set(v: TouchableNativeFeedbackStatic): unit = jsNative
        [<Import("TouchableOpacity", "react-native")>] static member TouchableOpacity with get(): TouchableOpacityStatic = jsNative and set(v: TouchableOpacityStatic): unit = jsNative
        [<Import("TouchableWithoutFeedback", "react-native")>] static member TouchableWithoutFeedback with get(): TouchableWithoutFeedbackStatic = jsNative and set(v: TouchableWithoutFeedbackStatic): unit = jsNative
        [<Import("View", "react-native")>] static member View with get(): ViewStatic = jsNative and set(v: ViewStatic): unit = jsNative
        [<Import("ViewPagerAndroid", "react-native")>] static member ViewPagerAndroid with get(): ViewPagerAndroidStatic = jsNative and set(v: ViewPagerAndroidStatic): unit = jsNative
        [<Import("WebView", "react-native")>] static member WebView with get(): WebViewStatic = jsNative and set(v: WebViewStatic): unit = jsNative
        [<Import("ActionSheetIOS", "react-native")>] static member ActionSheetIOS with get(): ActionSheetIOSStatic = jsNative and set(v: ActionSheetIOSStatic): unit = jsNative
        [<Import("AdSupportIOS", "react-native")>] static member AdSupportIOS with get(): AdSupportIOSStatic = jsNative and set(v: AdSupportIOSStatic): unit = jsNative
        [<Import("Alert", "react-native")>] static member Alert with get(): AlertStatic = jsNative and set(v: AlertStatic): unit = jsNative
        [<Import("AlertIOS", "react-native")>] static member AlertIOS with get(): AlertIOSStatic = jsNative and set(v: AlertIOSStatic): unit = jsNative
        [<Import("AppState", "react-native")>] static member AppState with get(): AppStateStatic = jsNative and set(v: AppStateStatic): unit = jsNative
        [<Import("AppStateIOS", "react-native")>] static member AppStateIOS with get(): AppStateStatic = jsNative and set(v: AppStateStatic): unit = jsNative
        [<Import("AsyncStorage", "react-native")>] static member AsyncStorage with get(): AsyncStorageStatic = jsNative and set(v: AsyncStorageStatic): unit = jsNative
        [<Import("BackAndroid", "react-native")>] static member BackAndroid with get(): BackAndroidStatic = jsNative and set(v: BackAndroidStatic): unit = jsNative
        [<Import("CameraRoll", "react-native")>] static member CameraRoll with get(): CameraRollStatic = jsNative and set(v: CameraRollStatic): unit = jsNative
        [<Import("Clipboard", "react-native")>] static member Clipboard with get(): ClipboardStatic = jsNative and set(v: ClipboardStatic): unit = jsNative
        [<Import("DatePickerAndroid", "react-native")>] static member DatePickerAndroid with get(): DatePickerAndroidStatic = jsNative and set(v: DatePickerAndroidStatic): unit = jsNative
        [<Import("IntentAndroid", "react-native")>] static member IntentAndroid with get(): IntentAndroidStatic = jsNative and set(v: IntentAndroidStatic): unit = jsNative
        [<Import("KeyboardAvoidingView", "react-native")>] static member KeyboardAvoidingView with get(): KeyboardAvoidingViewStatic = jsNative and set(v: KeyboardAvoidingViewStatic): unit = jsNative
        [<Import("Linking", "react-native")>] static member Linking with get(): LinkingStatic = jsNative and set(v: LinkingStatic): unit = jsNative
        [<Import("LinkingIOS", "react-native")>] static member LinkingIOS with get(): LinkingIOSStatic = jsNative and set(v: LinkingIOSStatic): unit = jsNative
        [<Import("NetInfo", "react-native")>] static member NetInfo with get(): NetInfoStatic = jsNative and set(v: NetInfoStatic): unit = jsNative
        [<Import("PanResponder", "react-native")>] static member PanResponder with get(): PanResponderStatic = jsNative and set(v: PanResponderStatic): unit = jsNative
        [<Import("PushNotificationIOS", "react-native")>] static member PushNotificationIOS with get(): PushNotificationIOSStatic = jsNative and set(v: PushNotificationIOSStatic): unit = jsNative
        [<Import("StatusBarIOS", "react-native")>] static member StatusBarIOS with get(): StatusBarIOSStatic = jsNative and set(v: StatusBarIOSStatic): unit = jsNative
        [<Import("TimePickerAndroid", "react-native")>] static member TimePickerAndroid with get(): TimePickerAndroidStatic = jsNative and set(v: TimePickerAndroidStatic): unit = jsNative
        [<Import("ToastAndroid", "react-native")>] static member ToastAndroid with get(): ToastAndroidStatic = jsNative and set(v: ToastAndroidStatic): unit = jsNative
        [<Import("VibrationIOS", "react-native")>] static member VibrationIOS with get(): VibrationIOSStatic = jsNative and set(v: VibrationIOSStatic): unit = jsNative
        [<Import("Vibration", "react-native")>] static member Vibration with get(): VibrationStatic = jsNative and set(v: VibrationStatic): unit = jsNative
        [<Import("Dimensions", "react-native")>] static member Dimensions with get(): Dimensions = jsNative and set(v: Dimensions): unit = jsNative
        [<Import("ShadowPropTypesIOS", "react-native")>] static member ShadowPropTypesIOS with get(): ShadowPropTypesIOSStatic = jsNative and set(v: ShadowPropTypesIOSStatic): unit = jsNative
        [<Import("NavigationExperimental", "react-native")>] static member NavigationExperimental with get(): NavigationExperimentalStatic = jsNative and set(v: NavigationExperimentalStatic): unit = jsNative
        [<Import("NavigationContainer", "react-native")>] static member NavigationContainer with get(): NavigationContainerStatic = jsNative and set(v: NavigationContainerStatic): unit = jsNative
        [<Import("NavigationRootContainer", "react-native")>] static member NavigationRootContainer with get(): NavigationRootContainerStatic = jsNative and set(v: NavigationRootContainerStatic): unit = jsNative
        [<Import("NavigationReducer", "react-native")>] static member NavigationReducer with get(): NavigationReducerStatic = jsNative and set(v: NavigationReducerStatic): unit = jsNative
        [<Import("Easing", "react-native")>] static member Easing with get(): EasingStatic = jsNative and set(v: EasingStatic): unit = jsNative
        [<Import("NativeModules", "react-native")>] static member NativeModules with get(): obj = jsNative and set(v: obj): unit = jsNative
        [<Import("NativeAppEventEmitter", "react-native")>] static member NativeAppEventEmitter with get(): NativeAppEventEmitterStatic = jsNative and set(v: NativeAppEventEmitterStatic): unit = jsNative
        [<Import("SegmentedControlIOS", "react-native")>] static member SegmentedControlIOS with get(): SegmentedControlIOSStatic = jsNative and set(v: SegmentedControlIOSStatic): unit = jsNative
        [<Import("PixelRatio", "react-native")>] static member PixelRatio with get(): PixelRatioStatic = jsNative and set(v: PixelRatioStatic): unit = jsNative
        [<Import("Platform", "react-native")>] static member Platform with get(): PlatformStatic = jsNative and set(v: PlatformStatic): unit = jsNative
        [<Import("DeviceEventEmitter", "react-native")>] static member DeviceEventEmitter with get(): DeviceEventEmitterStatic = jsNative and set(v: DeviceEventEmitterStatic): unit = jsNative
        [<Import("DeviceEventSubscription", "react-native")>] static member DeviceEventSubscription with get(): DeviceEventSubscriptionStatic = jsNative and set(v: DeviceEventSubscriptionStatic): unit = jsNative
        [<Import("InteractionManager", "react-native")>] static member InteractionManager with get(): InteractionManagerStatic = jsNative and set(v: InteractionManagerStatic): unit = jsNative
        [<Import("Geolocation", "react-native")>] static member Geolocation with get(): GeolocationStatic = jsNative and set(v: GeolocationStatic): unit = jsNative
        [<Import("createElement", "react-native")>] static member createElement(``type``: React.ReactType, props: 'P, [<ParamArray>] children: React.ReactNode[]): React.ReactElement = jsNative
        [<Import("requireNativeComponent", "react-native")>] static member requireNativeComponent(viewName: string, ?componentInterface: ComponentInterface<'P>, ?extraConfig: obj): React.ComponentClass<'P> = jsNative
        [<Import("___spread", "react-native")>] static member ___spread(target: obj, [<ParamArray>] sources: obj[]): obj = jsNative

    module addons =
        type TestModuleStatic =
            abstract verifySnapshot: ((obj -> unit) -> unit) with get, set
            abstract markTestPassed: (obj -> unit) with get, set
            abstract markTestCompleted: (unit -> unit) with get, set

        and TestModule =
            TestModuleStatic

        type [<Import("addons","react-native")>] Globals =
            static member TestModule with get(): TestModuleStatic = jsNative and set(v: TestModuleStatic): unit = jsNative
