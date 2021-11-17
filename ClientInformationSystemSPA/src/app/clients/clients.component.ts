import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientService } from '../services/client.service';
import { NewClient } from '../shared/models/newClient';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  constructor(private clientService:ClientService, private router: Router) { }

  newClient:NewClient = {
    name: '',
    email: '',
    phones: '',
    address: '',
    addedOn: new Date()
  }

  success!:boolean;

  ngOnInit(): void {
  }

  addClient() {
    this.clientService.addClient(this.newClient).subscribe((response) => {
      if (response) {
        this.success = true;
      }
    });
  }

}
