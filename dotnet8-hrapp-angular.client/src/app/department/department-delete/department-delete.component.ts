import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { IEmployeeDetail } from '../../employee/shared/employee.interface';

@Component({
  selector: 'app-department-delete',
  standalone: true,
  imports: [],
  templateUrl: './department-delete.component.html',
  styleUrl: './department-delete.component.scss'
})
export class DepartmentDeleteComponent {
  modalRef = inject(BsModalRef);
  @Input() public departmentId!: number;
  @Input() public departmentName!: string;
  @Input() public employees!: IEmployeeDetail[];
  @Output() evtDepartmentDelete = new EventEmitter<number>();

  deleteDepartment() {
    this.evtDepartmentDelete.emit(this.departmentId);
  }
}