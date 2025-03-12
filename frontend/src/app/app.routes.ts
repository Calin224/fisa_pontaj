import { Routes } from '@angular/router';
import { LoginComponent } from './features/account/login/login.component';
import { HomeComponent } from './features/home/home.component';
import { RegisterComponent } from './features/account/register/register.component';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'account/login', component: LoginComponent},
    {path: 'account/register', component: RegisterComponent},
];
