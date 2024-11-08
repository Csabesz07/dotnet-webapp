import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentCreatorComponent } from './student-creator.component';

describe('StudentCreatorComponent', () => {
  let component: StudentCreatorComponent;
  let fixture: ComponentFixture<StudentCreatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentCreatorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StudentCreatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
