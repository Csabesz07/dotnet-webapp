import { FormControl, FormGroup } from '@angular/forms';

export type LoginFormGroup = FormGroup<{
  username: FormControl<string | null>;
  password: FormControl<string | null>;  
}>;