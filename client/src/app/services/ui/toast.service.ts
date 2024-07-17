import { Injectable } from '@angular/core';

export interface ToastInfo {
  header: string;
  body: string;
  type: string;
  delay?: number;
}

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  toasts: ToastInfo[] = [];

  constructor() { }

  show(header: string, body: string, type: string) {
    this.toasts.push({ header, body, type });
  }

  remove(toast: ToastInfo) {
    this.toasts = this.toasts.filter(t => t != toast);
  }
}
