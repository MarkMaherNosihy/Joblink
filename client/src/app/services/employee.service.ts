import { inject, Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Employee } from '../models/Employee';
import { AuthService } from './auth.service';
import { Experience } from '../models/Experience';
import { BehaviorSubject, Subject } from 'rxjs';
import { Photo } from '../models/Photo';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  
  apiService = inject(ApiService);
  authService = inject(AuthService);
  private experienceSubject:Subject<Experience> = new Subject<Experience>();
  experienceUpdateAction$ = this.experienceSubject.asObservable(); 
  private profileImageSubject:Subject<string> = new Subject<string>();
  imageUpdatedAction$ = this.profileImageSubject.asObservable(); 

  getEmployeeByUsername(){
    return this.apiService.get<Employee>(`users/employees/${this.authService.currentUser()?.username}`);
  }
  updateEmployeeExperience(experience: Experience){
    return this.apiService.update(`users/employees/${this.authService.currentUser()?.username}/experience`, "", experience);
  }
    uploadProfileImage(file: File){
    const formData = new FormData();
    formData.append('file', file);
    return this.apiService.update<Photo>(`users/update-photo`,"", formData);
  }

  experienceChanged(experience: Experience){
    this.experienceSubject.next(experience);
  }
  profileImageChanged(url: string){
    this.profileImageSubject.next(url);
  }
}
