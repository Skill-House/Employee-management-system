import { Component, OnInit } from '@angular/core';
import { AdminService } from '../service/admin.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employeeData : any;
  constructor(private adminService: AdminService) {

    this.getAllEmployee();
   }


  ngOnInit(): void {
  }
  getAllEmployee(){
    this.adminService.getAllEmployee().subscribe((e)=>
    {
      this.employeeData = e;
      debugger;
    })
  }

}
