import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from 'src/app/services/employee.service';
import { Employee } from 'src/app/shared/models/employee';
import { NewEmployee } from 'src/app/shared/models/newEmployee';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private employeeService:EmployeeService) { }

  id!:number;
  success!:boolean;
  currentEmployee!:Employee;

  newemployee:NewEmployee = {
    name: '',
    password:'',
    designation:''
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(param => { this.id = Number(param.get('id')) })
    this.employeeService.getEmployeeDetail(this.id).subscribe(e=>
      {
        this.currentEmployee = e;
        this.newemployee.name = e.name;
        this.newemployee.password = e.password;
        this.newemployee.designation = e.designation;
      })
  }

  updateEmployee() {
    this.employeeService.updateEmployee(this.id, this.newemployee).subscribe((response) => {
      if (response) {
        this.success = true;
      }
    });
  }

}
