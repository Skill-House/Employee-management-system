import { Component, OnInit } from '@angular/core';
import { AdminService } from '../services/admin.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
})
export class EmployeeComponent implements OnInit {
  employeeData: any;
  isUpdateEmployee: boolean=false;
  employeeId: number=0;

    constructor(private adminService: AdminService, private router: Router) {
    this.getAllEmployees();
  }

  ngOnInit(): void {}

  getAllEmployees() {
    this.adminService.getAllEmployee().subscribe((e) => {
      debugger;
      this.employeeData = e;
    });
  }

  deleteEmployee(employeeId : number){
      this.adminService.deleteEmployee(employeeId).subscribe((e)=>{
        if(e==200)
          console.log("Deleted Successfully")
        else
          console.log("This record is not Found")
        this.getAllEmployees();
      })      
  }

  addEmployee(){
    debugger;
    this.router.navigate(["admin/Employee/add-employee"]);
  }

  updateEmployee(employeeId: number){
    debugger;
      this.employeeId=employeeId;
      this.isUpdateEmployee=true;  
    }

    closeModelEvent() {
      this.isUpdateEmployee = false;
    }

}
