import { Component, inject, OnInit } from '@angular/core';
import { AdminService } from '../shared/admin.service';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { User } from '../shared/admin.interface';

@Component({
  selector: 'app-user-detail',
  standalone: true,
  imports: [RouterLink, CommonModule, AccordionModule],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.scss'
})
export class UserDetailComponent implements OnInit {
  adminService = inject(AdminService);
  route = inject(ActivatedRoute);
  user!: User;
  onInitFinished = false;

  ngOnInit(): void {
    const userId = this.route.snapshot.paramMap.get('userId');

    this.adminService.getUser(userId).subscribe({
      next: response => {
        this.user = response;
        this.onInitFinished = true;
      },
      error: error => console.log(error)
    });
  }
}
