import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCheckMatchComponent } from './show-check-match.component';

describe('ShowCheckMatchComponent', () => {
  let component: ShowCheckMatchComponent;
  let fixture: ComponentFixture<ShowCheckMatchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowCheckMatchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowCheckMatchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
