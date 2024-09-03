import { Routes } from '@angular/router';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { DepartmentListComponent } from './department/department-list/department-list.component';
import { EmployeeDetailComponent } from './employee/employee-detail/employee-detail.component';
import { DepartmentDetailComponent } from './department/department-detail/department-detail.component';

export const routes: Routes = [
    {
        path: 'employee',
        children: [
        {
            path: '',
            title: 'Employees',
            component: EmployeeListComponent
        },
        {
            path: 'detail/:employeeId',
            title: 'View Employee Detail',
            component: EmployeeDetailComponent,
        },]
    },
    {
        path: 'department',
        children: [
        {
            path: '',
            title: 'Departments',
            component: DepartmentListComponent
        },
        {
            path: 'detail/:departmentId',
            title: 'View Department Detali',
            component: DepartmentDetailComponent
        }]
    }
];
