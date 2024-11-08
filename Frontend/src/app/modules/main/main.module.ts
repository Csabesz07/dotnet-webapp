import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { GradeCreatorComponent } from './grade-creator/grade-creator.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { StudentCreatorComponent } from './student-creator/student-creator.component';
import { StudentListComponent } from './student-list/student-list.component';
import { StudentStatisticsComponent } from './student-statistics/student-statistics.component';
import { RouterModule } from '@angular/router';
import { routes } from './main.routes';



@NgModule({
  declarations: [
    GradeCreatorComponent,
    LoginComponent,
    MainComponent,
    StudentCreatorComponent,
    StudentListComponent,
    StudentStatisticsComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class MainModule { }
