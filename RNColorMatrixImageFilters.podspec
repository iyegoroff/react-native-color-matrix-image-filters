require 'json'
package_json = JSON.parse(File.read('package.json'))

Pod::Spec.new do |s|
  s.name         = "RNColorMatrixImageFilters"
  s.version      = package_json["version"]
  s.summary      = package_json["description"]
  s.homepage     = "https://github.com/iyegoroff/react-native-color-matrix-image-filters"
  s.license      = "MIT"
  s.author       = { "author" => "author@domain.cn" }
  s.platform     = :ios, "9.0"
  s.source       = { :git => "https://github.com/author/RNColorMatrixImageFilters.git", :tag => "master" }
  s.source_files  = "ios/*.{h,m}"
  s.requires_arc = true

  s.dependency "React"
end

  