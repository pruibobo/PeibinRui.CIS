import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from 'src/app/services/client.service';
import { Client } from 'src/app/shared/models/client';
import { NewClient } from 'src/app/shared/models/newClient';

@Component({
  selector: 'app-edit-client',
  templateUrl: './edit-client.component.html',
  styleUrls: ['./edit-client.component.css']
})
export class EditClientComponent implements OnInit {

  constructor(private clientService:ClientService, private route: ActivatedRoute, private router: Router) { }

  id!:number;
  success!:boolean;
  currentClient!:Client;

  newClient:NewClient = {
    name: '',
    email: '',
    phones: '',
    address: '',
    addedOn: new Date
  }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe(param => { this.id = Number(param.get('id')) })
    this.clientService.getClientDetail(this.id).subscribe(c=>
      {
        this.currentClient = c;
        this.newClient.name = c.name;
        this.newClient.email = c.email;
        this.newClient.phones = c.phones;
        this.newClient.address = c.address;
        this.newClient.addedOn = c.addedOn;
      });
  }

  updateClient() {
    this.clientService.updateClient(this.id, this.newClient).subscribe((response) => {
      if (response) {
        this.success = true;
      }
    });
  }
}
