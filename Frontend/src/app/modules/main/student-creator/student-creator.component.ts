import { Component } from '@angular/core';
import { StudentFormGroup } from '../../../constants/form.entities';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { StudentService } from '../../../services/student.service';
import { PostStudentRequest } from '../../../models/request/post-student.request';

@Component({
  selector: 'student-creator',
  templateUrl: './student-creator.component.html',
  styleUrl: './student-creator.component.scss'
})
export class StudentCreatorComponent {
  
  public studentFormGroup: StudentFormGroup = new FormGroup({
    name: new FormControl<string>('', {validators: [Validators.required], nonNullable: true}),
    semester: new FormControl<number>(1, {validators: [Validators.required], nonNullable: true}),
    birthday: new FormControl<Date | null>(null, [Validators.required]),
    mobileNumber: new FormControl<string>('', {validators: [Validators.required], nonNullable: true}),
  });

  public isCreating: boolean = false;

  public isCreationSuccess: boolean = true;

  public isInvalidData: boolean = false;
  
  constructor(private studentService: StudentService) {}

  public createStudent() {
    if(this.studentFormGroup.valid) {
      this.isCreating = true;
      this.isInvalidData = false;

      this.studentService.postStudent(new PostStudentRequest(
        this.studentFormGroup.controls.name.value,
        this.studentFormGroup.controls.semester.value,
        this.studentFormGroup.controls.birthday.value!,
        this.studentFormGroup.controls.mobileNumber.value,
      ))
      .subscribe(res => {
        if(res)
          this.isCreationSuccess = true;
        else
          this.isCreationSuccess = false;

        this.isCreating = false;
      });
    }
    else {
      this.isInvalidData = true;
    }
  }
}
