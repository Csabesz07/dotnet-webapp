import { FormControl, FormGroup } from '@angular/forms';

export type LoginFormGroup = FormGroup<{
  username: FormControl<string | null>;
  password: FormControl<string | null>;  
}>;

export type StudentFormGroup = FormGroup<{
  name: FormControl<string>;
  semester: FormControl<number>;  
  birthday: FormControl<Date>;
  mobileNumber: FormControl<string>;
}>;

export type GradeFormGroup = FormGroup<{
  studentId: FormControl<number | null>;
  subjectId: FormControl<number | null>;
  grade: FormControl<number | null>;
}>;