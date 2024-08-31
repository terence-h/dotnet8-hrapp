import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { EmployeeService } from '../shared/employee.service';
import { EmployeeDetail } from '../shared/employee-detail.interface';

@Component({
  selector: 'app-employee-detail',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './employee-detail.component.html',
  styleUrl: './employee-detail.component.scss'
})
export class EmployeeDetailComponent implements OnInit {
  route = inject(ActivatedRoute);
  employeeService = inject(EmployeeService);
  employee!: EmployeeDetail;

  ngOnInit(): void {
    const employeeId = this.route.snapshot.paramMap.get('employeeId');

    this.employeeService.getEmployee(employeeId).subscribe({
      next: response => this.employee = response,
      error: error => console.log(error)
    })
  }
}