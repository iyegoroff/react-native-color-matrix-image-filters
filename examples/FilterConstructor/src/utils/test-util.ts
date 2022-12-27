type Hook<State, Actions> = { readonly result: { readonly current: readonly [State, Actions] } }

const getState = <State, Actions>(hook: Hook<State, Actions>) => hook.result.current[0]

const getActions = <State, Actions>(hook: Hook<State, Actions>) => hook.result.current[1]

const delay = (ms: number) => new Promise<void>((resolve) => setTimeout(resolve, ms))

export const TestUtil = { getState, getActions, delay } as const
