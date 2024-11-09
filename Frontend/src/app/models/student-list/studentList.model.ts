import { Student } from "../student.model";

export class StudentList {

    constructor(students: Array<Student>) {
        this.students = students;
    }

    students: Array<Student>;
}