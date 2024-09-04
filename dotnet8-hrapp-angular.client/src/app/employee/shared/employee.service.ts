import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Observable } from 'rxjs';
import { EmployeeList } from './employee-list.interface';
import { EmployeeDetail } from './employee-detail.model';
import { IEmployeeDetail } from './employee-detail.interface';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  http = inject(HttpClient);

  getEmployees(): Observable<EmployeeList[]> {
    return this.http.get<EmployeeList[]>(`${environment.apiUrl}/employee`);
  }

  getEmployee(employeeId: any): Observable<EmployeeDetail> {
    return this.http.get<EmployeeDetail>(`${environment.apiUrl}/employee/${employeeId}`);
  }

  createEmployee(employeeObj: any): Observable<IEmployeeDetail> {
    const httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post<IEmployeeDetail>(`${environment.apiUrl}/employee`, employeeObj, { headers: httpHeaders });
  }
}