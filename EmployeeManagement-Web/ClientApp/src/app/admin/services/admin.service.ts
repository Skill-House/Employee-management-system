import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable } from "rxjs";
import { EmployeeURLConstants, RoleURLConstants, USERURLConstants } from "src/app/shared/constants/url-constant";
import { CompanyURLConstants, ProjectURLConstants } from "src/app/shared/constants/url-constant";
import { EmployeeAddModel } from "../models/employee.model";
import { CompanyAddModel } from "../models/company.model";
import { ProjectModel } from "../models/project.model";
import { UserModel } from "../models/user.model";
import { ProjectEditModel } from "../models/projecteditmodel";



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

    deleteProject(projectId: number) {
        return this.http.delete<any>(ProjectURLConstants.DELETE_PROJECT + projectId);
    }

    saveEmployee(employeeModel: EmployeeAddModel) {

        return this.http.post<any>(EmployeeURLConstants.SAVE_EMPLOYEE, employeeModel)
            .pipe(
                map((result) => {
                    return result;
                })
            )
    }
    createCompany(companyModel: CompanyAddModel) {
        return this.http.post<any>(CompanyURLConstants.CREATE_COMPANY, companyModel)
            .pipe(
                map((result) => {
                    return result;
                })
            )
    }

    getCompanyById(id: number): Observable<any> {
        return this.http.get<any>(CompanyURLConstants.GET_COMPANY_BY_ID + id)
    }
    updateCompany(companyModel: CompanyAddModel) {

        return this.http.put<any>(CompanyURLConstants.UPDATE_COMPANY, companyModel)
            .toPromise()
            .then((result) => {
                return result;
            })
    }

    getAllProject() {
        return this.http.get<any>(ProjectURLConstants.GET_ALL_PROJECT);
    }
    getAllRoles() {
        return this.http.get<any>(RoleURLConstants.GET_ALL_ROLES);
    }

    getProjectById(projectId: number): Observable<any> {
        return this.http.get<any>(ProjectURLConstants.GET_PROJECT_BY_ID + projectId);
    }

    updateProject(projectEditModel: ProjectEditModel) {
        return this.http.put<any>(ProjectURLConstants.UPDATE_PROJECT, projectEditModel)
            .toPromise()
            .then((result) => {
                return result;
            })
    }

    getEmployeeById(id: number): Observable<any>{
        return this.http.get<any>(EmployeeURLConstants.GET_EMPLOYEE_BY_ID +id)
    }
   
    updateEmployee(employeeAddModel: EmployeeAddModel){
        return this.http.put<any>(EmployeeURLConstants.UPDATE_EMPLOYEE,employeeAddModel)
        .toPromise()
        .then((result)=>{
            return result;
        })
    }
   
    
saveProject(ProjectModel: ProjectModel){
    debugger;
    return this.http.post<any>(ProjectURLConstants.SAVE_PROJECT, ProjectModel)
        .pipe(
            map((result) => {
                return result;
            })

        )
}
saveUser(userModel: UserModel){
    debugger;
    return this.http.post<any>(USERURLConstants.SAVE_USER, userModel)
        .pipe(
            map((result) => {
                return result;

            })
        )
}

}
