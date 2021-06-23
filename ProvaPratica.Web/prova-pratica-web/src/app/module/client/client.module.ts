import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { ClientComponent } from './components/client/client.component';
import { CadastroClientComponent } from './components/cadastro-client/cadastro-client.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextMaskModule } from 'angular2-text-mask';
import { AtualizarClientComponent } from './components/atualizar-client/atualizar-client.component';




@NgModule({
  declarations: [        
    ClientComponent, CadastroClientComponent, AtualizarClientComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    TextMaskModule
  ], providers: [ DatePipe]
})
export class ClientModule { }
