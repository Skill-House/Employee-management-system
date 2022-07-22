import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyAddModel } from '../../models/company.model';
import { first } from 'rxjs';
import { AdminService } from '../../services/admin.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';


declare var NgForm:any;

@Component({
  selector: 'app-company-add',
  templateUrl: './company-add.component.html',
  styleUrls: ['./company-add.component.css']
})
export class CompanyAddComponent implements OnInit {

  submitted: boolean = false;
  saveCompanyForm !: FormGroup;
  companyAddModel!: CompanyAddModel;


  constructor(private adminService:AdminService, private formBuilder: FormBuilder, private router: Router, private location:Location) { }

  ngOnInit(): void {

    this.saveCompanyForm = this.formBuilder.group({
      cname: ["", Validators.required],
      address: ["", Validators.required],
      phone: ["", Validators.required],
    });
  }

  get f(): {
    [key: string]: AbstractControl
  } {
    return this.saveCompanyForm.controls;
  }

  createCompany() {
    this.submitted = true;
    if (this.saveCompanyForm.valid) {
      const cname = this.saveCompanyForm.controls['cname'].value;
      const address = this.saveCompanyForm.controls['address'].value;
      const phone = this.saveCompanyForm.controls['phone'].value;
      this.companyAddModel = {
        companyName: cname,
        companyAddress: address,
        companyPhone: phone
        
      };
      this.adminService.createCompany(this.companyAddModel)
      .pipe(first())
      .subscribe(
        data => {
        this.router.navigate(['/admin/Company']);
        }
      )
}
  }


  get fval() {
    return this.saveCompanyForm.controls;
    }

    signup(){
      this.submitted = true;
      if (this.saveCompanyForm.invalid) {
      return;
      }
      }

      back(){
        this.location.back()
      }
}
