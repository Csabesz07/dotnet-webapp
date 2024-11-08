import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradeCreatorComponent } from './grade-creator.component';

describe('GradeCreatorComponent', () => {
  let component: GradeCreatorComponent;
  let fixture: ComponentFixture<GradeCreatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GradeCreatorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GradeCreatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
