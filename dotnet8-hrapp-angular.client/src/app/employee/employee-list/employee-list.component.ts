import { Component, inject, OnInit } from '@angular/core';
import { EmployeeService } from '../shared/employee.service';
import { Router, RouterLink } from '@angular/router';
import { EmployeeModel } from '../shared/employee.model';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})

export class EmployeeListComponent implements OnInit {
  employeeService = inject(EmployeeService);
  router = inject(Router);

  employees!: EmployeeModel[];

  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe(data => {
      this.employees = data;
    });
  }
}