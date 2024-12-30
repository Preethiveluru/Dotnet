import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PetFormComponent } from './components/pet-form/pet-form.component';
import { PetListComponent } from './components/pet-list/pet-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'add-pet', pathMatch: 'full' },
  { path: 'add-pet', component: PetFormComponent },
  { path: 'pet-list', component: PetListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
