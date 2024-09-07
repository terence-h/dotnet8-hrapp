import { Address } from "./employee.interface";
import { IEmployeeDetail } from "./employee.interface";

export class EmployeeDetail implements IEmployeeDetail {
    id!: number;
    name!: string;
    salary!: number;
    gender!: string;
    dateOfBirth!: Date;
    contactCountryCode!: number;
    contactNo!: number;
    departmentId!: number;
    departmentName?: string | undefined;
    empAddress!: Address;

    constructor(data: IEmployeeDetail) {
        Object.assign(this, data);
    }

    getAgeFromDateOfBirth(): number {
        const today = new Date();
        const dob = new Date(this.dateOfBirth);

        let age = today.getFullYear() - dob.getFullYear();
        const monthDiff = today.getMonth() - dob.getMonth();
        const dayDiff = today.getDate() - dob.getDate();

        // Adjust age if the birthdate has not occurred yet this year
        if (monthDiff < 0 || (monthDiff === 0 && dayDiff < 0)) {
            age--;
        }

        return age;
    }
}