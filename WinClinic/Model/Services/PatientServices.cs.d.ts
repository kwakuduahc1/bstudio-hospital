declare module server {
	interface patientServices {
		patientServicesID: number;
		patientAttendanceID: number;
		serviceCodesID: number;
		numberOfDays: any;
		frequency: any;
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
		concurrency: any[];
		patientAttendance: {
			patientAttendanceID: any;
			patientsID: string;
			visitType: string;
			dateSeen: Date;
			sessionName: string;
			isActive: boolean;
			dateClosed: Date;
			userName: string;
			concurrency: any[];
			patients: server.patients;
		};
		serviceCodes: server.serviceCodes;
	}
}
