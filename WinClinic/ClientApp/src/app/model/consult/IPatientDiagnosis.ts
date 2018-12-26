export interface IPatientDiagnosis {
		patientDiagnosisID: string;
		patientsID: string;
		diagnosis: string;
		description: string;
		concurrency: number[];
		dateAdded: Date;
		userName: string;
	}
