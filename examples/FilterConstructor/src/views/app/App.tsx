import React, { StrictMode } from 'react'
import { FlatList, Image, SafeAreaView } from 'react-native'
import { useBacklash } from 'react-use-backlash'
import { usePipe } from 'use-pipe-ts'
import { Button } from '../button'
import { Gap } from '../gap'
import { SegmentedLabelControl } from '../segmented-control'
import { SelectModal } from '../select-modal'
import { init, updates } from './state'
import { styles } from './styles'
import { renderFilterControl } from './render-filter-control'
import { ColorMatrix, concatColorMatrices, normal } from 'react-native-color-matrix-image-filters'
import { Services } from '../../services'
import { Domain } from '../../domain'

declare const require: (name: string) => number

const {
  Filters: { filters: availableFilters, matrix },
  ResizeModes: { resizeModes }
} = Domain

const injects = { takePhoto: Services.ImagePicker.takePhoto }

const defaultImage = require('../../mini-parrot.jpg')

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

  return (
    <SafeAreaView style={styles.container}>
      <ColorMatrix
        style={styles.image}
        matrix={concatColorMatrices(normal(), ...filters.map(matrix))}
      >
        <Image
          source={'static' in image ? image.static : image}
          style={styles.image}
          resizeMode={selectedResizeMode}
          key={selectedResizeMode}
        />
      </ColorMatrix>
      <Gap size={5} />
      <SegmentedLabelControl
        items={resizeModes}
        selectedItem={selectedResizeMode}
        onSelect={selectResizeMode}
      />
      <Gap size={5} />
      <Button label={'take photo'} onPress={takePhoto} />
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
