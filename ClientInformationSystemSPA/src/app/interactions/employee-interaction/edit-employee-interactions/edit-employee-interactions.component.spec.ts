import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditEmployeeInteractionsComponent } from './edit-employee-interactions.component';

describe('EditEmployeeInteractionsComponent', () => {
  let component: EditEmployeeInteractionsComponent;
  let fixture: ComponentFixture<EditEmployeeInteractionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditEmployeeInteractionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditEmployeeInteractionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
