import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExitGateOperatorComponent } from './exit-gate-operator.component';

describe('ExitGateOperatorComponent', () => {
  let component: ExitGateOperatorComponent;
  let fixture: ComponentFixture<ExitGateOperatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExitGateOperatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExitGateOperatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
