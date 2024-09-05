import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AccountService } from '../../account/shared/account.service';
import { HasRoleDirective } from '../../_directives/has-role.directive';
import { IsLoggedInDirective } from '../../_directives/is-logged-in.directive';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [RouterLink, HasRoleDirective, IsLoggedInDirective],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss',
})
export class NavigationComponent implements OnInit {
  router = inject(Router);
  accountService = inject(AccountService);
  htmlElement = document.documentElement;
  isDarkMode = false;

  ngOnInit(): void {
    this.setTheme(localStorage.getItem('theme') ?? 'light')
  }

  onToggleLightDarkmode() {
    const theme = localStorage.getItem('theme') == 'dark' ? 'light' : 'dark';
    this.setTheme(theme);
  }

  setTheme(theme: string) {
    this.htmlElement.setAttribute('data-bs-theme', theme);
    localStorage.setItem('theme', theme);
    this.isDarkMode = theme == 'dark';
  }

  logout() {
    this.accountService.logout();
    this.router.navigate(['/']);
  }
}