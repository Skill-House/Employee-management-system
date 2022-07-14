import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs";
import { EmployeeURLConstants } from "src/app/shared/constants/url-constant";
import { CompanyURLConstants, ProjectURLConstants } from "src/app/shared/constants/url-constant";
import { EmployeeAddModel } from "../models/employee.model";
import { CompanyAddModel } from "../models/company.model";


@Injectable({ providedIn: 'root' })
export class AdminService {
    constructor(private http: HttpClient) {

    }

    getAllEmployee() {
        return this.http.get<any>(EmployeeURLConstants.GET_ALL_EMPLOYEE);
    }
    GetAllCompanies() {
        return this.http.get<any>(CompanyURLConstants.GET_ALL_COMPANIES);
    }
    deleteEmployee(employeeId: number) {
        return this.http.delete<any>(EmployeeURLConstants.DELETE_EMPLOYEE + employeeId);
    }
    deleteCompany(companyId: number) {
        return this.http.delete<any>(CompanyURLConstants.DELETE_COMPANY + companyId);
    }

    saveEmployee(employeeModel: EmployeeAddModel) {
        debugger;
        return this.http.post<any>(EmployeeURLConstants.SAVE_EMPLOYEE, employeeModel)
            .pipe(
                map((result) =>{
                    return result;
                })
            )
    }
    createCompany(companyModel: CompanyAddModel) {
        return this.http.post<any>(CompanyURLConstants.CREATE_COMPANY, companyModel)
            .pipe(
                map((result) =>{
                    return result;
                })
            )
    }
    getAllProject() {        return this.http.get<any>(ProjectURLConstants.GET_ALL_PROJECT);
    }

}
