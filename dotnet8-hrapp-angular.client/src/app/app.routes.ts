import { Routes } from '@angular/router';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { DepartmentListComponent } from './department/department-list/department-list.component';
import { EmployeeDetailComponent } from './employee/employee-detail/employee-detail.component';
import { DepartmentDetailComponent } from './department/department-detail/department-detail.component';
import { DepartmentCreateComponent } from './department/department-create/department-create.component';
import { DepartmentEditComponent } from './department/department-edit/department-edit.component';
// import { EmployeeCreateComponent } from './employee/employee-create/employee-create.component';
import { EmployeeEditComponent } from './employee/employee-edit/employee-edit.component';
import { LoginComponent } from './account/login/login.component';
import { authGuard } from './_guards/auth.guard';
import { adminGuard } from './_guards/admin.guard';
import { UserListComponent } from './admin/user-list/user-list.component';
import { RegisterComponent } from './admin/register/register.component';

export const routes: Routes = [
    {
        path: '',
        title: "Homepage",
        component: LoginComponent
    },
    {
        runGuardsAndResolvers: 'always',
        path: 'employee',
        children: [
            {
                path: '',
                title: 'Employees',
                component: EmployeeListComponent,
                canActivate: [authGuard]
            },
            // {
            //     path: 'create',
            //     title: 'Add Employee',
            //     component: EmployeeCreateComponent,
            //     canActivate: [adminGuard]
            // },
            {
                path: 'edit/:employeeId',
                title: 'Edit Employee',
                component: EmployeeEditComponent,
                canActivate: [adminGuard]
            },
            {
                path: 'detail/:employeeId',
                title: 'View Employee Detail',
                component: EmployeeDetailComponent,
                canActivate: [authGuard]
            },]
    },
    {
        runGuardsAndResolvers: 'always',
        path: 'department',
        children: [
            {
                path: '',
                title: 'Departments',
                component: DepartmentListComponent,
                canActivate: [authGuard]
            },
            {
                path: 'create',
                title: 'Add Department',
                component: DepartmentCreateComponent,
                canActivate: [adminGuard]
            },
            {
                path: 'edit/:departmentId',
                title: 'Edit Department',
                component: DepartmentEditComponent,
                canActivate: [adminGuard]
            },
            {
                path: 'detail/:departmentId',
                title: 'View Department Detali',
                component: DepartmentDetailComponent,
                canActivate: [authGuard]
            }]
    },
    {
        runGuardsAndResolvers: 'always',
        path: 'admin',
        canActivate: [adminGuard],
        children: [
            {
                path: '',
                pathMatch: 'full',
                redirectTo: 'userlist',
            },
            {
                path: 'userlist',
                title: 'Users',
                component: UserListComponent
            },
            {
                path: 'createuser',
                title: 'Add User',
                component: RegisterComponent
            }
        ]
    }
];
