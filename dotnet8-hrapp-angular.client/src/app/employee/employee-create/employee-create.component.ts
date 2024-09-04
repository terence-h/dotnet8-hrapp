import { Component, inject, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { EmployeeService } from '../shared/employee.service';
import { DepartmentService } from '../../department/shared/department.service';
import { DepartmentList } from '../../department/shared/department-list.interface';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee-create',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink, BsDatepickerModule, CommonModule],
  templateUrl: './employee-create.component.html',
  styleUrl: './employee-create.component.scss'
})
export class EmployeeCreateComponent implements OnInit {
  router = inject(Router);
  employeeService = inject(EmployeeService);
  departmentService = inject(DepartmentService);
  employeeForm!: FormGroup<{ id: FormControl<number | null>; name: FormControl<string | null>; departmentId: FormControl<string | null>; salary: FormControl<string | null>; gender: FormControl<string | null>; dateOfBirth: FormControl<string | null>; contactCountryCode: FormControl<string | null>; contactNo: FormControl<string | null>; empAddress: FormGroup<{ line1: FormControl<string | null>; line2: FormControl<string | null>; unitNo: FormControl<string | null>; postalCode: FormControl<string | null>; country: FormControl<string | null>; city: FormControl<string | null>; state: FormControl<string | null>; }>; }>;
  departmentList!: DepartmentList[];
  maxDate = new Date();
  maxYear = this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  onInitFinished = false;

  ngOnInit(): void {
    this.departmentService.getDepartments().subscribe({
      next: resp => { this.departmentList = resp; this.onInitFinished = true; }
    })
    this.employeeForm = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(50), Validators.pattern("^[a-zA-Z ]+$")]),
      departmentId: new FormControl('', [Validators.required, Validators.min(100)]),
      salary: new FormControl('', [Validators.required, Validators.min(0)]),
      gender: new FormControl('', [Validators.required, Validators.maxLength(20)]),
      dateOfBirth: new FormControl('', [Validators.required]),
      contactCountryCode: new FormControl('', [Validators.required, Validators.min(0)]),
      contactNo: new FormControl('', [Validators.required, Validators.min(0)]),
      empAddress: new FormGroup({
        line1: new FormControl('', [Validators.required]),
        line2: new FormControl(''),
        unitNo: new FormControl(''),
        postalCode: new FormControl('', [Validators.required, Validators.min(0)]),
        country: new FormControl('', [Validators.required]),
        city: new FormControl(''),
        state: new FormControl('')
      })
    });
  }

  createEmployee() {
    const jsonStr = JSON.stringify(this.employeeForm.value);
    console.log(this.employeeForm.value);
    console.log(jsonStr);

    this.employeeService.createEmployee(jsonStr).subscribe({
      next: resp => { this.router.navigate([`../employee/detail/${resp}`]); },
      error: error => { console.log(error); }
    });
  }
}
