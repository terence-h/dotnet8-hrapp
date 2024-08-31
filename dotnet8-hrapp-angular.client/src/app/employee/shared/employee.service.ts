import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { map, Observable } from 'rxjs';
import { EmployeeModel } from './employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  http = inject(HttpClient);

  getEmployees(): Observable<EmployeeModel[]> {
    return this.http.get<any[]>(`${environment.apiUrl}/employee`).pipe(
      map((response) => {
        return response.map(data => new EmployeeModel(data));
      })
    );
  }
}