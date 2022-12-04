import React, { useCallback } from 'react'
import { Domain } from '../../domain'
import { AmountFilter } from '../../domain/types'
import { SliderControl } from '../slider-control'

type Props = AmountFilter & {
  update: (filter: AmountFilter) => void
}

export const AmountFilterControl = React.memo(function AmountFilterControl({
  amount,
  tag,
  update
}: Props) {
  const onChange = useCallback(
    (value: number) => {
      update({ tag, amount: value })
    },
    [update, tag]
  )

  const { amount: minMax } = Domain.Filters.filterControlConstraints[tag]

  return <SliderControl {...minMax} name={'amount'} value={amount} onChange={onChange} />
})
