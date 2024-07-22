import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl: string = environment.apiUrl;
  httpClient = inject(HttpClient);
  constructor() { }


  get<T>(endpoint: string, queryString: string = ""){
    return this.httpClient.get<T>(this.baseUrl+endpoint);
  }

  post(endpoint: string, queryString: string = "", body: any){
    return this.httpClient.post(this.baseUrl+endpoint+queryString, body);
  }
}
