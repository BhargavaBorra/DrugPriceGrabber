import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Control/home/home.component';
import { AdminComponent } from './Control/admin/admin.component';

const routes: Routes = [
  { path: 'Home', component: HomeComponent },
  { path: 'Admin', component: AdminComponent },
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
