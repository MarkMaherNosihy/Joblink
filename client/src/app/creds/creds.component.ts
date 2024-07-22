import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

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
  router = inject(Router);
  loginErrorExist: boolean = false;
  loginError: any;
  login(){
    this.authService.login(this.model).subscribe({
      next: (res)=>{
        console.log(res);
  
        this.authService.setIsLoggedIn(true);
        this.router.navigateByUrl('/jobs');
      },
      error: (err)=>{
        this.loginError = err;
        console.log(err);
        this.loginErrorExist = true;
      }
    });
  }
}
