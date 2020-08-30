declare module server {
	interface diagnosticCodes {
		diagnosticCodesID: number;
		gDRG: string;
		iCDCode: string;
		description: string;
		schemesID: number;
		diagnosesID: number;
		tariff: number;
		patientDiagnoses: any[];
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
		diagnoses: {
			diagnosesID: any;
			diagnosis: string;
			description: string;
			concurrency: any[];
			dateAdded: Date;
			userName: string;
			diagnosticCodes: server.diagnosticCodes[];
		};
	}
}
