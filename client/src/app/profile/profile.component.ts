import { ChangeDetectorRef, Component, inject, Input, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { Experience } from '../models/Experience';
import { Employee } from '../models/Employee';
import { faEdit, faGlobe, faLocation } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { faFacebook, faGithub, faLinkedin } from '@fortawesome/free-brands-svg-icons';
import { EditExperienceModalComponent } from "./edit-experience-modal/edit-experience-modal.component";
import { Router, RouterModule } from '@angular/router';
import { ChangeImageComponent } from '../shared/change-image/change-image.component';
import { ExperiencesComponent } from "./experiences/experiences.component";

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, FontAwesomeModule, NgbNavModule, EditExperienceModalComponent, RouterModule, ChangeImageComponent, ExperiencesComponent],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent implements OnInit {
  employeeService = inject(EmployeeService);
  cdr = inject(ChangeDetectorRef);

  experiences: Experience[] = [];
  employeeInfo!: Employee;
  active = 1;
  locationIcon = faLocation;
  websiteIcon = faGlobe;
  linkedinIcon = faLinkedin;
  githubIcon = faGithub;
  isImageHovered = false;
  @Input() unsavedChanges?: boolean;
  router = inject(Router);

  ngOnInit(): void {
    //Initial call to get employee info.
    this.employeeService.getEmployeeByUsername().subscribe(res=>{
      this.employeeInfo = res;
      this.experiences = res.experiences;
    })

    //React to Experience Update Action
    this.employeeService.experienceUpdateAction$.subscribe((res)=>{
      const experienceIndex = this.experiences.findIndex(exp=>exp.id === res.id)
      if(experienceIndex !== -1){
        this.experiences[experienceIndex] = res;
      }
    }
    )
    //React to profile-image change
    this.employeeService.imageUpdatedAction$.subscribe((res)=>{
      console.log(res);
      this.employeeInfo.profilePictureURL = res;
    })
  
  }

  navigateToEdit(experience: Experience){
  }

}
