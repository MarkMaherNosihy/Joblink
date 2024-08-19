import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { TextInputComponent } from "../_forms/text-input/text-input.component";
import { NgbCalendar, NgbDate, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';
import { ToastService } from '../services/ui/toast.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, TextInputComponent, NgbDatepickerModule, FontAwesomeModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit {
  model: any = {};
  validationErrors: string[] = [];
  registerForm: FormGroup = new FormGroup({});
  calendarIcon = faCalendar;
  private authService = inject(AuthService);
  private fb = inject(FormBuilder);
  private router = inject(Router);
  private toast = inject(ToastService);




  ngOnInit(): void {
    this.initializeForm();
  }
  register(){
    const Ngbdate: NgbDate = this.registerForm.get('dateOfBirth')?.value;
    let dob: string = `${Ngbdate.year}-${Ngbdate.month}-${Ngbdate.day}`
    this.registerForm.get('dateOfBirth')?.setValue(dob);
    this.authService.register(this.registerForm.value).subscribe({
      next: _=>this.router.navigateByUrl('/login'),
      error: (err)=> this.toast.show('Sign up failed', err, 'danger')
    })


  }


  initializeForm(){
    this.registerForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(4)]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(32)]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]],
      gender: ['male'],
      dateOfBirth:['', Validators.required],
      Country: ['', Validators.required],
      City: ['', Validators.required],
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],

    })
    this.registerForm.controls['password'].valueChanges.subscribe({
      next: ()=> this.registerForm.controls['confirmPassword'].updateValueAndValidity()
    })
  }

  matchValues(matchTo: string): ValidatorFn{
    return (control: AbstractControl)=>{
      return control.value === control.parent?.get(matchTo)?.value ? null : {isMatching: true}
    }
  }
}
