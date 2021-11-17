import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Client } from '../shared/models/client';
import { NewClient } from '../shared/models/newClient';
import { ThisReceiver } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private http: HttpClient) { }

  getAllClients():Observable<Client[]> {
    return this.http.get(`${environment.apiUrl}${'Clients'}`).pipe(map(response=>response as Client[]))
  }

  addClient(newclient:NewClient) : Observable<Client> {
    return this.http.post(`${environment.apiUrl}${'Clients'}`, newclient).pipe(map(response=>response as Client))
  }

  updateClient(id:number, newclient:NewClient):Observable<Client> {
    return this.http.put(`${environment.apiUrl}${'Clients/'}${id}`, newclient).pipe(map(response=>response as Client))
  }

  deleteClient(id:number): Observable<Client> {
    return this.http.delete(`${environment.apiUrl}${'Clients/'}${id}`).pipe(map(response=>response as Client))
  }

  getClientDetail(id:number): Observable<Client> {
    return this.http.get(`${environment.apiUrl}${'Clients/'}${id}`).pipe(map(response=>response as Client))
  }
}
