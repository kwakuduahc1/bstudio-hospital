declare module server {
	interface attendanceVm {
		fullName: string;
		dateSeen: Date;
		visitType: string;
		patientsID: number;
		folderID: string;
		sessionName: string;
		iD: number;
		patientAttendanceID: number;
	}
}
