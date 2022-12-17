import React, { StrictMode } from 'react'
import { FlatList, Modal, SafeAreaView, StatusBar, TouchableOpacity, View } from 'react-native'
import { useBacklash } from 'react-use-backlash'
import { usePipe } from 'use-pipe-ts'
import { Button } from '../button'
import { Gap } from '../gap'
import { SegmentedLabelControl } from '../segmented-control'
import { SelectModal } from '../select-modal'
import { FilterSelection } from './filter-selection'
import { ImageSelection } from './image-selection'
import { styles } from './styles'
import { renderFilterControl } from './render-filter-control'
import { ImagePicker, Alert } from '../../services'
import { Filters, resizeModes } from '../../domain'
import { FilteredImage } from './FilteredImage'
import memoizeOne from 'memoize-one'

declare const require: (name: string) => number

const { filters: availableFilters, matrix } = Filters

const injects = { ...ImagePicker, ...Alert }

const defaultImage = require('../../../mini-parrot.jpg')

const Separator = () => <Gap size={5} />

const calculateMatrix = memoizeOne(matrix)

const Root = () => {
  const [
    { isAddingFilter, filters },
    {
      startAddFilter,
      cancelAddFilter,
      confirmAddFilter,
      updateFilter,
      removeFilter,
      moveFilterDown,
      moveFilterUp
    }
  ] = useBacklash(FilterSelection.init, FilterSelection.updates)

  const [
    { selectedResizeMode, image, isFullScreen },
    {
      selectResizeMode,
      takePhotoFromCamera,
      pickPhotoFromLibrary,
      enterFullScreen,
      leaveFullScreen
    }
  ] = useBacklash(() => ImageSelection.init(defaultImage), ImageSelection.updates, injects)

  const renderFilter = usePipe([
    renderFilterControl,
    updateFilter,
    removeFilter,
    moveFilterUp,
    moveFilterDown,
    filters.length
  ])

  const calculatedMatrix = calculateMatrix(filters)

  return (
    <SafeAreaView style={styles.container}>
      <StatusBar hidden={true} />
      <TouchableOpacity style={{ width: '100%' }} onPress={enterFullScreen}>
        <FilteredImage
          style={styles.image}
          matrix={calculatedMatrix}
          image={image}
          resizeMode={selectedResizeMode}
        />
      </TouchableOpacity>
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
      <Modal
        visible={isFullScreen}
        transparent={true}
        style={styles.fullscreenImage}
        animationType={'slide'}
        statusBarTranslucent={true}
      >
        <View style={styles.modalOverlay}>
          <TouchableOpacity style={styles.frame} onPress={leaveFullScreen}>
            <FilteredImage
              style={styles.fullscreenImage}
              matrix={calculatedMatrix}
              image={image}
              resizeMode={selectedResizeMode}
            />
          </TouchableOpacity>
        </View>
      </Modal>
    </SafeAreaView>
  )
}

export const App = () => (
  <StrictMode>
    <Root />
  </StrictMode>
)
