import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from '../interfaces/client/client.interface';
import { GetAllClientResponse } from '../interfaces/client/get-all-client-response.interface';
import { CreateClientRequest } from '../interfaces/client/create-client-request.interface';
import { BaseResponse } from '../interfaces/responseBase/base-response.interface';
import { GetClientResponse } from '../interfaces/client/get-client-response.interface';


@Injectable({
  providedIn: 'root'
})
export class ClientService {
 

  private readonly URL = environment.API;

  constructor(private http: HttpClient) { }

  public getAllClient(): Observable<GetAllClientResponse> {
    return this.http.get<GetAllClientResponse>(`${this.URL}/Client`);
  }

  public createClient(client: CreateClientRequest): Observable<BaseResponse> {
    return this.http.post<BaseResponse>(`${this.URL}/Client`, client);
  }

  public getClient(id: number): Observable<GetClientResponse> {
    return this.http.get<GetClientResponse>(`${this.URL}/Client/${id}`);
  }
  public updateClient(client: CreateClientRequest): Observable<BaseResponse>  {
    return this.http.put<BaseResponse>(`${this.URL}/Client`, client);
  }

}
