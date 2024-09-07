import { Component, inject, OnInit } from '@angular/core';
import { DepartmentService } from '../shared/department.service';
import { DepartmentList } from '../shared/department.interface';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AccordionModule } from 'ngx-bootstrap/accordion';

@Component({
  selector: 'app-department-detail',
  standalone: true,
  imports: [RouterLink, CommonModule, AccordionModule],
  templateUrl: './department-detail.component.html',
  styleUrl: './department-detail.component.scss'
})
export class DepartmentDetailComponent implements OnInit {
  route = inject(ActivatedRoute);
  departmentService = inject(DepartmentService);
  department!: DepartmentList;
  onInitFinished = false;

  ngOnInit(): void {
    const departmentId = this.route.snapshot.paramMap.get('departmentId');

    this.departmentService.getDepartment(departmentId).subscribe({
      next: response => {
        this.department = response;
        this.onInitFinished = true;
      },
      error: error => console.log(error)
    });
  }
}
