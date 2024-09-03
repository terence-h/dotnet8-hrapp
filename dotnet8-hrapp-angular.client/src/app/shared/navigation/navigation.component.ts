import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent implements OnInit {
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
}