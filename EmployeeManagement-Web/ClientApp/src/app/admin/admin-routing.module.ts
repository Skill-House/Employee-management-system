import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EmployeeComponent } from './employee/employee.component';
import { CompanyComponent } from './company/company.component';
import { ProjectComponent } from '../project/project.component';
import { EmployeeAddComponent } from './employee/employee-add/employee-add.component';
import { CompanyAddComponent } from './company/company-add/company-add.component';
import { ProjectAddComponent } from '../project/project-add/project-add.component';
import { LoginComponent } from '../login/login.component';
const routes: Routes = [
 
{
  path: '',
  component: DashboardComponent
},
{
  path: 'Empolyee',
  component: EmployeeComponent
},
{
  path: 'Company',
  component: CompanyComponent
},
{
  path: 'Project',
  component:  ProjectComponent
},
{
  path: 'Project/add-project',
  component:  ProjectAddComponent
},

{
  path: 'Roles',
  component: LoginComponent
},
{
  path: 'User/add-user',
  component: LoginComponent
},
{
  path: 'Employee/add-employee',
  component: EmployeeAddComponent
},
{
  path: 'Company/add-company',
  component: CompanyAddComponent
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
