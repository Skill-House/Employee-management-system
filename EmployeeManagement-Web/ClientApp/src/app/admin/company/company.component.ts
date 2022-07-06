import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from '../services/admin.service';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {

  companyData: any ;

  constructor(private adminService : AdminService, private route : ActivatedRoute) {
 
   }

  ngOnInit(): void {

    this.getAllCompanies();

  }

  getAllCompanies()
  {
    this.adminService.GetAllCompanies().subscribe((c)=>
    {
      this.companyData = c;
  })
  }

  deleteCompany(companyId: number)
  {
    
    this.adminService.deleteCompany(companyId).subscribe((c)=>{
      if(c==200)
        console.log("Deleted Successfully")
      else
        console.log("This record is not Found")

      this.getAllCompanies();
    })

    
    
    
}
}
