import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowEvaluationsComponent } from './show-evaluations.component';

describe('ShowEvaluationsComponent', () => {
  let component: ShowEvaluationsComponent;
  let fixture: ComponentFixture<ShowEvaluationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowEvaluationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowEvaluationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
