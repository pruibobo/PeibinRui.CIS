import { Component, OnInit } from '@angular/core';
import { InteractionService } from 'src/app/services/interaction.service';
import { Interaction } from 'src/app/shared/models/interaction';
import { ActivatedRoute } from '@angular/router';
import { NewInteraction } from 'src/app/shared/models/newInteraction';

@Component({
  selector: 'app-client-interaction',
  templateUrl: './client-interaction.component.html',
  styleUrls: ['./client-interaction.component.css']
})
export class ClientInteractionComponent implements OnInit {

  constructor(private route: ActivatedRoute, private interactionService: InteractionService) { }

  id!: number;
  interactionList!: Interaction[];
  hasResult!: boolean;

  ngOnInit(): void {
    this.route.paramMap.subscribe(param => { this.id = Number(param.get('id')) })
    this.interactionService.getInteractionByClientId(this.id).subscribe(ci => {
      if (ci == null) {
        this.hasResult = false;
      }
      else {
        this.hasResult = true;
        this.interactionList = ci
      }
    })
  }

  deleteInteraction(id:number) {
    this.interactionService.deleteInteraction(id).subscribe();
    window.location.reload();
  }

}
