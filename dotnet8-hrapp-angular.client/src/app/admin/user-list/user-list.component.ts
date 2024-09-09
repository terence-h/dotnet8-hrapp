import { Component, inject, Input, OnInit } from '@angular/core';
import { User } from '../shared/admin.interface';
import { AdminService } from '../shared/admin.service';
import { RouterLink } from '@angular/router';
import { AlertModule } from 'ngx-bootstrap/alert';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { UserEnableDisableComponent } from '../user-enabledisable/user-enabledisable.component';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [RouterLink, AlertModule],
  providers: [BsModalService],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.scss'
})
export class UserListComponent implements OnInit {
  adminService = inject(AdminService);
  users!: User[];
  modalService = inject(BsModalService);
  onInitFinished = false;
  onEnableDisable = "";
  @Input() modalRef?: BsModalRef;

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    this.adminService.getUsers().subscribe({
      next: resp => { this.users = resp; this.onInitFinished = true; },
      error: error => { console.log(error); }
    });
  }

  openModal(event: unknown, userId: number, userName: string, isDisabled: boolean) {
    const evt = (event as KeyboardEvent);

    if (evt.key && evt.key != "Enter")
        return;

    if (userId > 0) {
      const config: ModalOptions = {
        class: 'modal-dialog-centered',
        initialState: {
          userId: userId,
          userName: userName,
          isDisabled: isDisabled
        }
      };

      this.modalRef = this.modalService.show(UserEnableDisableComponent, config);

      this.modalRef.content.evtUserEnableDisable.subscribe(() => {
        this.enableDisableAccount(userId, !isDisabled);
      });
    } else {
      console.log(`Invalid user ID ${userId}`);
    }
  }

  enableDisableAccount(userId: number, isDisable: boolean) {
    this.adminService.enableDisableAccount(userId, isDisable).subscribe({
      next: () => {
        this.onEnableDisable = isDisable ? "disabled" : "enabled";
        this.modalRef?.hide();
        this.getUsers();
      },
      error: error => { console.log(error); }
    });
  }
}
