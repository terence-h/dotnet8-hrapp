import { Component, inject, Input, OnInit } from '@angular/core';
import { EmployeeService } from '../shared/employee.service';
import { RouterLink } from '@angular/router';
import { EmployeeList } from '../shared/employee-list.interface';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { EmployeeDeleteComponent } from '../employee-delete/employee-delete.component';
import { AlertModule } from 'ngx-bootstrap/alert';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [RouterLink, AlertModule],
  providers: [BsModalService],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})

export class EmployeeListComponent implements OnInit {
  employeeService = inject(EmployeeService);
  modalService = inject(BsModalService);
  employees!: EmployeeList[];
  onInitFinished = false;
  onDeleted = false;

  @Input() modalRef?: BsModalRef;

  ngOnInit(): void {
    this.getEmployees();
  }

  openModal(employeeId: number, employeeName: string) {
    if (employeeId > 0) {
      const config: ModalOptions = {
        class: 'modal-dialog-centered',
        initialState: {
          employeeId: employeeId,
          employeeName: employeeName,
        }
      };
      
      this.modalRef = this.modalService.show(EmployeeDeleteComponent, config);

      this.modalRef.content.evtEmployeeDelete.subscribe((data: number) => {
        this.deleteEmployee(data);
      });
    } else {
      console.log(`Invalid employee ID ${employeeId}`);
    }
  }

  getEmployees() {
    this.employeeService.getEmployees().subscribe({
      next: response => {this.employees = response; this.onInitFinished = true;},
      error: error => console.log(error)
    });
  }

  deleteEmployee(employeeId: number) {
    this.employeeService.deleteEmployee(employeeId).subscribe({
      next: response => {
        this.onDeleted = true;
        this.modalRef?.hide();
        this.getEmployees();
      },
      error: error => { console.log(error); }
    });
  }
}