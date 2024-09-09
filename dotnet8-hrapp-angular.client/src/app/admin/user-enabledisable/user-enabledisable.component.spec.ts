import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserEnableDisableComponent } from './user-enabledisable.component';

describe('UserEnabledisableComponent', () => {
  let component: UserEnableDisableComponent;
  let fixture: ComponentFixture<UserEnableDisableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserEnableDisableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserEnableDisableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
