import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BsModalRef, BsModalService, ModalModule } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ModalModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers:[BsModalService]
})
export class AppComponent implements OnInit {

  title:string = 'client';
  users: any;
  modalRef!: BsModalRef;
  constructor(private httpClient: HttpClient, private modalService: BsModalService){}
  
  ngOnInit(): void {
    this.httpClient.get('https://localhost:5000/api/users').subscribe({
      next: (res)=> {
        console.log(res);
        this.users = res;
      },
      error: (err:any)=>{
        console.log(err);
      },
      complete: ()=>{
        console.log("Done!");
      }
    });
  }

  openModal(template: TemplateRef<void>) {
    this.modalRef = this.modalService.show(template);
  }

}
