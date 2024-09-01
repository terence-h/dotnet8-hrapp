import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { EmployeeService } from '../shared/employee.service';
import { EmployeeDetail } from '../shared/employee-detail.model';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { CommonModule, CurrencyPipe, DatePipe } from '@angular/common';

@Component({
  selector: 'app-employee-detail',
  standalone: true,
  imports: [RouterOutlet, CommonModule, AccordionModule, DatePipe, CurrencyPipe],
  templateUrl: './employee-detail.component.html',
  styleUrl: './employee-detail.component.scss'
})
export class EmployeeDetailComponent implements OnInit {
  route = inject(ActivatedRoute);
  employeeService = inject(EmployeeService);
  employee!: EmployeeDetail;
  onInitFinished = false;

  ngOnInit(): void {
    const employeeId = this.route.snapshot.paramMap.get('employeeId');

    this.employeeService.getEmployee(employeeId).subscribe({
      next: response => {
        let employeeRef: EmployeeDetail = new EmployeeDetail(response);
        this.employee = employeeRef;
        this.onInitFinished = true;
      },
      error: error => console.log(error)
    });
  }
}