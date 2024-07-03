import { CommonModule } from '@angular/common';
import { Component, OnInit, TemplateRef, inject } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faRightToBracket } from '@fortawesome/free-solid-svg-icons';
import { faPen } from '@fortawesome/free-solid-svg-icons';
import { NgbDropdownModule, NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import { faRightFromBracket } from '@fortawesome/free-solid-svg-icons';
import { faMessage } from '@fortawesome/free-solid-svg-icons';
import { faUser } from '@fortawesome/free-solid-svg-icons';


import { AuthService } from '../services/auth.service';
import { Router, RouterModule } from '@angular/router';
@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FontAwesomeModule, CommonModule, NgbDropdownModule, RouterModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent implements OnInit {
  authService = inject(AuthService);
  router = inject(Router);

  private offCanvasService = inject(NgbOffcanvas);

  loginIcon = faRightToBracket;
  registerIcon = faPen;
  sideBarIcon = faBars;
  logoutIcon = faRightFromBracket;
  messagesIcon = faMessage;
  userIcon = faUser;


  showSideBar: boolean = false;
  isLoggedIn!: boolean;

  ngOnInit(): void {
    this.authService.getIsLoggedIn().subscribe((res)=>{
      this.isLoggedIn = res;
    })
  }

  openSidebar(content: TemplateRef<any>){
    this.offCanvasService.open(content, {position: 'end'});
  }
  logout(){
    this.authService.logout();
    this.router.navigateByUrl('/home');
  }
}
