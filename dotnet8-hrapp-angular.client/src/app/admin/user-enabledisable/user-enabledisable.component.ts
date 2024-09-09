import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-user-enabledisable',
  standalone: true,
  imports: [],
  templateUrl: './user-enabledisable.component.html',
  styleUrl: './user-enabledisable.component.scss'
})
export class UserEnableDisableComponent implements OnInit {
  modalRef = inject(BsModalRef);
  @Input() public userId!: number;
  @Input() public userName!: string;
  @Input() public isDisabled!: boolean;
  @Output() evtUserEnableDisable = new EventEmitter<number>();
  accountStatusTextOnConfirm = "Enable";
  OnInitFinished = false;

  ngOnInit(): void {
    this.accountStatusTextOnConfirm = this.isDisabled ? "Enable" : "Disable";
    this.OnInitFinished = true;
  }

  enableDisableUser() {
    this.evtUserEnableDisable.emit(this.userId);
  }
}
