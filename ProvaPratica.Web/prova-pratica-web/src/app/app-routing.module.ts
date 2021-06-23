import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ClientComponent } from './module/client/components/client/client.component';
import { CadastroClientComponent } from './module/client/components/cadastro-client/cadastro-client.component';
import { AtualizarClientComponent } from './module/client/components/atualizar-client/atualizar-client.component';

const routes: Routes = [
  {path: '', component: ClientComponent},
  {path: 'cadastro', component: CadastroClientComponent},
  {path: 'client-details/:prontuario', component: AtualizarClientComponent},
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}