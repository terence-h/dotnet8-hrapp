import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { map } from 'rxjs';
import { User } from './account.interface';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  http = inject(HttpClient);
  currentUser = signal<User | null>(null);
  roles = computed(() => {
    const user = this.currentUser();
    if (user && user.token) {
      const role = JSON.parse(atob(user.token.split('.')[1])).role;
      return Array.isArray(role) ? role : [role];
    }
    return [];
  })

  login(model: unknown) {
    return this.http.post<User>(`${environment.apiUrl}/account/login`, model).pipe(
      map(user => {
        if (user)
          this.setCurrentUser(user);
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUser.set(user);
  }
}