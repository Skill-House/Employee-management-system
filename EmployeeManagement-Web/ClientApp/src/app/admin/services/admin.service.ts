import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EmployeeURLConstants } from "src/app/shared/constants/url-constant";
import { CompanyURLConstants } from "src/app/shared/constants/url-constant";

@Injectable({providedIn:'root'})
export class AdminService{
    constructor(private http:HttpClient){

  }

    getAllEmployee(){
        return this.http.get<any>(EmployeeURLConstants.GET_ALL_EMPLOYEE);
    }
    GetAllCompanies(){
        return this.http.get<any>(CompanyURLConstants.GET_ALL_COMPANIES);
    }
    deleteEmployee(employeeId : number){
        return this.http.delete<any>(EmployeeURLConstants.DELETE_EMPLOYEE+employeeId);
    }
    deleteCompany(companyId : number){
        return this.http.delete<any>(CompanyURLConstants.DELETE_COMPANY+companyId);
    }
}
