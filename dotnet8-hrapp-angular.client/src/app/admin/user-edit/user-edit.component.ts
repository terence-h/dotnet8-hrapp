import { Component, inject, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { RouterLink, Router, ActivatedRoute } from '@angular/router';
import { AdminService } from '../shared/admin.service';
import { Role, User } from '../shared/admin.interface';

@Component({
  selector: 'app-user-edit',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './user-edit.component.html',
  styleUrl: './user-edit.component.scss'
})
export class UserEditComponent implements OnInit {
  router = inject(Router);
  route = inject(ActivatedRoute);
  currentValues!: User;
  roles!: Role[];
  adminService = inject(AdminService);
  userForm!: FormGroup<{ id: FormControl<number | null>; username: FormControl<string | null>; currentPassword: FormControl<string | null>; newPassword: FormControl<string | null>; roles: FormControl<string | null>; }>
  onInitFinished = [false, false];
  rolesInput: string[] = [];

  ngOnInit(): void {
    const userId = this.route.snapshot.paramMap.get('userId');

    this.adminService.getUser(userId).subscribe({
      next: response => {
        this.currentValues = response;

        let roleStr = "";

        response.roles.forEach(role => {
          if (roleStr.length > 0)
            roleStr += ",";
          roleStr += role;
          this.rolesInput.push(role);
        });

        this.userForm = new FormGroup({
          id: new FormControl(response.id),
          username: new FormControl(response.username, [Validators.required, Validators.minLength(4), Validators.maxLength(24)]),
          currentPassword: new FormControl('', [Validators.minLength(4), Validators.maxLength(24)]),
          newPassword: new FormControl('', [Validators.minLength(4), Validators.maxLength(24)]),
          roles: new FormControl(roleStr, [Validators.required])
        });

        this.onInitFinished[0] = true;
      },
      error: error => console.log(error)
    });

    this.adminService.getRoles().subscribe({
      next: response => {
        this.roles = response;
        this.onInitFinished[1] = true;
      },
      error: error => console.log(error)
    })
  }

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  onCheckboxChange(event: any) {
    if (event.currentTarget.checked) {
      this.rolesInput.push(event.currentTarget.name);
    } else {
      this.rolesInput = this.rolesInput.filter(role => role !== event.currentTarget.name);
    }

    let roleStr = '';

    this.rolesInput.forEach(role => {
      if (roleStr.length > 0)
        roleStr += ",";
      roleStr += role;
    });

    this.userForm.controls['roles'].setValue(roleStr);
  }

  updateUser() {
    this.adminService.updateUser(this.userForm.value).subscribe({
      next: resp => { this.router.navigate([`../../../admin/user/detail/${resp}`]); },
      error: error => { console.log(error); }
    });
  }
}
