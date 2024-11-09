import { StudentStatistics } from "../studentStatistics.model";

export class StudentStatisticsList {

    constructor(students: Array<StudentStatistics>) {
        this.students = students;
    }

    students: Array<StudentStatistics>
}