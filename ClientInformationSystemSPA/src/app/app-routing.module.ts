import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientsComponent } from './clients/clients.component';
import { EditClientComponent } from './clients/edit-client/edit-client.component';
import { EditEmployeeComponent } from './employees/edit-employee/edit-employee.component';
import { EmployeesComponent } from './employees/employees.component';
import { HomeComponent } from './home/home.component';
import { ClientInteractionComponent } from './interactions/client-interaction/client-interaction.component';
import { EditClientInteractionsComponent } from './interactions/client-interaction/edit-client-interactions/edit-client-interactions.component';
import { EditInteractionComponent } from './interactions/edit-interaction/edit-interaction.component';
import { EditEmployeeInteractionsComponent } from './interactions/employee-interaction/edit-employee-interactions/edit-employee-interactions.component';
import { EmployeeInteractionComponent } from './interactions/employee-interaction/employee-interaction.component';
import { InteractionsComponent } from './interactions/interactions.component';

const routes: Routes = [
  {path: "", component:HomeComponent},
  {path: "interactions", component:InteractionsComponent},
  {path: "interactions/client/:id", component:ClientInteractionComponent},
  {path: "interactions/employee/:id", component:EmployeeInteractionComponent},
  {path: "client", component:ClientsComponent},
  {path: "employee", component:EmployeesComponent},
  {path: "client/:id", component:EditClientComponent},
  {path: "employee/:id", component:EditEmployeeComponent},
  {path: "addInteractions", component:EditInteractionComponent},
  {path: "interactions/client/:id/interaction/:id", component:EditClientInteractionsComponent},
  {path: "interactions/:id", component:EditClientInteractionsComponent},
  {path: "interactions/employee/:id/interaction/:id", component:EditEmployeeInteractionsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
