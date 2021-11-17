import { Component, OnInit } from '@angular/core';
import { InteractionService } from '../services/interaction.service';
import { Interaction } from '../shared/models/interaction';

@Component({
  selector: 'app-interactions',
  templateUrl: './interactions.component.html',
  styleUrls: ['./interactions.component.css']
})
export class InteractionsComponent implements OnInit {

  constructor(private interactionService:InteractionService) { }

  interactionList!:Interaction[];

  ngOnInit(): void {
    this.interactionService.getAllInteractions().subscribe(
      i=>{
        this.interactionList = i;
        // console.table(this.interactionList);
      }
    )
  }

  deleteInteraction(id:number) {
    this.interactionService.deleteInteraction(id).subscribe();
    window.location.reload();
  }
}
