import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditClientInteractionsComponent } from './edit-client-interactions.component';

describe('EditClientInteractionsComponent', () => {
  let component: EditClientInteractionsComponent;
  let fixture: ComponentFixture<EditClientInteractionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditClientInteractionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditClientInteractionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
