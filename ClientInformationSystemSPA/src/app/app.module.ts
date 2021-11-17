import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { InteractionsComponent } from './interactions/interactions.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { ClientInteractionComponent } from './interactions/client-interaction/client-interaction.component';
import { EmployeeInteractionComponent } from './interactions/employee-interaction/employee-interaction.component';
import { ClientsComponent } from './clients/clients.component';
import { EmployeesComponent } from './employees/employees.component';
import { EditClientComponent } from './clients/edit-client/edit-client.component';
import { EditEmployeeComponent } from './employees/edit-employee/edit-employee.component';
import { EditClientInteractionsComponent } from './interactions/client-interaction/edit-client-interactions/edit-client-interactions.component';
import { EditEmployeeInteractionsComponent } from './interactions/employee-interaction/edit-employee-interactions/edit-employee-interactions.component';
import { EditInteractionComponent } from './interactions/edit-interaction/edit-interaction.component';
import { FooterComponent } from './core/layout/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    InteractionsComponent,
    HeaderComponent,
    ClientInteractionComponent,
    EmployeeInteractionComponent,
    ClientsComponent,
    EmployeesComponent,
    EditClientComponent,
    EditEmployeeComponent,
    EditClientInteractionsComponent,
    EditEmployeeInteractionsComponent,
    EditInteractionComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
