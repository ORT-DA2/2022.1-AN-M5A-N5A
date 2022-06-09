import { TestBed } from '@angular/core/testing';

import { ImporterService } from './importer.service';

describe('ImporterService', () => {
  let service: ImporterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImporterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
