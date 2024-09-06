import { Component, inject, OnInit } from '@angular/core';
import { User } from '../shared/admin.interface';
import { AdminService } from '../shared/admin.service';
import { RouterLink } from '@angular/router';
import { AlertModule } from 'ngx-bootstrap/alert';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [RouterLink, AlertModule],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.scss'
})
export class UserListComponent implements OnInit {
  adminService = inject(AdminService);
  users!: User[];
  onInitFinished = false;
  onDeleted = false;

  ngOnInit(): void {
    this.adminService.getUsers().subscribe({
      next: resp => { this.users = resp; this.onInitFinished = true; },
      error: error => { console.log(error); }
    });
  }
}
