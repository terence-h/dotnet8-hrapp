import { Component, inject, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { DepartmentService } from '../shared/department.service';
import { DepartmentList } from '../shared/department-list.interface';

@Component({
  selector: 'app-department-list',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './department-list.component.html',
  styleUrl: './department-list.component.scss'
})
export class DepartmentListComponent implements OnInit {
  departmentService = inject(DepartmentService);
  departments!: DepartmentList[];
  onInitFinished = false;

  ngOnInit(): void {
    this.departmentService.getDepartments().subscribe({
      next: response => {this.departments = response; this.onInitFinished = true;},
      error: error => console.log(error)
    });
  }
}