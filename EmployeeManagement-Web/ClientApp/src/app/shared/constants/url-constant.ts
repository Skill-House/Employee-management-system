import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;
export class LoginURLConstants {
    static LOGIN = apiUrl + '/user/Login';
}
export class USERURLConstants {
    static GETALL = apiUrl + '/user/GetAllUser';
}
export class EmployeeURLConstraints{
    static GET_ALL_EMPLOYEE = apiUrl + '/Employee/GetAllEmployee';
}
export class CompanyURLConstraints{
    static GET_ALL_COMPANIES = apiUrl + '/Company/GetAllCompanies';
}