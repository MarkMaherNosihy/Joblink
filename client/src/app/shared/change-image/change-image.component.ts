import { Component, inject } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { EmployeeService } from '../../services/employee.service';
import { Photo } from '../../models/Photo';
import { map, tap } from 'rxjs';

@Component({
  selector: 'app-change-image',
  standalone: true,
  imports: [FontAwesomeModule],
  templateUrl: './change-image.component.html',
  styleUrl: './change-image.component.scss'
})
export class ChangeImageComponent {
  editIcon = faEdit;
  selectedImage: File | null = null;
  empService = inject(EmployeeService);
  uploadImage(ev: Event){
    const input = ev.target as HTMLInputElement;

    if(input.files && input.files.length > 0){
      this.selectedImage = input.files[0];
      console.log('Selected file:', this.selectedImage);
    }
    if(this.selectedImage){
      this.empService.uploadProfileImage(this.selectedImage).pipe(map((res)=>res.url)).subscribe((res: any)=>{
        this.empService.profileImageChanged(res);
      })
    }
  }
}
