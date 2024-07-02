import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from './nav/nav.component';
import { CredsComponent } from './creds/creds.component';
import { AuthService } from './services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent, CredsComponent, HomeComponent, RegisterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {

  authService = inject(AuthService);

  ngOnInit(): void {
    const userString = localStorage.getItem('user');

    if(!userString) return;
    
    const user = JSON.parse(userString);

    this.authService.currentUser.set(user);
  }

}
