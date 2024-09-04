import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { EmployeeService } from '../shared/employee.service';
import { DepartmentService } from '../../department/shared/department.service';
import { DepartmentList } from '../../department/shared/department-list.interface';

@Component({
  selector: 'app-employee-create',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './employee-create.component.html',
  styleUrl: './employee-create.component.scss'
})
export class EmployeeCreateComponent implements OnInit {
  router = inject(Router);
  employeeService = inject(EmployeeService);
  departmentService = inject(DepartmentService);
  employeeForm: any;
  departmentList!: DepartmentList[];
  onInitFinished = false;

  ngOnInit(): void {
    this.departmentService.getDepartments().subscribe({
      next: resp => { this.departmentList = resp; this.onInitFinished = true; }
    })
    this.employeeForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(50), Validators.pattern("^[a-zA-Z ]+$")]),
      departmentId: new FormControl('', [Validators.required])
    });
  }

  createEmployee() {
    const jsonStr = JSON.stringify(this.employeeForm.value);

    this.employeeService.createEmployee(jsonStr).subscribe({
      next: resp => { this.router.navigate([`../employee/detail/${resp}`]); },
      error: error => { console.log(error); }
    });
  }
}
