import React from 'react'
import { ListRenderItemInfo } from 'react-native'
import { usePipe } from 'use-pipe-ts'
import { Filter } from '../../domain'
import { FilterControl } from '../filter-control'
import { Id, KeyedFilter } from './filter-selection'

type OnUpdate = (id: Id, filter: Filter) => void
type OnListAction = (id: Id) => void

const FilterControlListItem = React.memo(function FilterControlListItem({
  onUpdate,
  onRemove,
  onMoveDown,
  onMoveUp,
  id,
  isFirst,
  isLast,
  ...filter
}: KeyedFilter & {
  isFirst: boolean
  isLast: boolean
  onUpdate: OnUpdate
  onRemove: OnListAction
  onMoveUp: OnListAction
  onMoveDown: OnListAction
}) {
  const updateFilter = usePipe([onUpdate, id])
  const removeFilter = usePipe([onRemove, id])
  const moveFilterUp = usePipe([onMoveUp, id])
  const moveFilterDown = usePipe([onMoveDown, id])

  return (
    <FilterControl
      update={updateFilter}
      remove={removeFilter}
      moveUp={isFirst ? undefined : moveFilterUp}
      moveDown={isLast ? undefined : moveFilterDown}
      {...filter}
    />
  )
})

export const renderFilterControl = (
  onUpdate: OnUpdate,
  onRemove: OnListAction,
  onMoveUp: OnListAction,
  onMoveDown: OnListAction,
  filtersListLength: number,
  { item: filter, index }: ListRenderItemInfo<KeyedFilter>
) => (
  <FilterControlListItem
    key={`${filter.id}-${index}`}
    isFirst={index === 0}
    isLast={index === filtersListLength - 1}
    onUpdate={onUpdate}
    onRemove={onRemove}
    onMoveDown={onMoveDown}
    onMoveUp={onMoveUp}
    {...filter}
  />
)
