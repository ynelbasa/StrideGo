export interface Question {
  id: number;
  text: string;
  askedBy: string;
  answerCount: number;
  isEditing?: boolean;
}
