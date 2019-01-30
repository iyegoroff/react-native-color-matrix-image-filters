#!/usr/bin/env python

from pbxproj import XcodeProject

def patch_pbxproj(path, targets):
  project = XcodeProject.load(path)
  build_files = project.objects.get_objects_in_section('PBXBuildFile')
  for build_file in build_files:
    if 'fileRef' not in build_file:
      del project.objects[build_file.get_id()]
  for target in targets:
    project.add_flags('PRODUCT_MODULE_NAME', target, target)
  project.save()

patch_pbxproj(
  'node_modules/react-native/React/React.xcodeproj/project.pbxproj',
  ['React-tvOS', 'yoga-tvOS', 'cxxreact-tvOS', 'jsinspector-tvOS', 'third-party', 'double-conversion', 'jsi-tvOS', 'jsiexecutor-tvOS']
)

patch_pbxproj(
  'node_modules/react-native/Libraries/NativeAnimation/RCTAnimation.xcodeproj/project.pbxproj',
  ['RCTAnimation-tvOS']
)

patch_pbxproj(
  'node_modules/react-native/Libraries/Blob/RCTBlob.xcodeproj/project.pbxproj',
  ['RCTBlob-tvOS']
)

patch_pbxproj(
  'node_modules/react-native/Libraries/Image/RCTImage.xcodeproj/project.pbxproj',
  ['RCTImage-tvOS']
)

patch_pbxproj(
  'node_modules/react-native/Libraries/LinkingIOS/RCTLinking.xcodeproj/project.pbxproj',
  ['RCTLinking-tvOS']
)

patch_pbxproj(
  'node_modules/react-native/Libraries/Network/RCTNetwork.xcodeproj/project.pbxproj',
  ['RCTNetwork-tvOS']
)

patch_pbxproj(
  'node_modules/react-native/Libraries/Settings/RCTSettings.xcodeproj/project.pbxproj',
  ['RCTSettings-tvOS']
)

patch_pbxproj(
  'node_modules/react-native/Libraries/Text/RCTText.xcodeproj/project.pbxproj',
  ['RCTText-tvOS']
)

patch_pbxproj(
  'node_modules/react-native/Libraries/WebSocket/RCTWebSocket.xcodeproj/project.pbxproj',
  ['RCTWebSocket-tvOS', 'fishhook-tvOS']
)
