import { NgOptimizedImage } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../shared/account.service';
import { Router } from '@angular/router';
import { AlertModule } from 'ngx-bootstrap/alert';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [NgOptimizedImage, ReactiveFormsModule, AlertModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  accountService = inject(AccountService);
  router = inject(Router);
  loginForm: any;
  loginErrorMsg: string = '';

  ngOnInit(): void {
    if (this.accountService.currentUser()) {
      this.accountService.currentUser()!.roles = this.accountService.roles();
      this.router.navigate(['employee']);
    }

    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
  }

  login(): void {
    this.accountService.login(this.loginForm.value).subscribe({
      next: _ => { this.router.navigate(['employee']); },
      error: error => {
        // console.log(error?.error?.message);
        this.loginErrorMsg = error?.error?.message;
      }
    })
  }
}