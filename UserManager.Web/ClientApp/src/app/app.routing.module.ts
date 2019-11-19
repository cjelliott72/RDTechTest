import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserListComponent } from './components/user-list/user-list.component';
import { UserDetailComponent } from './components/user-detail/user-detail.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';

const routes: Routes = [
    { path: 'user-list', component: UserListComponent },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'user-detail/:id', component: UserDetailComponent },
    { path: 'home', component: HomeComponent },
    { path: 'about', component: AboutComponent},
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
