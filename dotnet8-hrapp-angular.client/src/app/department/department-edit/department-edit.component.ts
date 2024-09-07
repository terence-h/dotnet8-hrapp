import { Component, inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { DepartmentService } from '../shared/department.service';
import { DepartmentList } from '../shared/department.interface';

@Component({
  selector: 'app-department-edit',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './department-edit.component.html',
  styleUrl: './department-edit.component.scss'
})
export class DepartmentEditComponent implements OnInit {
  router = inject(Router);
  route = inject(ActivatedRoute);
  currentValues!: DepartmentList;
  departmentService = inject(DepartmentService);
  departmentForm!: FormGroup<{ departmentId: FormControl<number | null>; departmentName: FormControl<string | null>; }>;
  onInitFinished = false;

  ngOnInit(): void {
    const departmentId = this.route.snapshot.paramMap.get('departmentId');

    this.departmentService.getDepartment(departmentId).subscribe({
      next: response => {
        this.currentValues = response;

        this.departmentForm = new FormGroup({
          departmentId: new FormControl(response.departmentId),
          departmentName: new FormControl(response.departmentName, [Validators.required, Validators.minLength(1), Validators.maxLength(50), Validators.pattern("^[a-zA-Z ]+$")])
        });

        this.onInitFinished = true;
      },
      error: error => console.log(error)
    });
  }

  updateDepartment() {
    this.departmentService.updateDepartment(this.departmentForm.value).subscribe({
      next: resp => { this.router.navigate([`../department/detail/${resp}`]); },
      error: error => { console.log(error); }
    });
  }
}
