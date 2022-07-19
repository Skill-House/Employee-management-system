import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first, identity } from 'rxjs';
import { EmployeeAddModel } from '../../models/employee.model';
import { AdminService } from '../../services/admin.service';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css']
})
export class EmployeeAddComponent implements OnInit {
  submitted: boolean = false;
  saveEmployeeForm !: FormGroup;
  employeeAddModel!: EmployeeAddModel;
  date !: Date;
  companyData: any ;
  constructor(private adminService: AdminService, private formBuilder: FormBuilder) {
    this.getAllCompanies();
  }

  ngOnInit(): void {
    this.saveEmployeeForm = this.formBuilder.group({
      fname: ["", Validators.required],
      lname: ["", Validators.required],
      gender: ["", Validators.required],
      companyName: ["", Validators.required],
      email: ["", Validators.required],
      phone: ["", Validators.required]
    });
    this.date = new Date(); 
  }

  get f(): {
    [key: string]: AbstractControl
  } {
    return this.saveEmployeeForm.controls;
  }

  saveEmployee() {
    this.submitted = true;
    if (this.saveEmployeeForm.valid) {
      const fname = this.saveEmployeeForm.controls['fname'].value;
      const lname = this.saveEmployeeForm.controls['lname'].value;
      const gender = this.saveEmployeeForm.controls['gender'].value;
      const companyId = parseInt(this.saveEmployeeForm.controls['companyName'].value);
      const email = this.saveEmployeeForm.controls['email'].value;
      const phone = this.saveEmployeeForm.controls['phone'].value;
      const dateCreated = String(this.date.getFullYear()+'-'+(this.date.getUTCMonth()+1)+'-'+this.date.getUTCDate());
      const dateModified = String(this.date.getFullYear()+'-'+(this.date.getUTCMonth()+1)+'-'+this.date.getDate());
      this.employeeAddModel = {
        firstName: fname,
        lastName: lname,
        gender: gender,
        companyId: companyId,
        email: email,
        phone: phone,
        dateCreated: dateCreated,
        dateModified: dateModified
      };
      this.adminService.saveEmployee(this.employeeAddModel)
      .pipe(first())
      .subscribe(
        data => {
          var employeeDetails = data;
          debugger;
        }
      )
    }
  }

  getAllCompanies()
  {
    this.adminService.GetAllCompanies().subscribe((c)=>
    {
      this.companyData = c;
  })
  }
}
