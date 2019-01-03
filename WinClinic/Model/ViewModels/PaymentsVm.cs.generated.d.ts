declare module Server.Dtos {
	interface PaymentsVm {
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
		};
		drugs: any[];
		services: any[];
		groups: Server.Dtos.Groups[];
		receipt: string;
		paymentMethod: any;
		amount: number;
		patientAttendanceID: any;
		userName: string;
	}
	interface LabsVm {
		labsID: any;
		lab: string;
		amount: number;
		labGroupsID: number;
		attendanceID: any;
		patLabID: number;
	}
	interface Groups {
		labGroupsID: number;
		groupName: string;
		cost: number;
		labs: Server.Dtos.LabsVm[];
		laboratoryServicesID: any;
	}
}
