import { TestBed } from '@angular/core/testing';
import { ErrorsLogService } from './errors-log.service';
import { HttpClient } from '@angular/common/http';

describe('ErrorsLogService', () => {
  let service: ErrorsLogService;
  const httpSpy = jasmine.createSpyObj('HttpClient', ['post']);
  httpSpy.post.and.returnValue(true);

  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      {provide: HttpClient, useValue: httpSpy},
      { provide: 'BASE_URL', useValue: {}}
    ]
  }));

  beforeEach(() => {
    service = TestBed.get(ErrorsLogService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('logError should call http.post method', () => {
    const result =  service.logError(new Error());
    expect(httpSpy.post).toHaveBeenCalled();
    expect(result).toBeTruthy();
  });
});
