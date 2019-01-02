export interface IServiceCodes {
  serviceCodesID: string;
  serviceCode: string;
  schemesID: string;
  servicesID: string;
  cost: number;
  status: boolean;
  description: string;
  concurrency: number[];
  service: string;
  serviceTypesID: string;
  serviceGroup: string;
  serviceType: string;
  isSelected: boolean;
}

export interface IPatientServices {
  amount: number;
  patientServicesID: string;
  patientAttendanceID: string;
  serviceCodesID: string;
  numberOfDays: number;
  frequency: number;
  requestingOficcer: string;
  serviceCost: number;
  datePaid: Date;
  isPaid: boolean;
  receivingOficcer: string;
  receipt: string;
  isServed: boolean;
  dateServed: Date;
  servingOficcer: string;
  dateRequested: Date;
  concurrency: number[];
  patientsID: string;
  sessionName: string;
  gender: string;
  fullName: string;
  serviceCode: string;
  servicesID: string;
  cost: number;
  schemesID: string;
  scheme: string;
  service: string;
  serviceTypesID: string;
  serviceGroup: string;
  status: boolean;
  serviceType: string;
}
