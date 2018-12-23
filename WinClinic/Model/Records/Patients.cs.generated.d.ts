declare module Server.Dtos {
	interface Patients {
		patientsID: string;
		surname: string;
		otherNames: string;
		gender: string;
		dateOfBirth: Date;
		mobileNumber: string;
		dateAdded: Date;
		userName: string;
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
			patients: Server.Dtos.Patients;
		};
		patientAttendance: any[];
		opdHistory: any[];
		patientServices: any[];
		patientDrugs: any[];
		patientConsultation: any[];
		schemes: {
			schemesID: any;
			scheme: string;
			description: string;
			status: boolean;
			concurrency: any[];
			patients: Server.Dtos.Patients[];
			drugCodes: any[];
			serviceCodes: any[];
			diagnosticCodes: any[];
		};
		patientMedications: any[];
		patientAdmissions: any[];
		patientDiagnoses: any[];
		patientLaboratoryServices: any[];
	}
}
