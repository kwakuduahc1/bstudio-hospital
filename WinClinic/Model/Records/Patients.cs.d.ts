declare module server {
	interface patients {
		patientsID: number;
		folderID: string;
		surname: string;
		otherNames: string;
		gender: string;
		dateOfBirth: Date;
		age: any;
		ageTyepe: string;
		mobileNumber: string;
		dateAdded: Date;
		userName: string;
		schemesID: number;
		concurrency: any[];
		fullName: string;
		patientDetails: {
			patientsID: number;
			address: string;
			kin: string;
			kinContact: string;
			isDependent: boolean;
			dependentID: string;
			status: boolean;
			isCapitated: boolean;
			schemesID: number;
			town: string;
			patients: server.patients;
		};
		patientAttendance: any[];
		schemes: {
			schemesID: number;
			scheme: string;
			description: string;
			status: boolean;
			concurrency: any[];
			patients: server.patients[];
			drugCodes: any[];
			serviceCodes: server.serviceCodes[];
			diagnosticCodes: server.diagnosticCodes[];
		};
	}
}
