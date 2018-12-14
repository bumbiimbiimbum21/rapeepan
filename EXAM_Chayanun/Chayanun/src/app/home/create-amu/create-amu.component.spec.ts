import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateAmuComponent } from './create-amu.component';

describe('CreateAmuComponent', () => {
  let component: CreateAmuComponent;
  let fixture: ComponentFixture<CreateAmuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateAmuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateAmuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
