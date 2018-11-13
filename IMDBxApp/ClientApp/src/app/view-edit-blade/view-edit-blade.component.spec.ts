import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewEditBladeComponent } from './view-edit-blade.component';

describe('ViewEditBladeComponent', () => {
  let component: ViewEditBladeComponent;
  let fixture: ComponentFixture<ViewEditBladeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewEditBladeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewEditBladeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
