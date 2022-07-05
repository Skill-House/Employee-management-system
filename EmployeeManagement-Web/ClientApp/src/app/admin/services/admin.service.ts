import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CompanyURLConstraints, EmployeeURLConstants, ProjectURLConstants } from "src/app/shared/constants/url-constant";

@Injectable({providedIn:'root'})
export class AdminService{
    constructor(private http:HttpClient){

    }
    
    getAllEmployee(){
        debugger;
        return this.http.get<any>(EmployeeURLConstants.GET_ALL_EMPLOYEE);
    }
    GetAllCompanies(){
        debugger;
        return this.http.get<any>(CompanyURLConstraints.GET_ALL_COMPANIES);
    }
    getAllProject(){
        debugger;
        return this.http.get<any>(ProjectURLConstants.GET_ALL_PROJECT);
    }

}
