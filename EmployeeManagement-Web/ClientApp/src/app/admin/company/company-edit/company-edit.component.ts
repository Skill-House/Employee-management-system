import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  constructor(private formBuilder: FormBuilder, private adminService: AdminService) {  }

  ngOnInit(): void {
    this.editFormGroup = this.formBuilder.group({
      cname: ["", Validators.required],
      address: ["", Validators.required],
      phone: ["", Validators.required],
    });
debugger;
   this.getCompanyById(this.companyId);
  }

  editCompany(){
    let companyModel=<CompanyAddModel>{
      companyId:1,
      companyName: "Infy",
      companyAddress: "Mangalore",
      companyPhone:"9876665432",
    }
    this.adminService.updateCompany(companyModel).then((data)=>{
      console.log("Updated Successfully")
    })

  }

  getCompanyById(id: number){
    this.adminService.getCompanyById(id).subscribe((res)=>{
      debugger;
  
    })

}
}
