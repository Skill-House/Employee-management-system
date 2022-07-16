import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyAddModel } from '../../models/company.model';
import { AdminService } from '../../services/admin.service';

@Component({
  selector: 'app-company-edit',
  templateUrl: './company-edit.component.html',
  styleUrls: ['./company-edit.component.css']
})
export class CompanyEditComponent implements OnInit {
 editFormGroup!: FormGroup;
 @Input() companyId: number=0;
 @Output() getAllCompanies= new EventEmitter<any>();
 @Output() closeModelEvent= new EventEmitter<any>();

  constructor(private formBuilder: FormBuilder, private adminService: AdminService) {  }

  ngOnInit(): void {
    this.editFormGroup = this.formBuilder.group({
      companyName: ["", Validators.required],
      address: ["", Validators.required],
      companyPhone: ["", Validators.required],
    });
debugger;
   this.getCompanyById(this.companyId);
  }

  editCompany(){
    let companyModel=<CompanyAddModel>{
      companyId:this.companyId,
      companyName: this.editFormGroup.controls['companyName'].value,
      companyAddress: this.editFormGroup.controls['address'].value,
      companyPhone:this.editFormGroup.controls['companyPhone'].value,
    }
    this.adminService.updateCompany(companyModel).then((data)=>{
      console.log("Updated Successfully")
      this.getAllCompanies.emit();
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

  getCompanyById(id: number){
    this.adminService.getCompanyById(id).subscribe((res)=>{
      this.editFormGroup.patchValue(res)
      this.editFormGroup.controls['address'].setValue(res.companyAddress)
    })

}
}
