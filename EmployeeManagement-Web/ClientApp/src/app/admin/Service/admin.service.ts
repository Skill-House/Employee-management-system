import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EmployeeURLConstants } from "src/app/shared/constants/url-constant";

 @Injectable({providedIn:'root'})
 export class AdminService{
    constructor(private http:HttpClient)
    {

    }
    getAllEmployee(){
    debugger;
    return this.http.get<any>(EmployeeURLConstants.Get_All_EMPLOYEE);
    }
 }