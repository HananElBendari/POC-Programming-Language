import { TestBed } from '@angular/core/testing';
import { NotificationService } from './notification.service';
import { ToastrService } from 'ngx-toastr';

describe('NotificationServiceService', () => {
  let service: NotificationService;
  const toastrSpy = jasmine.createSpyObj('ToastrService', ['success', 'error']);
  toastrSpy.success.and.callThrough();
  toastrSpy.error.and.callThrough();

  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      {provide: ToastrService, useValue: toastrSpy}
    ]
  }));

  beforeEach(() => {
    service = TestBed.get(NotificationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('showSuccess should call success method', () => {
    service.showSuccess(null, null);
    expect(toastrSpy.success).toHaveBeenCalled();
  });

  it('showError should call error method', () => {
    service.showError(null, null);
    expect(toastrSpy.error).toHaveBeenCalled();
  });
});
