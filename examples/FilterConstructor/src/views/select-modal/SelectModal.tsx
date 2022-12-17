import React, { ComponentProps } from 'react'
import {
  Modal,
  FlatList,
  ListRenderItemInfo,
  TouchableOpacity,
  Text,
  SafeAreaView
} from 'react-native'
import { memo } from 'ts-react-memo'
import { usePipe } from 'use-pipe-ts'
import { Gap } from '../gap'
import { theme } from '../theme'
import { SelectOption } from './SelectOption'
import { styles } from './styles'
import { OptionShape } from './types'

type Props<Option extends OptionShape> = {
  readonly isVisible: boolean
  readonly onClose: () => void
  readonly onSelect: (option: Option) => void
  readonly options: readonly Option[]
}

const renderOption = <Option extends OptionShape>(
  onSelect: Props<Option>['onSelect'],
  { item }: ListRenderItemInfo<Option>
) => <SelectOption<Option> onSelect={onSelect} key={item.tag} option={item} />

const gap = 5

const Separator = () => <Gap size={gap} />

const getButtonLayout: ComponentProps<typeof FlatList>['getItemLayout'] = (_, index) => ({
  length: theme.controlHeight,
  offset: (theme.controlHeight + gap) * index,
  index
})

export const SelectModal = memo(function SelectModal<Option extends OptionShape>({
  isVisible,
  onClose,
  onSelect,
  options
}: Props<Option>) {
  const renderItem = usePipe([renderOption<Option>, onSelect])

  return (
    <Modal
      animationType={'slide'}
      onRequestClose={onClose}
      visible={isVisible}
      statusBarTranslucent={true}
    >
      <SafeAreaView>
        <FlatList
          getItemLayout={getButtonLayout}
          style={styles.optionList}
          data={options}
          renderItem={renderItem}
          ItemSeparatorComponent={Separator}
          ListFooterComponent={Separator}
          ListHeaderComponent={Separator}
        />
        <TouchableOpacity style={styles.close} onPress={onClose}>
          <Text style={styles.closeLabel}>❎</Text>
        </TouchableOpacity>
      </SafeAreaView>
    </Modal>
  )
})
