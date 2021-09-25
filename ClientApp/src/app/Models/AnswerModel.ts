export class AnswerModel {
    id:number;
    answerText:string;
    isSurvey:boolean;
    isRightAnswer?:boolean;
    questionId:number;
}