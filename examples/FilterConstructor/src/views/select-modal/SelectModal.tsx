import React from 'react'
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

const Separator = () => <Gap size={5} />

export const SelectModal = memo(function SelectModal<Option extends OptionShape>({
  isVisible,
  onClose,
  onSelect,
  options
}: Props<Option>) {
  const renderItem = usePipe([renderOption<Option>, onSelect])

  return (
    <Modal animationType={'slide'} onRequestClose={onClose} visible={isVisible}>
      <SafeAreaView>
        <FlatList
          style={styles.optionList}
          data={options}
          renderItem={renderItem}
          ItemSeparatorComponent={Separator}
        />
        <TouchableOpacity style={styles.close} onPress={onClose}>
          <Text style={styles.closeLabel}>❎</Text>
        </TouchableOpacity>
      </SafeAreaView>
    </Modal>
  )
})
