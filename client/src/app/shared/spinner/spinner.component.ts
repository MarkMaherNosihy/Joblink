import { Component, inject, OnInit } from '@angular/core';
import { SpinnerService } from '../../services/ui/spinner.service';

@Component({
  selector: 'app-spinner',
  standalone: true,
  imports: [],
  templateUrl: './spinner.component.html',
  styleUrl: './spinner.component.scss'
})
export class SpinnerComponent implements OnInit {
  spinnerService = inject(SpinnerService);
  isVisbile: boolean = false;

  ngOnInit(): void {
    this.spinnerService.visibility$.subscribe((isVisible)=>{
      this.isVisbile = isVisible
      console.log(isVisible);
    })
  }


}
