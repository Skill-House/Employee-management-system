import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../services/admin.service';


@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {

  companyData: any;
  isUpdateCompany: boolean = false;
  companyId: number = 0;

  constructor(private adminService: AdminService, private router: Router) {

    this.getAllCompanies();
  }

  ngOnInit(): void {

  }

  getAllCompanies() {
    this.adminService.GetAllCompanies().subscribe((c) => {
      this.companyData = c;
    })
  }

  deleteCompany(companyId: number) {

    this.adminService.deleteCompany(companyId).subscribe((c) => {
      if (c == 200)
        console.log("Deleted Successfully")
      else
        console.log("This record is not Found")
      this.getAllCompanies();
    })
  }

  updateCompany(companyId: number) {
    this.companyId = companyId;
    this.isUpdateCompany = true;
  }

  addCompany() {
    this.router.navigate(["admin/Company/add-company"]);
  }

  closeModelEvent() {
    this.isUpdateCompany = false;
  }

}
