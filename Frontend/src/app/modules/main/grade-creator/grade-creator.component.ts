import { ChangeDetectorRef, Component } from '@angular/core';
import { Grade } from '../../../enums/grade.enum';
import { Subject } from '../../../enums/subject.enum';
import { GradeFormGroup } from '../../../constants/form.entities';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { StudentService } from '../../../services/student.service';
import { PostGradeRequest } from '../../../models/request/post-grade.request';

@Component({
  selector: 'grade-creator',
  templateUrl: './grade-creator.component.html',
  styleUrl: './grade-creator.component.scss'
})
export class GradeCreatorComponent {

  constructor(public studentServcie: StudentService) {}

  /** Created in order to eliminate the magic numbers in the html template */
  public grade = Grade;

  /** Created in order to eliminate the magic numbers in the html template */
  public subject = Subject;

  public isCreating: boolean = false;

  public isCreationSuccess: boolean = true;

  public isInvalidData: boolean = false;

  public gradeFormGroup: GradeFormGroup = new FormGroup({
    studentId: new FormControl<number | null>(null, [Validators.required]),
    subjectId: new FormControl<number | null>(null, [Validators.required]),
    grade: new FormControl<number | null>(null, [Validators.required]),
  });

  public assignGrade() {
    if(this.gradeFormGroup.valid) {
      this.isCreating = true;
      this.isInvalidData = false;

      this.studentServcie.postGrade(new PostGradeRequest(
        this.gradeFormGroup.controls.studentId.value!,
        this.gradeFormGroup.controls.subjectId.value!,
        this.gradeFormGroup.controls.grade.value!,
      ))
      .subscribe(res => {
        if(res)
          this.isCreationSuccess = true;
        else
          this.isCreationSuccess = false;

        this.studentServcie.getStudentStatisticsList()
        .subscribe(() => {
          this.isCreating = false;        
        });
      });
    }
    else {
      this.isInvalidData = true;
    }
  }
}
