declare module server {
	interface serviceCodes {
		serviceCodesID: number;
		serviceCode: string;
		schemesID: number;
		servicesID: number;
		cost: number;
		status: boolean;
		description: string;
		concurrency: any[];
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
		services: {
			servicesID: number;
			service: string;
			serviceTypesID: number;
			serviceGroup: string;
			status: boolean;
			concurrency: any[];
			serviceCodes: server.serviceCodes[];
			serviceTypes: {
				serviceTypesID: number;
				serviceType: string;
				description: string;
				status: boolean;
				concurrency: any[];
				services: any[];
			};
		};
	}
}
