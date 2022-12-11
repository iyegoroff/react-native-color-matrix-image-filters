import React, { StrictMode } from 'react'
import { FlatList, SafeAreaView, View } from 'react-native'
import { useBacklash } from 'react-use-backlash'
import { usePipe } from 'use-pipe-ts'
import { Button } from '../button'
import { Gap } from '../gap'
import { SegmentedLabelControl } from '../segmented-control'
import { SelectModal } from '../select-modal'
import { init, updates } from './state'
import { styles } from './styles'
import { renderFilterControl } from './render-filter-control'
import { concatColorMatrices, normal } from 'react-native-color-matrix-image-filters'
import { ImagePicker } from '../../services'
import { Filters, resizeModes } from '../../domain'
import { FilteredImage } from './FilteredImage'

declare const require: (name: string) => number

const { filters: availableFilters, matrix } = Filters

const injects = { ...ImagePicker }

const defaultImage = require('../../../mini-parrot.jpg')

const Separator = () => <Gap size={5} />

const Root = () => {
  const [
    { selectedResizeMode, isAddingFilter, filters, image },
    {
      selectResizeMode,
      startAddFilter,
      cancelAddFilter,
      confirmAddFilter,
      updateFilter,
      removeFilter,
      moveFilterDown,
      moveFilterUp,
      takePhoto
    }
  ] = useBacklash(() => init(defaultImage), updates, injects)

  const renderFilter = usePipe([
    renderFilterControl,
    updateFilter,
    removeFilter,
    moveFilterUp,
    moveFilterDown,
    filters.length
  ])

  const takePhotoFromCamera = usePipe([takePhoto, 'camera'])
  const pickPhotoFromLibrary = usePipe([takePhoto, 'library'])
  const calculatedMatrix = concatColorMatrices(normal(), ...filters.map(matrix))

  return (
    <SafeAreaView style={styles.container}>
      <FilteredImage
        style={styles.image}
        matrix={calculatedMatrix}
        image={image}
        resizeMode={selectedResizeMode}
      />
      <Gap size={5} />
      <SegmentedLabelControl
        items={resizeModes}
        selectedItem={selectedResizeMode}
        onSelect={selectResizeMode}
      />
      <Gap size={5} />
      <View style={styles.pickerControls}>
        <Button label={'take photo'} onPress={takePhotoFromCamera} />
        <Gap size={5} />
        <Button label={'pick photo'} onPress={pickPhotoFromLibrary} />
      </View>
      <Gap size={5} />
      <FlatList
        style={styles.filterControlList}
        data={filters}
        renderItem={renderFilter}
        ItemSeparatorComponent={Separator}
        ListFooterComponent={
          <>
            <Separator />
            <Button label={'add filter'} onPress={startAddFilter} />
          </>
        }
      />
      <SelectModal
        isVisible={isAddingFilter}
        options={availableFilters}
        onClose={cancelAddFilter}
        onSelect={confirmAddFilter}
      />
    </SafeAreaView>
  )
}

export const App = () => (
  <StrictMode>
    <Root />
  </StrictMode>
)
