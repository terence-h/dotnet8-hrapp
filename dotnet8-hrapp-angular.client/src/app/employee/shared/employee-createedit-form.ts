import { FormGroup, FormControl, Validators } from "@angular/forms";
import { IEmployeeDetail } from "./employee-detail.interface";

export function EmployeeCreateEditForm(employee?: IEmployeeDetail) {
    const hasData = employee != null;
    return new FormGroup({
        id: new FormControl(hasData ? employee.id : 0),
        name: new FormControl(hasData ? employee.name : '', [Validators.required, Validators.minLength(1), Validators.maxLength(50), Validators.pattern("^[a-zA-Z ]+$")]),
        departmentId: new FormControl(hasData ? employee.departmentId : '', [Validators.required, Validators.min(100)]),
        salary: new FormControl(hasData ? employee.salary : '', [Validators.required, Validators.min(0)]),
        gender: new FormControl(hasData ? employee.gender : '', [Validators.required, Validators.maxLength(20)]),
        dateOfBirth: new FormControl(hasData ? new Date(employee.dateOfBirth) : '', [Validators.required]),
        contactCountryCode: new FormControl(hasData ? employee.contactCountryCode : '', [Validators.required, Validators.min(0)]),
        contactNo: new FormControl(hasData ? employee.contactNo : '', [Validators.required, Validators.min(0)]),
        empAddress: new FormGroup({
            line1: new FormControl(hasData ? employee.empAddress.line1 : '', [Validators.required]),
            line2: new FormControl(hasData ? employee.empAddress.line2 : ''),
            unitNo: new FormControl(hasData ? employee.empAddress.unitNo : ''),
            postalCode: new FormControl(hasData ? employee.empAddress.postalCode : '', [Validators.required, Validators.min(0)]),
            country: new FormControl(hasData ? employee.empAddress.country : '', [Validators.required]),
            city: new FormControl(hasData ? employee.empAddress.city : ''),
            state: new FormControl(hasData ? employee.empAddress.state : '')
        })
    });
}