import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-theme-switcher',
  standalone: true,
  imports: [],
  templateUrl: './theme-switcher.component.html',
  styleUrl: './theme-switcher.component.scss'
})
export class ThemeSwitcherComponent implements OnInit {
  htmlElement = document.documentElement;

  ngOnInit(): void {
    this.setTheme(localStorage.getItem('theme') ?? 'light')
  }
  
  setTheme(theme: string) {
    const btnToActive = document.querySelector(`[data-bs-theme-value="${theme}"]`)
    localStorage.setItem('theme', theme);

    if (theme == "auto") {
      theme = window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    }

    this.htmlElement.setAttribute('data-bs-theme', theme);
    
    document.querySelectorAll('[data-bs-theme-value]').forEach(element => {
      element.classList.remove('active')
      element.setAttribute('aria-pressed', 'false')
    });

    btnToActive!.classList.add('active')
    btnToActive!.setAttribute('aria-pressed', 'true')
  }
}
