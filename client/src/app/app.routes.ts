import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { JobsListComponent } from './jobs-list/jobs-list.component';
import { JobDetailComponent } from './jobs-list/job-detail/job-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { RegisterComponent } from './register/register.component';
import { CredsComponent } from './creds/creds.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
    {path: '', component: HomeComponent},

    {path: '', runGuardsAndResolvers: 'always', canActivate: [authGuard], children: [
        {path: 'jobs', component: JobsListComponent,},
        {path: 'jobs/:id', component: JobDetailComponent, },
        {path: 'messages', component: MessagesComponent, },

    ] },
    {path: 'login', component: CredsComponent},
    {path: 'register', component: RegisterComponent},

    {path: '**', component: HomeComponent, pathMatch: 'full'}

];
