declare module Server.Dtos {
	interface Patientvm {
		patientsID: string;
		surname: string;
		otherNames: string;
		gender: string;
		dateOfBirth: Date;
		mobileNumber: string;
		dateAdded: Date;
		userName: string;
		schemesID: any;
		concurrency: any[];
		fullName: string;
		patientDetails: {
			patientsID: string;
			address: string;
			kin: string;
			kinContact: string;
			isDependent: boolean;
			dependentID: string;
			status: boolean;
			isCapitated: boolean;
			schemesID: any;
			schemeNumber: string;
			town: string;
			patients: Server.Dtos.Patientvm;
		};
		patientAttendance: any[];
		schemes: {
			schemesID: any;
			scheme: string;
			description: string;
			status: boolean;
			concurrency: any[];
			patients: Server.Dtos.Patientvm[];
			drugCodes: any[];
			serviceCodes: any[];
			diagnosticCodes: any[];
		};
	}
}
