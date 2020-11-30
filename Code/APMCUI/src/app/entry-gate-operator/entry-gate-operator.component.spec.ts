import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EntryGateOperatorComponent } from './entry-gate-operator.component';

describe('EntryGateOperatorComponent', () => {
  let component: EntryGateOperatorComponent;
  let fixture: ComponentFixture<EntryGateOperatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EntryGateOperatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EntryGateOperatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
