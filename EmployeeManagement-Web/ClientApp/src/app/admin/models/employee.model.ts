export class EmployeeAddModel {
    id?: number ; 
    firstName: string = "";
    lastName: string = "";
    gender: string = "";
    email: string = "";
    phone: string = "";
    dateCreated?: string = "";
    dateModified?: string = "";
    companyId: number = 0;
}