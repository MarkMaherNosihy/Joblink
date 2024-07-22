import { inject, Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Employee } from '../models/Employee';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  apiService = inject(ApiService);
  authService = inject(AuthService);

  getEmployeeByUsername(){
    return this.apiService.get<Employee>(`users/employees/${this.authService.currentUser()?.username}`);
  }

}
