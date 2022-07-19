import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;
export class LoginURLConstants {
    static LOGIN = apiUrl + '/user/Login';
}
export class USERURLConstants {
    static GETALL = apiUrl + '/user/GetAllUser';
    static SAVE_USER = apiUrl +'/user/SaveUser';
}
export class EmployeeURLConstants {
    static GET_ALL_EMPLOYEE  = apiUrl + '/employee/GetAllEmployee';
    static DELETE_EMPLOYEE = apiUrl + '/employee/';
    static SAVE_EMPLOYEE = apiUrl + '/employee/SaveEmployee';
}
export class CompanyURLConstants {
    static GET_ALL_COMPANIES = apiUrl + '/company/GetAllCompanies';
    static DELETE_COMPANY  = apiUrl + '/company/';
    static CREATE_COMPANY = apiUrl + '/company/CreateCompany';
    static GET_COMPANY_BY_ID = apiUrl + '/company/GetCompany/';
    static UPDATE_COMPANY = apiUrl + '/company/UpdateCompany';
}

export class ProjectURLConstants{
    static GET_ALL_PROJECT = apiUrl +'/Project/GetAllProjects';
    static EDIT_ALL_PROJECT = apiUrl + '/Project/UpdateProject';
    static SAVE_PROJECT = apiUrl + '/Project/SaveProject';
}
export class RoleURLConstants{
    static GET_ALL_ROLES = apiUrl +'/Role/GetAllRoles';
}
