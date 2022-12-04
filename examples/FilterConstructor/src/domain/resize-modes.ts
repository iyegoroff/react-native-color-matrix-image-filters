const resizeModes = ['center', 'contain', 'cover', 'repeat', 'stretch'] as const

export type ResizeMode = typeof resizeModes[number]

export const ResizeModes = {
  resizeModes
} as const
