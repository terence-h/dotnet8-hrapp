import { Component, inject, OnInit } from '@angular/core';
import { EmployeeService } from '../shared/employee.service';
import { RouterLink } from '@angular/router';
import { EmployeeList } from '../shared/employee-list.interface';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})

export class EmployeeListComponent implements OnInit {
  employeeService = inject(EmployeeService);
  employees!: EmployeeList[];
  onInitFinished = false;

  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe({
      next: response => {this.employees = response; this.onInitFinished = true;},
      error: error => console.log(error)
    });
  }
}