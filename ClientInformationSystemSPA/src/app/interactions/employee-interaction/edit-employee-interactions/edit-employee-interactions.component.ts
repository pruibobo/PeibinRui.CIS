import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InteractionService } from 'src/app/services/interaction.service';
import { InteractionDetail } from 'src/app/shared/models/interactionDetail';
import { NewInteraction } from 'src/app/shared/models/newInteraction';

@Component({
  selector: 'app-edit-employee-interactions',
  templateUrl: './edit-employee-interactions.component.html',
  styleUrls: ['./edit-employee-interactions.component.css']
})
export class EditEmployeeInteractionsComponent implements OnInit {

  constructor(private route: ActivatedRoute, private interactionService: InteractionService) { }

  id!: number;
  success!: boolean;
  currentInteraction!: InteractionDetail;

  newInteraction: NewInteraction = {
    clientId: 0,
    empId: 0,
    intType: '',
    intDate: new Date,
    remarks: ''
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(param => { this.id = Number(param.get('id')) });
    this.interactionService.getInteractionDetail(this.id).subscribe(
      i => {
        this.currentInteraction = i;
        this.newInteraction.empId = i.empId;
        this.newInteraction.clientId = i.clientId;
        this.newInteraction.intType = i.intType;
        this.newInteraction.intDate = i.intDate;
        this.newInteraction.remarks = i.remarks;
      });
  }

  updateInteraction() {
    this.interactionService.updateInteraction(this.id, this.newInteraction).subscribe((response) => {
      if (response) {
        this.success = true;
      }
    });
  }

}
