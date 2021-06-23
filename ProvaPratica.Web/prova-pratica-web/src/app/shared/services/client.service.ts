import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from '../interfaces/client/client.interface';
import { GetAllClientResponse } from '../interfaces/client/get-all-client-response.interface';


@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private readonly URL = environment.API;

  constructor(private http: HttpClient) { }

  public getAllClient(): Observable<GetAllClientResponse> {
    return this.http.get<GetAllClientResponse>(`${this.URL}/Client`);
  }
}
