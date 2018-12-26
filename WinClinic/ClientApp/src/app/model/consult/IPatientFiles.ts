export interface IPatientFiles {
  filesID: number;
  fileUrl: string;
  opdNumber: string;
  dateAdded: Date;
  fileInfo: string;
  concurrency: number[];
}
