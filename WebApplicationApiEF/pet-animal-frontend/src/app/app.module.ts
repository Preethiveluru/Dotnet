import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PetListComponent } from './components/pet-list/pet-list.component';
import { PetFormComponent } from './components/pet-form/pet-form.component';

@NgModule({
  declarations: [
    AppComponent,        // Root component
    PetListComponent,    // Component to display the pet list
    PetFormComponent     // Component for adding a pet
  ],
  imports: [
    BrowserModule,       // Required for any Angular app
    AppRoutingModule,    // Your routing module
    FormsModule,         // For template-driven forms
    ReactiveFormsModule, // For reactive forms (used in `pet-form.component`)
    HttpClientModule     // For HTTP requests
  ],
  providers: [],
  bootstrap: [AppComponent] // Bootstrap the root component
})
export class AppModule { }
