import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
import { PostStudentRequest } from '../models/request/postStudentRequest.model';
import { API_BASE } from '../constants/api';
import { PostGradeRequest } from '../models/request/postGradeRequest.model';
import { StudentList } from '../models/student-list/studentList.model';
import { StudentStatisticsList } from '../models/student-list/studentStatisticsList.model';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  /** The list of students */
  private _studentList: StudentList = new StudentList([]);
  public get studentList() {
    return this._studentList.students;
  }

  /** The list of student statistics */
  private _studentStatisticList: StudentStatisticsList = new StudentStatisticsList([]);
  public get studentStatisticList() {
    return this._studentStatisticList.students;
  }

  constructor(private http: HttpClient) { }

  public postStudent(student: PostStudentRequest): Observable<boolean> {
    return this.http.post<number>(API_BASE + 'Student', student, {observe: 'response'})
    .pipe(
      map(r => {
        if(r.ok)
        {
          this._studentList.students.push(
            new Student(r.body!, student.name, student.semester, student.birthday, student.mobileNumber)
          );

          this.sortStudentList();
        }

        return r.ok;
      }),
      catchError(() => of(false)),
    );
  }

  public postGrade(grade: PostGradeRequest): Observable<boolean> {
    return this.http.post(API_BASE + 'Student/Grade', grade, {observe: 'response'})
    .pipe(
      map(r => {
        if(r.ok)
          this.getStudentStatisticsList();

        return r.ok;
      }),
      catchError(() => of(false)),
    );
  }

  public getStudentList(): Observable<StudentList | null> {
    return this.http.get<StudentList>(API_BASE + 'Student/List', {observe: 'response'})
    .pipe(
      map(r => {
        this._studentList.students = r.body?.students ?? [];
        return this._studentList;
      }),
      catchError(() => of(null))
    );
  }

  public getStudentStatisticsList(): Observable<StudentStatisticsList | null> {
    return this.http.get<StudentStatisticsList>(API_BASE + 'Student/List/Statistics', {observe: 'response'})
    .pipe(
      map(r => {
        this._studentStatisticList.students = r.body?.students ?? [];
        return this._studentStatisticList;
      }),
      catchError(() => of(null))
    );
  }

  private sortStudentList(): void {
    this._studentList.students.sort((a, b) => a.name.localeCompare(b.name));
  }  
}
