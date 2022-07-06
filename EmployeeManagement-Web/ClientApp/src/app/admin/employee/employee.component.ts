import { Component, OnInit } from '@angular/core';
import { AdminService } from '../services/admin.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employeeData : any ;

  constructor(private adminService : AdminService)
   {
    this.getAllEmployees();
  }

  ngOnInit(): void {
  }

  getAllEmployees(){
   
    this.adminService.getAllEmployee().subscribe((e)=>
    {
        debugger;
        this.employeeData = e ;
    }
    )
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
}
