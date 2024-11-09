import { Component } from '@angular/core';
import { StudentFormGroup } from '../../../constants/form.entities';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { StudentService } from '../../../services/student.service';
import { PostStudentRequest } from '../../../models/request/postStudentRequest.model';

@Component({
  selector: 'student-creator',
  templateUrl: './student-creator.component.html',
  styleUrl: './student-creator.component.scss'
})
export class StudentCreatorComponent {
  
  public studentFormGroup: StudentFormGroup = new FormGroup({
    name: new FormControl<string>('', {validators: [Validators.required], nonNullable: true}),
    semester: new FormControl<number>(1, {validators: [Validators.required], nonNullable: true}),
    birthday: new FormControl<Date>(new Date(Date.now()), {validators: [Validators.required], nonNullable: true}),
    mobileNumber: new FormControl<string>('', {validators: [Validators.required], nonNullable: true}),
  });
  
  constructor(private studentService: StudentService) {}

  public createStudent() {
    if(this.studentFormGroup.valid) {
      this.studentService.postStudent(new PostStudentRequest(
        this.studentFormGroup.controls.name.value,
        this.studentFormGroup.controls.semester.value,
        this.studentFormGroup.controls.birthday.value,
        this.studentFormGroup.controls.mobileNumber.value,
      ))
      .subscribe(res => {

      });
    }
    else {
      
    }
  }
}
