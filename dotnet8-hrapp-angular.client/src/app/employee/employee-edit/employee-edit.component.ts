import { Component, inject } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { DepartmentList } from '../../department/shared/department-list.interface';
import { DepartmentService } from '../../department/shared/department.service';
import { EmployeeCreateEditForm } from '../shared/employee-createedit-form';
import { EmployeeService } from '../shared/employee.service';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { IEmployeeDetail } from '../shared/employee-detail.interface';

@Component({
  selector: 'app-employee-edit',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink, BsDatepickerModule],
  templateUrl: './employee-edit.component.html',
  styleUrl: './employee-edit.component.scss'
})
export class EmployeeEditComponent {
  router = inject(Router);
  route = inject(ActivatedRoute);
  employeeService = inject(EmployeeService);
  departmentService = inject(DepartmentService);
  employeeInfo!: IEmployeeDetail;
  employeeForm!: FormGroup<{ id: FormControl<number | null>; name: FormControl<string | null>; departmentId: FormControl<string | number | null>; salary: FormControl<string | number | null>; gender: FormControl<string | null>; dateOfBirth: FormControl<string | Date | null>; contactCountryCode: FormControl<string | number | null>; contactNo: FormControl<string | number | null>; empAddress: FormGroup<{ line1: FormControl<string | null>; line2: FormControl<string | null | undefined>; unitNo: FormControl<string | null | undefined>; postalCode: FormControl<string | number | null>; country: FormControl<string | null>; city: FormControl<string | null | undefined>; state: FormControl<string | null | undefined>; }>; }>
  departmentList!: DepartmentList[];
  maxDate = new Date();
  maxYear = this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  onInitFinished = [false, false];

  ngOnInit(): void {
    const employeeId = this.route.snapshot.paramMap.get('employeeId');

    this.employeeService.getEmployee(employeeId).subscribe({
      next: resp => {
        this.employeeForm = EmployeeCreateEditForm(resp);
        this.onInitFinished[0] = true;
      },
      error: error => console.log(error)
    })


    this.departmentService.getDepartments().subscribe({
      next: resp => { this.departmentList = resp; this.onInitFinished[1] = true; },
      error: error => console.log(error)
    });
  }

  updateEmployee() {
    this.employeeService.updateEmployee(this.employeeForm.value).subscribe({
      next: resp => { this.router.navigate([`../employee/detail/${resp}`]); },
      error: error => { console.log(error); }
    });
  }
}
