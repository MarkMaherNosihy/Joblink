import { Component, input } from '@angular/core';
import { Experience } from '../../models/Experience';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-experiences',
  standalone: true,
  imports: [FontAwesomeModule, RouterModule, CommonModule],
  templateUrl: './experiences.component.html',
  styleUrl: './experiences.component.scss'
})
export class ExperiencesComponent {
  experiences = input<Experience[]>();
  editIcon = faEdit;

}
