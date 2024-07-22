import { Component, inject, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { Experience } from '../models/Experience';
import { Employee } from '../models/Employee';
import { faGlobe, faLocation } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { faFacebook, faGithub, faLinkedin } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, FontAwesomeModule, NgbNavModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent implements OnInit {
  employeeService = inject(EmployeeService);
  experiences: Experience[] = [];
  employeeInfo!: Employee;
  active = 1;
  locationIcon = faLocation;
  websiteIcon = faGlobe;
  linkedinIcon = faLinkedin;
  githubIcon = faGithub;
  ngOnInit(): void {
    this.employeeService.getEmployeeByUsername().subscribe(res=>{
      this.employeeInfo = res;
      console.log(this.employeeInfo);
      console.log(this.employeeInfo.profilePictureURL);
      this.experiences = res.experiences;
    })
  }



}
