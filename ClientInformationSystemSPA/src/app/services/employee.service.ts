import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Employee } from '../shared/models/employee';
import { NewEmployee } from '../shared/models/newEmployee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  getAllEmployees():Observable<Employee[]> {
    return this.http.get(`${environment.apiUrl}${'Employees'}`).pipe(map(response=>response as Employee[]))
  }

  addEmployee(newEmployee:NewEmployee):Observable<Employee> {
    return this.http.post(`${environment.apiUrl}${'Employees'}`, newEmployee).pipe(map(response=>response as Employee))
  }

  updateEmployee(id:number, newEmployee:NewEmployee) :Observable<Employee> {
    return this.http.put(`${environment.apiUrl}${'Employees/'}${id}`, newEmployee).pipe(map(response=>response as Employee))
  }

  deleteEmployee(id:number):Observable<Employee> {
    return this.http.delete(`${environment.apiUrl}${'Employees/'}${id}`).pipe(map(response=>response as Employee))
  }

  getEmployeeDetail(id:number):Observable<Employee> {
    return this.http.get(`${environment.apiUrl}${'Employees/'}${id}`).pipe(map(response=>response as Employee))
  }
}
