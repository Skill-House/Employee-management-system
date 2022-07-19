import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { AdminRoutingModule } from './admin-routing.module';
import { SidebarComponent } from '../shared/sidebar/sidebar.component';
import { SidebarfooterComponent } from '../shared/sidebarfooter/sidebarfooter.component';
import { TopnavComponent } from '../shared/topnav/topnav.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EmployeeComponent } from './employee/employee.component';
import { CompanyComponent } from './company/company.component';
import { EmployeeAddComponent } from './employee/employee-add/employee-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompanyAddComponent } from './company/company-add/company-add.component';
import { CompanyEditComponent } from './company/company-edit/company-edit.component';
import { EmployeeEditComponent } from './employee/employee-edit/employee-edit.component';


@NgModule({
  declarations: [
    AdminComponent,
    SidebarComponent,
    SidebarfooterComponent,
    TopnavComponent,
    DashboardComponent,
    EmployeeComponent,
    CompanyComponent,
    EmployeeAddComponent,
    CompanyAddComponent,
    CompanyEditComponent,
    EmployeeEditComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AdminModule { }
