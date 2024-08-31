import { Address } from "./employee-address.interface";

export interface EmployeeDetail {
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