import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { GetAllConvenioResponse } from '../interfaces/convenio/get-all-convenio-response.interface';

@Injectable({
  providedIn: 'root'
})
export class ConvenioService {

  private readonly URL = environment.API;

  constructor(private http: HttpClient) { }

  public getAllConvenio(): Observable<GetAllConvenioResponse> {
    return this.http.get<GetAllConvenioResponse>(`${this.URL}/Convenio`);
  }
}
