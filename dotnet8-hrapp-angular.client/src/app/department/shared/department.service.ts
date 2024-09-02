import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepartmentList } from './department-list';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  http = inject(HttpClient);

  getDepartments(): Observable<DepartmentList[]> {
    return this.http.get<DepartmentList[]>(`${environment.apiUrl}/department`);
  }
}
