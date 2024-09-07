import { Component, inject, Input, OnInit } from '@angular/core';
import { EmployeeService } from '../shared/employee.service';
import { Router, RouterLink } from '@angular/router';
import { EmployeeList } from '../shared/employee.interface';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { EmployeeDeleteComponent } from '../employee-delete/employee-delete.component';
import { AlertModule } from 'ngx-bootstrap/alert';
import { AccountService } from '../../account/shared/account.service';
import { HasRoleDirective } from '../../_directives/has-role.directive';
import { PageChangedEvent, PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule } from '@angular/forms';
import { environment } from '../../../environments/environment.development';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [RouterLink, FormsModule, AlertModule, PaginationModule, HasRoleDirective],
  providers: [BsModalService],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})

export class EmployeeListComponent implements OnInit {
  employeeService = inject(EmployeeService);
  accountService = inject(AccountService);
  router = inject(Router);
  modalService = inject(BsModalService);
  employees!: EmployeeList[];
  displayedEmployees!: EmployeeList[];
  onInitFinished = false;
  onDeleted = false;
  page?: number;
  pageSize: number = environment.paginationSize;

  @Input() modalRef?: BsModalRef;

  ngOnInit(): void {
    if (!this.accountService.currentUser())
      this.router.navigate(['/']);

    this.getEmployees();
  }

  pageChanged(event: PageChangedEvent): void {
    this.page = event.page;

    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.displayedEmployees = this.employees.slice(startItem, endItem);
  }

  openModal(event:unknown, employeeId: number, employeeName: string) {
    const evt = (event as KeyboardEvent);

    if (evt.key && evt.key != "Enter")
        return;

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
      next: response => {
        this.page = 1;
        this.employees = response;
        this.displayedEmployees = response.slice(0, this.pageSize);
        this.onInitFinished = true;
      },
      error: error => console.log(error)
    });
  }

  deleteEmployee(employeeId: number) {
    this.employeeService.deleteEmployee(employeeId).subscribe({
      next: () => {
        this.onDeleted = true;
        this.modalRef?.hide();
        this.getEmployees();
      },
      error: error => { console.log(error); }
    });
  }
}