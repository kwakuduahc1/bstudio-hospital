import { Component, OnInit } from '@angular/core';
import { IDiagnosticCodes, IPatientDiagnosis } from '../../../model/consult/IDiagnosis';
import { ActivatedRoute } from '@angular/router';
import { DiagnosesHttpService } from '../../../http/consulting/diagnoses-http.service';
import { IPatients } from '../../../model/IPatients';
import { bsHandler } from '../../../providers/bsHandler';

@Component({
  selector: 'bs-diagnosis',
  templateUrl: './diagnosis.component.html',
  styleUrls: ['./diagnosis.component.css']
})
export class DiagnosisComponent implements OnInit {

  diags: IDiagnosticCodes[];
  pt_diags: IPatientDiagnosis[] = [];
  list: IPatientDiagnosis[] = [];
  pat: IPatients;
  hand: bsHandler = new bsHandler();
  constructor(route: ActivatedRoute, private http: DiagnosesHttpService) {
    this.diags = route.snapshot.data['diags'];
    this.list = route.snapshot.data['list'];
    this.pat = route.snapshot.data['patient'];
  }

  select(ix: IDiagnosticCodes) {
    if (this.pt_diags.some(x => x.diagnosticCodesID === ix.diagnosticCodesID)) {
      alert(`${ix.description} has already been added`);
    }
    else {
      let diag: IPatientDiagnosis = { dateAdded: new Date(), description: ix.description, diagnosis: ix.diagnosis, gDRG: ix.gDRG, diagnosticCodesID: ix.diagnosticCodesID, icdCode: ix.icdCode, patientAttendanceID: this.pat.patientAttendanceID, userName: '' } as IPatientDiagnosis;
      this.pt_diags.unshift(diag);
    }
  }

  refresh() {
    this.http.patientList(this.pat.patientAttendanceID).subscribe(res => this.list = res, err => this.hand.onError(err));
  }
  diagnose() {
    this.hand.beginProc();
    this.http.add(this.pt_diags).subscribe(res => {
      this.pt_diags.splice(0, this.pt_diags.length);
      alert('Diagnoses(is) were added');
      this.refresh();
    }, err => this.hand.onError(err));
    this.hand.endProc();
  }

  remove(ix: number) {
    this.pt_diags.splice(ix, 1);
  }

  ngOnInit() {
  }

}

