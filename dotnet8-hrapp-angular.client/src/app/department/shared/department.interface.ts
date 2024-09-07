import { IEmployeeDetail } from "../../employee/shared/employee.interface";

export interface DepartmentList {
    departmentId: number;
    departmentName: string;
    employees: IEmployeeDetail[];
}

export interface DepartmentCreateEdit {
    departmentId: number;
    departmentName: string;
}