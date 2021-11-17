import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeInteractionComponent } from './employee-interaction.component';

describe('EmployeeInteractionComponent', () => {
  let component: EmployeeInteractionComponent;
  let fixture: ComponentFixture<EmployeeInteractionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeInteractionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeInteractionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
