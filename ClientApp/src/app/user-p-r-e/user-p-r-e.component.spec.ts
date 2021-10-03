import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPREComponent } from './user-p-r-e.component';

describe('UserPREComponent', () => {
  let component: UserPREComponent;
  let fixture: ComponentFixture<UserPREComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserPREComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserPREComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
