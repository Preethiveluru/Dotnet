export class PetAnimal {
  petId: number;
  petName: string;
  petType: string;
  //dob: string;
  isVeg: boolean;

  constructor(petId: number, petName: string, petType: string, isVeg: boolean) {
    this.petId = petId;
    this.petName = petName;
    this.petType = petType;
    //this.dob = dob;
    this.isVeg = isVeg;
  }
}
