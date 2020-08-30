declare module server {
	interface paymentsVm {
		patient: {
			patientAttendanceID: any;
			patientsID: string;
			fullName: string;
			dateOfBirth: Date;
			surname: string;
			otherNames: string;
			gender: string;
			mobileNumber: string;
			schemesID: any;
			scheme: string;
			sessionName: string;
			isActive: boolean;
			attendanceDate: Date;
		};
		drugs: any[];
		services: any[];
		groups: any[];
		receipt: string;
		paymentMethod: number;
		amount: number;
		patientAttendanceID: number;
		userName: string;
	}
	interface labsVm {
		labsID: number;
		lab: string;
		amount: number;
		labGroupsID: number;
		attendanceID: number;
		patLabID: number;
	}
	interface groups {
		labGroupsID: number;
		groupName: string;
		cost: number;
		labs: any[];
		laboratoryServicesID: number;
	}
}
