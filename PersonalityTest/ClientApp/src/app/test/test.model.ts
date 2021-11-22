export interface Question {
  text: string,
  options: Option[]
  value: number
}

export interface Option {
  text: string,
  value: number
}

export interface TestModel {
  name: string,
  questions: Question[]
}
