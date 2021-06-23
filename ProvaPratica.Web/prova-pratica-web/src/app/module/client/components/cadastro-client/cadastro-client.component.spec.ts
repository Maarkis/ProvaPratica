import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroClientComponent } from './cadastro-client.component';

describe('CadastroClientComponent', () => {
  let component: CadastroClientComponent;
  let fixture: ComponentFixture<CadastroClientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroClientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
