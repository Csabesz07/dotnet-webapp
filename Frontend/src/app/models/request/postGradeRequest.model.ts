import { Grade } from "../../enums/grade.enum";

export class PostGradeRequest {

    constructor(studentId: number, subjectId: number, grade: Grade)
    {
        this.studentId = studentId;
        this.subjectId = subjectId;
        this.grade = grade;
    }

    public studentId: number;
    public subjectId: number;
    public grade: Grade;
}