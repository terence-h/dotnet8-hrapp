export class EmployeeModel {
    id!: number;
    name!: string;
    salary!: number;
    departmentId!: number;
    departmentName?: string;

    constructor(data: any) {
        this.id = data.id;
        this.name = data.name;
        this.salary = data.salary;
        this.departmentId = data.departmentId;
        this.departmentName = data?.departmentName;
    }
}
