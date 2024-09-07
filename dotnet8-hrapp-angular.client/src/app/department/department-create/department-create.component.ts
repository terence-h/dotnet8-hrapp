import { Component, inject, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormControl, Validators, FormGroup } from '@angular/forms';
import { DepartmentService } from '../shared/department.service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-department-create',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './department-create.component.html',
  styleUrl: './department-create.component.scss'
})
export class DepartmentCreateComponent implements OnInit {
  router = inject(Router);
  departmentService = inject(DepartmentService);
  departmentForm!: FormGroup<{
    departmentId: FormControl<string | null>;
    departmentName: FormControl<string | null>;
  }>;

  ngOnInit(): void {
    this.departmentForm = new FormGroup({
      departmentId: new FormControl('0'), // unnecessary, but already did it in .NET sadly
      departmentName: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(50), Validators.pattern("^[a-zA-Z ]+$")])
    });
  }

  createDepartment() {
    const jsonStr = JSON.stringify(this.departmentForm.value);

    this.departmentService.createDepartment(jsonStr).subscribe({
      next: resp => { this.router.navigate([`../department/detail/${resp}`]); },
      error: error => { console.log(error); }
    });
  }
}