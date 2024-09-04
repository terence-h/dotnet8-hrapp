import { Routes } from '@angular/router';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { DepartmentListComponent } from './department/department-list/department-list.component';
import { EmployeeDetailComponent } from './employee/employee-detail/employee-detail.component';
import { DepartmentDetailComponent } from './department/department-detail/department-detail.component';
import { DepartmentCreateComponent } from './department/department-create/department-create.component';
import { DepartmentEditComponent } from './department/department-edit/department-edit.component';
import { EmployeeCreateComponent } from './employee/employee-create/employee-create.component';
import { EmployeeEditComponent } from './employee/employee-edit/employee-edit.component';

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
            path: 'create',
            title: 'Add Employee',
            component: EmployeeCreateComponent
        },
        {
            path: 'edit/:employeeId',
            title: 'Edit Employee',
            component: EmployeeEditComponent
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
            path: 'create',
            title: 'Add Department',
            component: DepartmentCreateComponent
        },
        {
            path: 'edit/:departmentId',
            title: 'Edit Department',
            component: DepartmentEditComponent
        },
        {
            path: 'detail/:departmentId',
            title: 'View Department Detali',
            component: DepartmentDetailComponent
        }]
    }
];
