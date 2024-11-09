import { Component } from '@angular/core';
import { StudentService } from '../../../services/student.service';

@Component({
  selector: 'student-statistics',
  templateUrl: './student-statistics.component.html',
  styleUrl: './student-statistics.component.scss'
})
export class StudentStatisticsComponent {
  
  public isRefreshing: boolean = false;

  constructor(public studentService: StudentService) {}

  public refresh(): void {
    this.isRefreshing = true;
    this.studentService.getStudentStatisticsList()
    .subscribe(() => {
      this.isRefreshing = false;
    });
  }
}
