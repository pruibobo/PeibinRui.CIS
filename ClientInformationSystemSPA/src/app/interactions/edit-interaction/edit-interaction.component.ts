import { Component, OnInit } from '@angular/core';
import { ClientService } from 'src/app/services/client.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { InteractionService } from 'src/app/services/interaction.service';
import { Client } from 'src/app/shared/models/client';
import { Employee } from 'src/app/shared/models/employee';
import { NewInteraction } from 'src/app/shared/models/newInteraction';

@Component({
  selector: 'app-edit-interaction',
  templateUrl: './edit-interaction.component.html',
  styleUrls: ['./edit-interaction.component.css']
})
export class EditInteractionComponent implements OnInit {

  constructor(private interactionService: InteractionService, private clientService: ClientService, private employeeService: EmployeeService) { }

  newInteraction:NewInteraction = {
    clientId: 0,
    empId: 0,
    intType: '',
    intDate: new Date,
    remarks: ''
  }
  
  success!:boolean;
  clientList!:Client[];
  employeeList!:Employee[];

  ngOnInit(): void {
    this.clientService.getAllClients().subscribe(c=>{this.clientList = c});
    this.employeeService.getAllEmployees().subscribe(e=>{this.employeeList = e});
  }

  addInteractions() {
    this.interactionService.addInteraction(this.newInteraction).subscribe((response) => {
      if (response) {
        this.success = true;
      }
    });
  }

}
