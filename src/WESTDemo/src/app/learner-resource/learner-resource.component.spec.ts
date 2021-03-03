import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearnerResourceComponent } from './learner-resource.component';

describe('LearnerResourceComponent', () => {
  let component: LearnerResourceComponent;
  let fixture: ComponentFixture<LearnerResourceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearnerResourceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearnerResourceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
