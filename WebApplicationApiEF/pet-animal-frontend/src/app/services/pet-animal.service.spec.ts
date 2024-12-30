import { TestBed } from '@angular/core/testing';

import { PetAnimalService } from './pet-animal.service';

describe('PetAnimalService', () => {
  let service: PetAnimalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PetAnimalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
