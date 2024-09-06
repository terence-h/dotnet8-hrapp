import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AlertModule } from 'ngx-bootstrap/alert';
import { AdminService } from '../shared/admin.service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule, AlertModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit {
  adminService = inject(AdminService);
  router = inject(Router);
  registerForm: any;
  registerErrorMsg: string = '';

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      username: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(24)]),
      password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(24)]),
    });
  }

  register(): void {
    this.adminService.register(this.registerForm.value).subscribe({
      next: resp => { this.router.navigate(['../admin/userlist'])},
      error: error => { this.registerErrorMsg = error?.error?.message }
    })
  }
}