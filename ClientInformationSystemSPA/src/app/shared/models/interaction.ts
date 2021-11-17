export interface Interaction {
    id: number;
    clientId?: number;
    empId?: number;
    clientName: string;
    employeeName: string;
    intType: string;
    intDate: Date;
    remarks: string;
}