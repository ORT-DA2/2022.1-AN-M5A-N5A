import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JinkannaComponent } from './jinkanna.component';

describe('JinkannaComponent', () => {
  let component: JinkannaComponent;
  let fixture: ComponentFixture<JinkannaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JinkannaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(JinkannaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
