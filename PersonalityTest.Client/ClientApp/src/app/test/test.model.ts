export interface Question {
  id: string,
  text: string,
  options: Option[],
  value: number
}

export interface Option {
  id: string,
  questionId: string
  text: string,
  value: number
}

export interface TestRequest {
  id: string,
  name: string,
  questions: Question[],
  isValid: boolean
}

export interface TestResponse {
  name: string,
  personality: string
}
