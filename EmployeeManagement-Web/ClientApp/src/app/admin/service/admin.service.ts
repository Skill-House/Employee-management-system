import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CompanyURLConstraints, EmployeeURLConstraints } from "src/app/shared/constants/url-constant";
@Injectable({providedIn: 'root'})

export class AdminService{
    constructor(private http:HttpClient){}
    
    getAllEmployee(){
        return this.http.get<any>(EmployeeURLConstraints.GET_ALL_EMPLOYEE);
    }

    GetAllCompanies(){
        
        return this.http.get<any>(CompanyURLConstraints.GET_ALL_COMPANIES);
    }


}