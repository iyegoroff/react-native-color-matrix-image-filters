import { errorMessage } from '.'

describe('error-message', () => {
  test('should return message from Error instance', () => {
    expect(errorMessage(new Error('message!'))).toEqual('message!')
  })

  test('should convert value to string unless it is an Error', () => {
    expect(errorMessage(123)).toEqual('123')
  })
})
