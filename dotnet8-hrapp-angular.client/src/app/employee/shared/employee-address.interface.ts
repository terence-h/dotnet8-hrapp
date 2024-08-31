export interface Address {
    line1: string;
    line2?: string;
    unitNo?: string;
    postalCode: number;
    country: string;
    city?: string;
    state?: string;
}