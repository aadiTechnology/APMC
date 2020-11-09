import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatIndentComponent } from './creat-indent.component';

describe('CreatIndentComponent', () => {
  let component: CreatIndentComponent;
  let fixture: ComponentFixture<CreatIndentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatIndentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatIndentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
