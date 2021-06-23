import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Client } from 'src/app/shared/interfaces/client/client.interface';
import { GetAllClientResponse } from 'src/app/shared/interfaces/client/get-all-client-response.interface';
import { Sexo } from 'src/app/shared/interfaces/client/sexo.enum';
import { Convenio } from 'src/app/shared/interfaces/convenio/convenio.interface';
import { GetAllConvenioResponse } from 'src/app/shared/interfaces/convenio/get-all-convenio-response.interface';
import { ClientService } from 'src/app/shared/services/client.service';
import { ConvenioService } from 'src/app/shared/services/convenio.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  public clients: Client[] = [];
  public convenios: Convenio[] = [];

  filter = new FormControl('');


  constructor(private clientService: ClientService, private convenioService: ConvenioService) { }

  ngOnInit(): void {

    this.clientService.getAllClient().subscribe((response: GetAllClientResponse) => {
      if(response){
        this.clients = response.clients;
        console.log(response.mensagem);
      }      
    })

    this.convenioService.getAllConvenio().subscribe((response: GetAllConvenioResponse) => {
      if(response) {
        this.convenios = response.convenios;
        console.log(response.mensagem);
      }
    })   
  }

  public getNameConvenio(id: number): string {
    const empresa = this.convenios.find(f => f.id_Convenio === id);
    if(!empresa) {
      return '';
    }
    return empresa.empresa;
  }

  public getSexo(sexo: number): string {
      return Sexo[sexo];
  }
}
