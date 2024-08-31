import { formatDate } from "@angular/common";
import { Address } from "./employee-address.interface";
import { IEmployeeDetail } from "./employee-detail.interface";

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

    constructor(data: EmployeeDetail) {
        Object.assign(this, data);
    }

    getFormattedDateOfBirth(): string {
        return formatDate(this.dateOfBirth, 'dd/MM/yyyy', 'en-SG');
    }

    getAgeFromDateOfBirth(): number {
        let today = new Date();
        let dob = new Date(this.dateOfBirth);

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