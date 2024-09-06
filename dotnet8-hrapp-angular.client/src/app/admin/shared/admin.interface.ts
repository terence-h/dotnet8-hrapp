export interface Register {
    username: string;
    password: string;
}

export interface User {
    id: number;
    username: string;
    roles: string[];
}