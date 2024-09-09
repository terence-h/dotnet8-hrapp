export interface Register {
    username: string;
    password: string;
}

export interface User {
    id: number;
    username: string;
    roles: string[];
    employeeId: number;
    isDisabled: boolean;
}

export interface EditUser {
    id: number;
    username: string;
    currentPassword: string;
    newPassword: string;
    roles: string[];
}

export interface Role {
    id: number;
    name: string;
}