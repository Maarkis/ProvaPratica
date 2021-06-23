import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MASKS, NgBrazil, NgBrazilValidators } from 'ng-brazil';
import { CreateClientRequest } from 'src/app/shared/interfaces/client/create-client-request.interface';
import { Sexo } from 'src/app/shared/interfaces/client/sexo.enum';
import { Convenio } from 'src/app/shared/interfaces/convenio/convenio.interface';
import { GetAllConvenioResponse } from 'src/app/shared/interfaces/convenio/get-all-convenio-response.interface';
import { BaseResponse } from 'src/app/shared/interfaces/responseBase/base-response.interface';
import { ClientService } from 'src/app/shared/services/client.service';
import { ConvenioService } from 'src/app/shared/services/convenio.service';
import { GenericValidator } from 'src/app/shared/validator/generic-validator.validator';

@Component({
  selector: 'app-cadastro-client',
  templateUrl: './cadastro-client.component.html',
  styleUrls: ['./cadastro-client.component.css']
})
export class CadastroClientComponent implements OnInit {
  public clientRegister!: FormGroup;

  public convenios!: Convenio[];
  public sexo = Sexo;
  public MASKS = MASKS; 
  public resultError!: BaseResponse;

  
  constructor(private fb: FormBuilder, private clientService: ClientService,
              private convenioService: ConvenioService, private router: Router) { }

  ngOnInit(): void {    
    
    this.convenioService.getAllConvenio().subscribe((response: GetAllConvenioResponse) => {
      if(response) {
        this.convenios = response.convenios;        
      }
    }) 
    this.clientRegister = this.createForm(new CreateClientRequest());     

  }

  private createForm(client: CreateClientRequest): FormGroup {
    return this.fb.group({
      nome: new FormControl(client.nome, [Validators.required]),
      sobrenome: new FormControl(client.sobrenome, [Validators.required]),
      dt_Nasc:  new FormControl(client.dt_Nasc, [Validators.required]),
      sexo:  new FormControl(client.sexo, [Validators.required]),
      cpf:  new FormControl(client.cpf, [NgBrazilValidators.cpf]),
      rg:  new FormControl(client.rg, [Validators.required]),
      ufrg:  new FormControl(client.ufrg, [Validators.required,Validators.minLength(2), Validators.maxLength(2)]),
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
      this.clientService.createClient(client).subscribe((response: BaseResponse ) => {        
        if(response.statusCode === 201){
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
}
