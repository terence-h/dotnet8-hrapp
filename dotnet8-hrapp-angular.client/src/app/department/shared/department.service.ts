import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepartmentList } from './department-list.interface';
import { environment } from '../../../environments/environment.development';
import { DepartmentCreate } from './department-create.interface';
import { DepartmentEdit } from './department-edit.interface';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  http = inject(HttpClient);

  getDepartments(): Observable<DepartmentList[]> {
    return this.http.get<DepartmentList[]>(`${environment.apiUrl}/department`);
  }

  getDepartment(departmentId: any): Observable<DepartmentList> {
    return this.http.get<DepartmentList>(`${environment.apiUrl}/department/${departmentId}`);
  }

  createDepartment(departmentObj: any): Observable<DepartmentCreate> {
    const httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post<DepartmentCreate>(`${environment.apiUrl}/department`, departmentObj, { headers: httpHeaders });
  }

  updateDepartment(departmentObj: any): Observable<DepartmentEdit> {
    const httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    const jsonStr = JSON.stringify(departmentObj);

    return this.http.put<DepartmentEdit>(`${environment.apiUrl}/department/${departmentObj.departmentId}`, jsonStr, { headers: httpHeaders });
  }

  deleteDepartment(departmentId: any) {
    return this.http.delete(`${environment.apiUrl}/department/${departmentId}`);
  }
}