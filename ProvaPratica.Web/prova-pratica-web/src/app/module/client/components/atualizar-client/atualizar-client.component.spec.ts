import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AtualizarClientComponent } from './atualizar-client.component';

describe('AtualizarClientComponent', () => {
  let component: AtualizarClientComponent;
  let fixture: ComponentFixture<AtualizarClientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AtualizarClientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AtualizarClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
