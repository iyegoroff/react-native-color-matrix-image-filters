import { Command, UpdateMap } from 'react-use-backlash'
import { swap, shallowEqual } from '../../../utils'
import { Filter } from '../../../domain'

export type Id = `${number}`

export type KeyedFilter = Filter & { id: Id }

type State = {
  isAddingFilter: boolean
  filters: readonly KeyedFilter[]
  nextId: number
}

type Actions = {
  startAddFilter: []
  confirmAddFilter: [filter: Filter]
  cancelAddFilter: []
  removeFilter: [id: Id]
  updateFilter: [id: Id, filter: Filter]
  moveFilterUp: [id: Id]
  moveFilterDown: [id: Id]
}

const init = (): Command<State, Actions> => [
  {
    isAddingFilter: false,
    filters: [],
    nextId: 0
  }
]

const updates: UpdateMap<State, Actions> = {
  startAddFilter: (state) => [{ ...state, isAddingFilter: true }],

  confirmAddFilter: ({ filters, nextId, ...state }, filter) => [
    {
      ...state,
      filters: [...filters, { ...filter, id: `${nextId}` }],
      nextId: nextId + 1,
      isAddingFilter: false
    }
  ],

  cancelAddFilter: (state) => [{ ...state, isAddingFilter: false }],

  removeFilter: (state, id) => {
    const { filters } = state

    return filters.find((f) => f.id === id) === undefined
      ? [state]
      : [{ ...state, filters: filters.filter((f) => f.id !== id) }]
  },

  moveFilterDown: (state, id) => {
    const { filters } = state
    const index = filters.findIndex((f) => f.id === id)
    const nextFilters = swap(filters, index, index + 1)

    return nextFilters === filters ? [state] : [{ ...state, filters: nextFilters }]
  },

  moveFilterUp: (state, id) => {
    const { filters } = state
    const index = filters.findIndex((f) => f.id === id)
    const nextFilters = swap(filters, index - 1, index)

    return nextFilters === filters ? [state] : [{ ...state, filters: nextFilters }]
  },

  updateFilter: (state, id, filter) => {
    const { filters } = state
    const index = filters.findIndex((f) => f.id === id)
    const nextFilter = { ...filter, id }
    const prevFilter = filters[index]

    if (prevFilter === undefined || shallowEqual(prevFilter, nextFilter)) {
      return [state]
    }

    const nextFilters = [...filters]
    nextFilters[index] = nextFilter

    return [{ ...state, filters: nextFilters }]
  }
}

export const FilterSelection = { init, updates } as const
