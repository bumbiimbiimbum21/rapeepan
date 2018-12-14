import { TestBed } from '@angular/core/testing';

import { TbAmuletService } from './tb-amulet.service';

describe('TbAmuletService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TbAmuletService = TestBed.get(TbAmuletService);
    expect(service).toBeTruthy();
  });
});
