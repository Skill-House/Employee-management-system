import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;
export class LoginURLConstants {
    static LOGIN = apiUrl + '/user/Login';
}
export class USERURLConstants {
    static GETALL = apiUrl + '/user/GetAllUser';
}
export class EmployeeURLConstants {
    static GET_ALL_EMPLOYEE  = apiUrl + '/api/employee/GetAllEmployee';
    static DELETE_EMPLOYEE = apiUrl + '/api/employee/';
}
export class CompanyURLConstraints {
    static GET_ALL_COMPANIES = apiUrl + '/Company/GetAllCompanies';
}
export class ProjectURLConstants{
    static GET_ALL_PROJECT =apiUrl +'/Project/GetAllCompanies';
}