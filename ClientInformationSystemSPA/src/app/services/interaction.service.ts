import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Interaction } from '../shared/models/interaction';
import { NewInteraction } from '../shared/models/newInteraction';

@Injectable({
  providedIn: 'root'
})
export class InteractionService {

  constructor(private http: HttpClient) { }

  getAllInteractions():Observable<Interaction[]> {
    return this.http.get(`${environment.apiUrl}${'Interactions'}`).pipe(map(response=>response as Interaction[]))
  }

  getInteractionByClientId(id:number):Observable<Interaction[]> {
    return this.http.get(`${environment.apiUrl}${'Interactions/Client/'}${id}`).pipe(map(response=>response as Interaction[]))
  }

  getInteractionByEmployeeId(id:number):Observable<Interaction[]> {
    return this.http.get(`${environment.apiUrl}${'Interactions/Employee/'}${id}`).pipe(map(response=>response as Interaction[]))
  }

  addInteraction(newInteraction: NewInteraction):Observable<Interaction> {
    return this.http.post(`${environment.apiUrl}${'Interactions'}`, newInteraction).pipe(map(response=>response as Interaction))
  }

  updateInteraction(id:number, newInteraction: NewInteraction):Observable<Interaction> {
    return this.http.put(`${environment.apiUrl}${'Interactions/'}${id}`, newInteraction).pipe(map(response=>response as Interaction))
  }

  deleteInteraction(id:number):Observable<Interaction> {
    return this.http.delete(`${environment.apiUrl}${'Interactions/'}${id}`).pipe(map(response=>response as Interaction))
  }

  getInteractionDetail(id:number):Observable<Interaction> {
    return this.http.get(`${environment.apiUrl}${'Interactions/'}${id}`).pipe(map(response=>response as Interaction))
  }
}
