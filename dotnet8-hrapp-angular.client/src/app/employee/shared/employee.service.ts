import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Observable } from 'rxjs';
import { EmployeeList } from './employee-list.interface';
import { EmployeeDetail } from './employee-detail.model';

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
}