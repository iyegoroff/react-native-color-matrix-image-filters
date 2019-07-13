require 'json'

package = JSON.parse(File.read(File.join(__dir__, 'package.json')))

Pod::Spec.new do |s|
  s.name         = 'RNColorMatrixImageFilters'
  s.version      = package['version']
  s.summary      = package['description']
  s.homepage     = package['homepage']
  s.license      = package['license']
  s.author       = package['author']
  s.platform     = :ios, '9.0'
  s.source       = { :git => 'https://github.com/iyegoroff/react-native-color-matrix-image-filters.git', :tag => 'v#{s.version}' }
  s.source_files = 'ios/*.{h,m}'
  s.requires_arc = true

  s.dependency 'React'
end
