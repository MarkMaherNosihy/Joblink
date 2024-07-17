import { Component, inject } from '@angular/core';
import { ToastService } from '../../services/ui/toast.service';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-toasts',
  standalone: true,
  imports: [NgbToastModule, CommonModule],
  templateUrl: './toasts.component.html',
  styleUrl: './toasts.component.scss'
})
export class ToastsComponent {

  toastService = inject(ToastService);
}
