import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AlertModule } from 'ngx-bootstrap/alert';
import { AdminService } from '../shared/admin.service';
import { Router, RouterLink } from '@angular/router';
import { EmployeeCreateEditForm } from '../../employee/shared/employee-createedit-form';
import { DepartmentService } from '../../department/shared/department.service';
import { DepartmentList } from '../../department/shared/department.interface';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule, AlertModule, BsDatepickerModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit {
  adminService = inject(AdminService);
  departmentService = inject(DepartmentService);
  router = inject(Router);
  registerForm!: FormGroup<{ username: FormControl<string | null>; password: FormControl<string | null>; employee: FormGroup<{ id: FormControl<number | null>; name: FormControl<string | null>; departmentId: FormControl<string | number | null>; salary: FormControl<string | number | null>; gender: FormControl<string | null>; dateOfBirth: FormControl<string | Date | null>; contactCountryCode: FormControl<string | number | null>; contactNo: FormControl<string | number | null>; empAddress: FormGroup<{ line1: FormControl<string | null>; line2: FormControl<string | null | undefined>; unitNo: FormControl<string | null | undefined>; postalCode: FormControl<string | number | null>; country: FormControl<string | null>; city: FormControl<string | null | undefined>; state: FormControl<string | null | undefined>; }>; }>; }>
  registerErrorMsg = '';
  partTwoForm = false;
  departmentList!: DepartmentList[];
  maxDate = new Date();
  maxYear = this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  onInitFinished = false;

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      username: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(24)]),
      password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(24)]),
      employee: EmployeeCreateEditForm()
    });

    this.departmentService.getDepartments().subscribe({
      next: resp => { this.departmentList = resp; this.onInitFinished = true; }
    })

    this.onInitFinished = true;
  }

  isFormPartOneInvalid(): boolean {
    return this.registerForm.controls.username.hasError('required') || this.registerForm.controls.password.hasError('required');
  }

  toggleFormPart(): void {
    this.partTwoForm = !this.partTwoForm;
  }

  register(): void {
    this.adminService.register(this.registerForm.value).subscribe({
      next: () => { this.router.navigate(['../admin/userlist'])},
      error: error => { this.registerErrorMsg = error?.error?.message }
    });
  }
}