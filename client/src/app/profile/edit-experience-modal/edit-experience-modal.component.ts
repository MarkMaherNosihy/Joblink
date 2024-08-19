import { AfterContentChecked, AfterContentInit, AfterViewChecked, AfterViewInit, Component,  inject, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faCalendar, faEdit } from '@fortawesome/free-solid-svg-icons';
import {
  NgbDate,
  NgbDatepickerModule,
  NgbDateStruct,
  NgbModal,
} from '@ng-bootstrap/ng-bootstrap';
import { Experience } from '../../models/Experience';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ToastService } from '../../services/ui/toast.service';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-edit-experience-modal',
  standalone: true,
  imports: [FontAwesomeModule, NgbDatepickerModule, FormsModule, CommonModule],
  templateUrl: './edit-experience-modal.component.html',
  styleUrl: './edit-experience-modal.component.scss',
})
export class EditExperienceModalComponent implements OnInit, AfterViewInit {
  @ViewChild('editForm') editForm?: NgForm;
  @ViewChild('content') modalContent?: TemplateRef<any>;
  private modalService = inject(NgbModal);
  editIcon = faEdit;
  calendarIcon = faCalendar;
  ngbStartDate!: NgbDateStruct;
  ngbEndDate!: NgbDateStruct;
  toastService = inject(ToastService);
  activeRoute = inject(ActivatedRoute);
  empService = inject(EmployeeService);
  router = inject(Router);
  @Input() CurrentExperience!: Experience;


  ngOnInit(): void {
    this.CurrentExperience = history.state;
    this.ngbStartDate = this.convertToNgbDate(this.CurrentExperience.startDate);
    this.ngbEndDate = this.convertToNgbDate(this.CurrentExperience.endDate);
  }
  ngAfterViewInit(): void {
    this.modalService.open(this.modalContent, { ariaLabelledBy: 'modal-basic-title', backdrop: 'static' });
    console.log(this.editForm);
  }

  convertToNgbDate(date: string){
    const parts = date.split('-');
    const year = parseInt(parts[0], 10);
    const month = parseInt(parts[1], 10);
    const day = parseInt(parts[2], 10);
    let res: NgbDateStruct =  new NgbDate(year,month,day);
    return res;
  }
  convertNgbDateToDate(date: NgbDateStruct){
    return `${date.year}-${date.month}-${date.day}`;
  }

  open(content: TemplateRef<any>) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((res)=>{});
  }
  closeModal(modal: any){
    if(this.editForm?.dirty){
      if(confirm("You have unsaved changes, are you sure you want to leave?")){
        modal.close();
        this.router.navigateByUrl('profile')

      }else{
        console.log('Closed');
        return;
      }
    }
    modal.close();
    this.router.navigateByUrl('profile')


  }

  SaveChanges(){

    this.CurrentExperience.startDate = '2020-10-10';
    this.CurrentExperience.endDate ='2020-10-10';
    console.log(this.CurrentExperience.startDate);

    this.empService.updateEmployeeExperience(this.CurrentExperience).subscribe({next: (res)=>{
      this.empService.experienceChanged(res as Experience);
    }, complete: ()=>{
    }});
    this.editForm?.resetForm();
    this.router.navigateByUrl('profile');
    this.modalService.dismissAll();
  }

}
