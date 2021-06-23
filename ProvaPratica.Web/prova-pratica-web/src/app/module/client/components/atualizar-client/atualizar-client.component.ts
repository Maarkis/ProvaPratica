import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MASKS, NgBrazil, NgBrazilValidators } from 'ng-brazil';
import { number } from 'ng-brazil/number/validator';
import { Client } from 'src/app/shared/interfaces/client/client.interface';
import { CreateClientRequest } from 'src/app/shared/interfaces/client/create-client-request.interface';
import { GetClientResponse } from 'src/app/shared/interfaces/client/get-client-response.interface';
import { Sexo } from 'src/app/shared/interfaces/client/sexo.enum';
import { UpdateClientRequest } from 'src/app/shared/interfaces/client/update-client-request.interface';
import { Convenio } from 'src/app/shared/interfaces/convenio/convenio.interface';
import { GetAllConvenioResponse } from 'src/app/shared/interfaces/convenio/get-all-convenio-response.interface';
import { BaseResponse } from 'src/app/shared/interfaces/responseBase/base-response.interface';
import { ClientService } from 'src/app/shared/services/client.service';
import { ConvenioService } from 'src/app/shared/services/convenio.service';
import { GenericValidator } from 'src/app/shared/validator/generic-validator.validator';

@Component({
  selector: 'app-atualizar-client',
  templateUrl: './atualizar-client.component.html',
  styleUrls: ['./atualizar-client.component.css']
})
export class AtualizarClientComponent implements OnInit {

  public clientRegister!: FormGroup;

  public convenios!: Convenio[];
  public sexo = Sexo;
  public MASKS = MASKS; 
  public resultError!: BaseResponse;

  public prontuario!: number;
  public client!: Client;

  
  constructor(private fb: FormBuilder, private clientService: ClientService,
              private convenioService: ConvenioService, private router: Router,
              private route: ActivatedRoute, private datePipe: DatePipe) { }

  ngOnInit(): void {    
    
    this.convenioService.getAllConvenio().subscribe((response: GetAllConvenioResponse) => {
      if(response) {
        this.convenios = response.convenios;        
      }
    }) 
    
    this.route.params.subscribe(params => {
      this.prontuario = +params['prontuario'];
   });
   

    this.clientService.getClient(this.prontuario).subscribe((response: GetClientResponse) => {
      if(response){
        console.log(response.mensagem);
        this.client = response.client;
        this.clientRegister = this.createForm(response.client);     
      }
    }, error => {
      console.log(error);      
    });
    

  }

  private createForm(client: UpdateClientRequest): FormGroup {
    return this.fb.group({
      prontuario: new FormControl(client.prontuario, [Validators.required]),
      nome: new FormControl(client.nome, [Validators.required]),
      sobrenome: new FormControl(client.sobrenome, [Validators.required]),
      dt_Nasc:  new FormControl(this.convertDate(client.dt_Nasc), [Validators.required]),
      sexo:  new FormControl(client.sexo, [Validators.required]),     
      email:  new FormControl(client.email, [Validators.required,Validators.email]),
      celular:  new FormControl(client.celular, [Validators.required, NgBrazilValidators.celular]),
      fone_Res:  new FormControl(client.fone_Res, [Validators.required, NgBrazilValidators.telefone]),
      id_Convenio:  new FormControl(client.id_Convenio, [Validators.required]),
      n_Carteirinha:  new FormControl(client.n_Carteirinha, [Validators.required]),
    });
  }
  
  get form(): { [control: string]: AbstractControl } {
        return this.clientRegister.controls;
  }

  public onSubmit(client: CreateClientRequest): void {            
    
    if (this.clientRegister.valid) {      
      this.clientService.updateClient(client).subscribe((response: BaseResponse ) => {        
        if(response.statusCode === 200){
          console.log(response.mensagem);
          this.router.navigate(['/']);
        } else {
          this.resultError = response;

        }
      }, error => {
        console.log(error);       
      });      
    } else {
      GenericValidator.verifierValidatorsForm(this.clientRegister);
    }
  }

  public hasError(control: string, error: string) : boolean {
    return (this.form[control].dirty || this.form[control].touched) && this.form[control].hasError(error);
  }

  public back(): void {
    this.router.navigate(['/']);
  }

  public convertDate(date: string): string | null {
    return this.datePipe.transform(date, 'yyyy-MM-dd');
  }
}
