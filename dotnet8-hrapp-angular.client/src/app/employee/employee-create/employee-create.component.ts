import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { EmployeeService } from '../shared/employee.service';
import { DepartmentService } from '../../department/shared/department.service';
import { DepartmentList } from '../../department/shared/department.interface';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { EmployeeCreateEditForm } from '../shared/employee-createedit-form';

@Component({
  selector: 'app-employee-create',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink, BsDatepickerModule],
  templateUrl: './employee-create.component.html',
  styleUrl: './employee-create.component.scss'
})
export class EmployeeCreateComponent implements OnInit {
  router = inject(Router);
  employeeService = inject(EmployeeService);
  departmentService = inject(DepartmentService);
  employeeForm!: FormGroup<{ id: FormControl<number | null>; name: FormControl<string | null>; departmentId: FormControl<string | number | null>; salary: FormControl<string | number | null>; gender: FormControl<string | null>; dateOfBirth: FormControl<string | Date | null>; contactCountryCode: FormControl<string | number | null>; contactNo: FormControl<string | number | null>; empAddress: FormGroup<{ line1: FormControl<string | null>; line2: FormControl<string | null | undefined>; unitNo: FormControl<string | null | undefined>; postalCode: FormControl<string | number | null>; country: FormControl<string | null>; city: FormControl<string | null | undefined>; state: FormControl<string | null | undefined>; }>; }>
  departmentList!: DepartmentList[];
  maxDate = new Date();
  maxYear = this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  onInitFinished = false;

  ngOnInit(): void {
    this.departmentService.getDepartments().subscribe({
      next: resp => { this.departmentList = resp; this.onInitFinished = true; }
    })
    this.employeeForm = EmployeeCreateEditForm();
  }

  createEmployee() {
    const jsonStr = JSON.stringify(this.employeeForm.value);

    this.employeeService.createEmployee(jsonStr).subscribe({
      next: resp => { this.router.navigate([`../employee/detail/${resp}`]); },
      error: error => { console.log(error); }
    });
  }
}
