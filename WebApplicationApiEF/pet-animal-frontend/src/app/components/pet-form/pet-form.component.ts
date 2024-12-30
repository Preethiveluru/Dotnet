

import { Component, OnInit } from '@angular/core';
import { PetAnimalService } from '../../services/pet-animal.service';
import { PetAnimal } from '../../module/pet-animal.model';

@Component({
  selector: 'app-pet-form',
  templateUrl: './pet-form.component.html',
  styleUrls: ['./pet-form.component.css']
})
export class PetFormComponent implements OnInit {
  pet: PetAnimal = new PetAnimal(0, '', '', true);
  petsList: PetAnimal[] = [];
  responseMessage: string = '';

  constructor(private petAnimalService: PetAnimalService) { }

  ngOnInit(): void {
    this.loadPets(); // Load pets from the backend
    this.resetForm(); // Reset form to default state
  }

  // Add a new pet animal
  addPetAnimal() {
    this.petAnimalService.addPet(this.pet).subscribe(
      (response) => {
        this.responseMessage = `Pet animal ${response.petName} added successfully!`;
        this.loadPets(); // Reload pet list after adding
        this.resetForm(); // Reset the form
      },
      (error) => {
        this.responseMessage = `Error: ${error.message}`;
      }
    );
  }



  updatePet() {
    if (!this.pet.petId || this.pet.petId <= 0) {
      this.responseMessage = 'Invalid Pet ID for update.';
      return;
    }

    this.petAnimalService.updatePet(this.pet).subscribe(
      (response) => {
        this.responseMessage = `Pet animal ${response.petName} updated successfully!`;
        this.loadPets(); // Reload the pet list
        this.resetForm(); // Reset the form
      },
      (error) => {
        this.responseMessage = `Error updating pet: ${error.message}`;
      }
    );
  }

  resetForm() {
    this.pet = new PetAnimal(0, '', '', true); // Reset the form for a new entry
    this.isEditMode = false; // Reset mode to add mode
  }



  // Load all pets
  loadPets() {
    this.petAnimalService.getPets().subscribe(
      (data) => {
        this.petsList = data;
      },
      (error) => {
        console.error('Error loading pets:', error);
      }
    );
  }

  // Delete a pet animal
  deletePet(petId: number) {
    this.petAnimalService.deletePet(petId).subscribe(
      () => {
        this.responseMessage = `Pet animal with ID ${petId} deleted successfully!`;
        this.loadPets();
      },
      (error) => {
        this.responseMessage = `Error deleting pet: ${error.message}`;
      }
    );
  }
  isEditMode: boolean = false;

  // Edit a pet animal
  editPet(pet: PetAnimal) {
    this.pet = { ...pet }; // Populate the form with the selected pet's details
    this.isEditMode = true; // Switch to edit mode
  }
  cancelEdit() {
    this.resetForm();
    this.isEditMode = false; // Switch back to add mode
  }

 
}


