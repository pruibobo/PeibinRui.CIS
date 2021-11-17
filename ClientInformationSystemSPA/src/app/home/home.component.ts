import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ClientService } from '../services/client.service';
import { EmployeeService } from '../services/employee.service';
import { Client } from '../shared/models/client';
import { Employee } from '../shared/models/employee';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private clientService: ClientService, private employeeService: EmployeeService) { }

  clientList!: Client[];
  employeeList!:Employee[];

  ngOnInit(): void {

    this.clientService.getAllClients().subscribe(
      c=>{
        this.clientList = c;
        // console.table(this.clientList);
      }
    )

    this.employeeService.getAllEmployees().subscribe(
      e=>{
        this.employeeList = e;
      }
    )
  }

  deleteEmployee(id:number) {
    this.employeeService.deleteEmployee(id).subscribe();
    window.location.reload();
  }

  deleteClient(id:number) {
    this.clientService.deleteClient(id).subscribe();
    window.location.reload();
  }

}
