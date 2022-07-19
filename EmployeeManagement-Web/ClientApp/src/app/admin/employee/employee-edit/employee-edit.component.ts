import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeAddModel } from '../../models/employee.model';
import { AdminService } from '../../services/admin.service';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {
  companyData: any ;
  editFormGroup!: FormGroup;
 @Input() companyId: number=0;
 date !: Date;
 @Input()employeeId: number=0;
 @Output() getAllEmployee= new EventEmitter<any>();
 @Output() closeModelEvent= new EventEmitter<any>();

  constructor(private adminService: AdminService, private formBuilder: FormBuilder) {
    this.getAllCompanies();
    this.date = new Date();
  }

  ngOnInit(): void {
    this.editFormGroup = this.formBuilder.group({
      firstName: ["", Validators.required],
      lastName: ["", Validators.required],
      gender: ["", Validators.required],
      companyName: ["", Validators.required],
      email: ["", Validators.required],
      phone: ["", Validators.required]
    });
    this.getEmployeeById(this.employeeId);
  }

  getAllCompanies()
  {
    this.adminService.GetAllCompanies().subscribe((c)=>
    {
      this.companyData = c;
  })
  }

  getEmployeeById(id: number){
    debugger;
    this.adminService.getEmployeeById(id).subscribe((res)=>{
      this.employeeId = res.id;
      this.editFormGroup.patchValue(res);
      this.editFormGroup.controls['companyName'].setValue(res.companyId);
      debugger;
    })
}

editEmployee(){
  let employeeAddModel=<EmployeeAddModel>{
    id:this.employeeId,
    firstName: this.editFormGroup.controls['firstName'].value,
    lastName: this.editFormGroup.controls['lastName'].value,
    gender: this.editFormGroup.controls['gender'].value,
    companyId: parseInt(this.editFormGroup.controls['companyName'].value),
    email: this.editFormGroup.controls['email'].value,
    phone: this.editFormGroup.controls['phone'].value,
    dateModified: String(this.date.getFullYear()+'-'+(this.date.getUTCMonth()+1)+'-'+this.date.getDate())
  }
    this.adminService.updateEmployee(employeeAddModel).then((data)=>{
      console.log("Updated Successfully")
      this.getAllEmployee.emit();
      this.closeModelEvent.emit();
    },
    (error)=>{
      console.log("Something went wrong");
    }
    )
}

get f(): {
  [key: string]: AbstractControl
} {
  return this.editFormGroup.controls;
}

}
