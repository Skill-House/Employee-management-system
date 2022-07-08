import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs';
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
  constructor(private adminService: AdminService, private formBuilder: FormBuilder) {

  }

  ngOnInit(): void {
    this.saveEmployeeForm = this.formBuilder.group({
      fname: ["", Validators.required],
      lname: ["", Validators.required],
      gender: ["", Validators.required],
      companyName: ["", Validators.required],
      email: ["", Validators.required],
      phone: ["", Validators.required],
      dateCreated: ["", Validators.required],
      dateModified: ["", Validators.required]
    });
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
      const dateCreated = this.saveEmployeeForm.controls['dateCreated'].value;
      const dateModified = this.saveEmployeeForm.controls['dateModified'].value;
      this.employeeAddModel = {
        firstName: fname,
        lastName: lname,
        gender: "male",
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
}
