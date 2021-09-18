import { TestBed } from '@angular/core/testing';
import { #NomeModel#Service } from './#nomemodel#.service';

 

describe('#NomeModel#Service', () => {
  let service: #NomeModel#Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(#NomeModel#Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
