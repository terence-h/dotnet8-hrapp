import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-employee-delete',
  standalone: true,
  imports: [],
  templateUrl: './employee-delete.component.html',
  styleUrl: './employee-delete.component.scss'
})
export class EmployeeDeleteComponent {
  modalRef = inject(BsModalRef);
  @Input() public employeeId!: number;
  @Input() public employeeName!: string;
  @Output() evtEmployeeDelete = new EventEmitter<number>();

  deleteEmployee() {
    this.evtEmployeeDelete.emit(this.employeeId);
  }
}
