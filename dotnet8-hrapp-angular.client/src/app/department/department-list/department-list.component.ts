import { Component, inject, Input, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { RouterLink } from '@angular/router';
import { DepartmentService } from '../shared/department.service';
import { DepartmentList } from '../shared/department-list.interface';
import { DepartmentDeleteComponent } from '../department-delete/department-delete.component';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { IEmployeeDetail } from '../../employee/shared/employee-detail.interface';
import { AlertModule } from 'ngx-bootstrap/alert';
import { HasRoleDirective } from '../../_directives/has-role.directive';
import { PageChangedEvent, PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule } from '@angular/forms';
import { environment } from '../../../environments/environment.development';

@Component({
  selector: 'app-department-list',
  standalone: true,
  imports: [RouterLink, FormsModule, AlertModule, PaginationModule,HasRoleDirective],
  providers: [BsModalService],
  templateUrl: './department-list.component.html',
  styleUrl: './department-list.component.scss'
})
export class DepartmentListComponent implements OnInit {
  departmentService = inject(DepartmentService);
  departments!: DepartmentList[];
  displayedDepartments!: DepartmentList[];
  modalService = inject(BsModalService);
  onInitFinished = false;
  onDeleted = false;
  page?: number;
  pageSize: number = environment.paginationSize;

  @Input() modalRef?: BsModalRef;

  ngOnInit(): void {
    this.getDepartments();
  }

  pageChanged(event: PageChangedEvent): void {
    this.page = event.page;

    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.displayedDepartments = this.departments.slice(startItem, endItem);
  }

  openModal(departmentId: number, departmentName: string, employees: IEmployeeDetail[]) {
    if (departmentId > 0) {
      const config: ModalOptions = {
        class: 'modal-dialog-centered',
        initialState: {
          departmentId: departmentId,
          departmentName: departmentName,
          employees: employees
        }
      };

      this.modalRef = this.modalService.show(DepartmentDeleteComponent, config);

      this.modalRef.content.evtDepartmentDelete.subscribe((data: number) => {
        this.deleteDepartment(data);
      });
    } else {
      console.log(`Invalid department ID ${departmentId}`);
    }
  }

  getDepartments() {
    this.departmentService.getDepartments().subscribe({
      next: response => {
        this.departments = response;
        this.displayedDepartments = response.slice(0, this.pageSize);
        this.onInitFinished = true;
      },
      error: error => console.log(error)
    });
  }

  deleteDepartment(departmentId: number) {
    this.departmentService.deleteDepartment(departmentId).subscribe({
      next: response => {
        this.onDeleted = true;
        this.modalRef?.hide();
        this.getDepartments();
      },
      error: error => { console.log(error); }
    });
  }
}