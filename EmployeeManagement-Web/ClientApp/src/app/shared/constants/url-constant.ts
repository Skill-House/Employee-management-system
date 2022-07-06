import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;
export class LoginURLConstants {
    static LOGIN = apiUrl + '/user/Login';
}
export class USERURLConstants {
    static GETALL = apiUrl + '/user/GetAllUser';
}
export class EmployeeURLConstants {
    static GET_ALL_EMPLOYEE  = apiUrl + 'api/Employee/GetAllEmployee';
    static DELETE_EMPLOYEE = apiUrl + '/Employee/employeeId';
}
export class CompanyURLConstraints {
    static GET_ALL_COMPANIES = apiUrl + '/api/Company/GetAllCompanies';
}
export class ProjectURLConstants{
    static GET_ALL_PROJECT =apiUrl +'/Project/GetAllProjects';
    static EDIT_ALL_PROJECT = apiUrl + '/Project/UpdateProject';
}