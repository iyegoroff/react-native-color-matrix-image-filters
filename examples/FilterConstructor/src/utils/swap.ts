export const swap = <T>(
  items: ReadonlyArray<NonNullable<T>>,
  firstIndex: number,
  secondIndex: number
) => {
  const first = items[firstIndex]
  const second = items[secondIndex]

  if (first === undefined || second === undefined) {
    return items
  }

  const next = [...items]
  next[firstIndex] = second
  next[secondIndex] = first

  return next
}
