import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
import { PostStudentRequest } from '../models/request/postStudentRequest.model';
import { API_BASE } from '../constants/api';
import { PostGradeRequest } from '../models/request/postGradeRequest.model';
import { StudentList } from '../models/student-list/studentList.model';
import { StudentStatisticsList } from '../models/student-list/studentStatisticsList.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  /** The list of students */
  private _students: StudentList = new StudentList([]);

  /** The list of student statistics */
  private _studentStatistics: StudentStatisticsList = new StudentStatisticsList([]);

  constructor(private http: HttpClient) { }

  public postStudent(student: PostStudentRequest): Observable<boolean> {
    return this.http.post(API_BASE + 'Student', student, {observe: 'response'})
    .pipe(
      map(r => r.ok),
      catchError(() => of(false)),
    );
  }

  public postGrade(grade: PostGradeRequest): Observable<boolean> {
    return this.http.post(API_BASE + 'Student/Grade', grade, {observe: 'response'})
    .pipe(
      map(r => r.ok),
      catchError(() => of(false)),
    );
  }

  public getStudentList(): Observable<StudentList | null> {
    return this.http.get<StudentList>(API_BASE + 'Student/List', {observe: 'response'})
    .pipe(
      map(r => r.body),
      catchError(() => of(null))
    );
  }

  public getStudentStatistics(): Observable<StudentStatisticsList | null> {
    return this.http.get<StudentStatisticsList>(API_BASE + 'Student/List/Statistics', {observe: 'response'})
    .pipe(
      map(r => r.body),
      catchError(() => of(null))
    );
  }
}
