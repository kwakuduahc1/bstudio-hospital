declare module server {
	interface diagnoses {
		diagnosesID: number;
		diagnosis: string;
		description: string;
		concurrency: any[];
		dateAdded: Date;
		userName: string;
		diagnosticCodes: server.diagnosticCodes[];
	}
}
