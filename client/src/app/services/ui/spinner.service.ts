import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {
  private spinnerVisibility = new BehaviorSubject<boolean>(false);
  visibility$ = this.spinnerVisibility.asObservable();

  constructor() { }

  show() {
    this.spinnerVisibility.next(true);
  }
  hide() {
    this.spinnerVisibility.next(false);
  }
}
