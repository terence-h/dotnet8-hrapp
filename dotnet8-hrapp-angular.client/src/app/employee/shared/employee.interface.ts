export interface EmployeeList {
    id: number;
    name: string;
    salary: number;
    departmentId: number;
    departmentName?: string;
}

export interface IEmployeeDetail {
    id: number;
    name: string;
    salary: number;
    gender: string;
    dateOfBirth: Date;
    contactCountryCode: number;
    contactNo: number;
    departmentId: number;
    departmentName?: string;
    empAddress: Address;
}

export interface Address {
    line1: string;
    line2?: string;
    unitNo?: string;
    postalCode: number;
    country: string;
    city?: string;
    state?: string;
}