import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StallRegistrationComponent } from './stall-registration.component';

describe('StallRegistrationComponent', () => {
  let component: StallRegistrationComponent;
  let fixture: ComponentFixture<StallRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StallRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StallRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
