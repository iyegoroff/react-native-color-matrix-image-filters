import React from 'react'
import { memo } from 'ts-react-memo'
import { usePipe } from 'use-pipe-ts'
import { Button } from '../button'
import { OptionShape } from './types'

type Props<Option extends OptionShape> = {
  readonly option: Option
  readonly onSelect: (option: Option) => void
}

export const SelectOption = memo(function SelectOption<Option extends OptionShape>({
  option,
  onSelect
}: Props<Option>) {
  const select = usePipe([onSelect, option])

  return <Button onPress={select} label={option.tag} />
})
