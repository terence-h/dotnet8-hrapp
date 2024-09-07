import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepartmentList } from './department.interface';
import { environment } from '../../../environments/environment.development';
import { DepartmentCreateEdit } from './department.interface';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  http = inject(HttpClient);

  getDepartments(): Observable<DepartmentList[]> {
    return this.http.get<DepartmentList[]>(`${environment.apiUrl}/department`);
  }

  getDepartment(departmentId: unknown): Observable<DepartmentList> {
    return this.http.get<DepartmentList>(`${environment.apiUrl}/department/${departmentId}`);
  }

  createDepartment(departmentObj: unknown): Observable<DepartmentCreateEdit> {
    const httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post<DepartmentCreateEdit>(`${environment.apiUrl}/department`, departmentObj, { headers: httpHeaders });
  }

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  updateDepartment(departmentObj: any): Observable<DepartmentCreateEdit> {
    const httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    const jsonStr = JSON.stringify(departmentObj);

    return this.http.put<DepartmentCreateEdit>(`${environment.apiUrl}/department/${departmentObj.departmentId}`, jsonStr, { headers: httpHeaders });
  }

  deleteDepartment(departmentId: unknown) {
    return this.http.delete(`${environment.apiUrl}/department/${departmentId}`);
  }
}