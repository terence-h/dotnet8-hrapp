import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Observable } from 'rxjs';
import { EmployeeList } from './employee.interface';
import { IEmployeeDetail } from './employee.interface';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  http = inject(HttpClient);

  getEmployees(): Observable<EmployeeList[]> {
    return this.http.get<EmployeeList[]>(`${environment.apiUrl}/employee`);
  }

  getEmployee(employeeId: unknown): Observable<IEmployeeDetail> {
    return this.http.get<IEmployeeDetail>(`${environment.apiUrl}/employee/${employeeId}`);
  }

  createEmployee(employeeObj: unknown): Observable<IEmployeeDetail> {
    const httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post<IEmployeeDetail>(`${environment.apiUrl}/employee`, employeeObj, { headers: httpHeaders });
  }

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  updateEmployee(employeeObj: any): Observable<IEmployeeDetail> {
    const httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    const jsonStr = JSON.stringify(employeeObj);

    return this.http.put<IEmployeeDetail>(`${environment.apiUrl}/employee/${employeeObj.id}`, jsonStr, { headers: httpHeaders });
  }

  deleteEmployee(employeeId: unknown) {
    return this.http.delete(`${environment.apiUrl}/employee/${employeeId}`);
  }
}