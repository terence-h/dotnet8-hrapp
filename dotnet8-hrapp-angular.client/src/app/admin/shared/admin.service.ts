import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Register, User } from './admin.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  http = inject(HttpClient);

  register(model: unknown): Observable<Register> {
    return this.http.post<Register>(`${environment.apiUrl}/admin/register`, model);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiUrl}/admin/userList`);
  }
}