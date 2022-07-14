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
