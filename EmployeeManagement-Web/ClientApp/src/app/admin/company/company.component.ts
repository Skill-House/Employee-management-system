import { Component, OnInit } from '@angular/core';
import { AdminService } from '../service/admin.service';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {

  companyData: any ;

  constructor(private adminService : AdminService) {

    this.getAllCompanies();
   }

  ngOnInit(): void {
  }

  getAllCompanies()
  {
    this.adminService.GetAllCompanies().subscribe((c)=>
    {
      this.companyData = c;
  })
  }
}
