//import { Injectable } from '@angular/core';
//import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { Observable, catchError, throwError } from 'rxjs';
//import { PetAnimal } from '../module/pet-animal.model';

//@Injectable({
//  providedIn: 'root',
//})
//export class PetAnimalService {
//  private apiUrl = 'http://localhost:5103/api/PetAnimals'; // Backend API URL

//  constructor(private http: HttpClient) { }

//  // Add a pet
//  //addPet(pet: PetAnimal): Observable<PetAnimal> {
//  //  console.log('Sending pet to backend:', pet);
//  //  const headers = new HttpHeaders().set('Content-Type', 'application/json');
//  //  return this.http.post<PetAnimal>(this.apiUrl, pet, { headers });
//  //}
//  //addPet(pet: PetAnimal): Observable<PetAnimal> {
//  //  console.log('Sending pet to backend:', pet);
//  //  const headers = new HttpHeaders().set('Content-Type', 'application/json');
//  //  return this.http.post<PetAnimal>(this.apiUrl, pet, { headers }).pipe(
//  //    catchError((error) => {
//  //      console.error('Error from backend:', error);
//  //      alert('Failed to add pet. Check console for details.');
//  //      return throwError(() => error);
//  //    })
//  //  );
//  //}

//  addPet(pet: PetAnimal): Observable<any> {
//    return this.http.post('http://localhost:5103/api/PetAnimals', pet, {
//      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
//    });
//  }


//  //// Get all pets
//  //getPets(): Observable<PetAnimal[]> {
//  //  return this.http.get<PetAnimal[]>(this.apiUrl);
//  //}

//  getPets(): Observable<PetAnimal[]> {
//    console.log('Fetching pets from backend...');
//    return this.http.get<PetAnimal[]>(this.apiUrl).pipe(
//      catchError((error) => {
//        console.error('Error fetching pets:', error);
//        alert('Failed to fetch pets. Check console for details.');
//        return throwError(() => error);
//      })
//    );
//  }


//}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PetAnimal } from '../module/pet-animal.model';

@Injectable({
  providedIn: 'root'
})
export class PetAnimalService {
  private apiUrl = 'http://localhost:5103/api/PetAnimals';

  constructor(private http: HttpClient) { }

  // Add a pet
  addPet(pet: PetAnimal): Observable<PetAnimal> {
    return this.http.post<PetAnimal>(this.apiUrl, pet, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    });
  }

  // Get all pets
  getPets(): Observable<PetAnimal[]> {
    return this.http.get<PetAnimal[]>(this.apiUrl);
  }

  // Delete a pet by ID
  deletePet(petId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${petId}`);
  }

  // Update a pet
  updatePet(pet: PetAnimal): Observable<PetAnimal> {
    return this.http.put<PetAnimal>(`${this.apiUrl}/${pet.petId}`, pet, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    });
  }
}

