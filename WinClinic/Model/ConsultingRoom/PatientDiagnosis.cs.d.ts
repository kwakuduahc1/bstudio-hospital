declare module server {
	interface patientDiagnosis {
		patientDiagnosisID: number;
		patientAttendanceID: number;
		diagnosticCodesID: number;
		description: string;
		concurrency: any[];
		dateAdded: Date;
		userName: string;
		diagnosticCodes: server.diagnosticCodes;
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
	}
}
