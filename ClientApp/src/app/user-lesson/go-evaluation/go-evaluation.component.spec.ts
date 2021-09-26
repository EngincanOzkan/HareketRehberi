import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoEvaluationComponent } from './go-evaluation.component';

describe('GoEvaluationComponent', () => {
  let component: GoEvaluationComponent;
  let fixture: ComponentFixture<GoEvaluationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoEvaluationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GoEvaluationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
