import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { EditUser, Register, Role, User } from './admin.interface';
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
    return this.http.get<User[]>(`${environment.apiUrl}/admin/user/users`);
  }

  getUser(userId: unknown): Observable<User> {
    return this.http.get<User>(`${environment.apiUrl}/admin/user/${userId}`);
  }

  getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(`${environment.apiUrl}/admin/user/roles`)
  }

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  updateUser(userObj: any) {
    const httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    
    userObj.roles = userObj.roles.split(',');
    const jsonStr = JSON.stringify(userObj);

    return this.http.put<EditUser>(`${environment.apiUrl}/admin/user/editUser/${userObj.id}`, jsonStr, { headers: httpHeaders })
  }

  enableDisableAccount(userId: number, disable: boolean) {
    const obj = {
      userId: userId,
      isDisable: disable
    };
    return this.http.post<boolean>(`${environment.apiUrl}/admin/user/enableDisableAccount`, obj)
  }

  checkUserExist(userName: unknown): Observable<boolean> {
    return this.http.get<boolean>(`${environment.apiUrl}/admin/user/checkUsername?userName=${userName}`);
  }
}