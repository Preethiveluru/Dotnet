import { Component, OnInit } from '@angular/core';
import { PetAnimalService } from '../../services/pet-animal.service';
import { PetAnimal } from '../../module/pet-animal.model';

@Component({
  selector: 'app-pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css'],
})
export class PetListComponent implements OnInit {
  pets: PetAnimal[] = [];

  constructor(private petService: PetAnimalService) { }

  ngOnInit(): void {
    this.petService.getPets().subscribe(
      (data: PetAnimal[]) => {
        console.log('Pets fetched successfully:', data);
        this.pets = data;
      },
      (error) => {
        console.error('Error fetching pets:', error);
      }
    );
  }
}
