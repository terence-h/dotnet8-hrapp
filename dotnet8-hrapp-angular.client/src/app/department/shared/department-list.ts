import { IEmployeeDetail } from "../../employee/shared/employee-detail.interface";

export interface DepartmentList {
    departmentId: number;
    departmentName: string;
    employees: IEmployeeDetail[];
}