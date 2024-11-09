import { Component } from '@angular/core';
import { StudentService } from '../../../services/student.service';

@Component({
  selector: 'student-list',
  templateUrl: './student-list.component.html',
  styleUrl: './student-list.component.scss'
})
export class StudentListComponent {

  public isRefreshing: boolean = false;

  constructor(public studentService: StudentService) {}

  public refresh(): void {
    this.isRefreshing = true;
    this.studentService.getStudentList()
    .subscribe(() => {
      this.isRefreshing = false;
    });
  }
}
