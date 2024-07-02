import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-creds',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './creds.component.html',
  styleUrl: './creds.component.scss'
})
export class CredsComponent {

  model: any = {};
  authService = inject(AuthService);
  loginErrorExist: boolean = false;

  login(){
    this.authService.login(this.model).subscribe({
      next: (res)=>{
        console.log(res);
        this.authService.setIsLoggedIn(true);
      },
      error: (err)=>{
        console.log(err);
        this.loginErrorExist = true;
      }
    });
  }
}
