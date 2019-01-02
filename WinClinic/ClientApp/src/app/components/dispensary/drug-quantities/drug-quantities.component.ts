import { Component, OnInit } from '@angular/core';
import { IPatients } from '../../../model/IPatients';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { bsHandler } from '../../../providers/bsHandler';
import { HttpErrorResponse } from '@angular/common/http';
import { IPatientDrugs } from '../../../model/consult/IPatientDrugs';
import { DrugQuantitiesHttpService } from '../../../http/dispensary/drug-quantities-http-service';

@Component({
  selector: 'bs-drug-quantities',
  templateUrl: './drug-quantities.component.html',
  styleUrls: ['./drug-quantities.component.css']
})
export class DrugQuantitiesComponent implements OnInit {
  pat: IPatients | undefined;
  forms: FormGroup[] = [];
  hand: bsHandler;
  opd: FormGroup;
  constructor(fb: FormBuilder, private http: DrugQuantitiesHttpService) {
    this.opd = fb.group({
      patientsID: ["", Validators.compose([Validators.required, Validators.minLength(15), Validators.maxLength(20)])],
    });
    this.hand = new bsHandler();
  }

  find(id: string) {
    this.http.findPat(id).subscribe(res => this.pat = res, (err: HttpErrorResponse) => this.hand.onError(err));
  }

  add(vs: IPatientDrugs) {
    if (confirm(`Do you want to add vitals signs for this ${this.pat!.fullName}`)) {
      this.hand.beginProc();
      vs.patientsID = this.pat.patientsID;
      vs.patientAttendanceID = this.pat.patientAttendanceID;
      this.http.add(vs).subscribe(() => {
        this.forms.map(x => x.reset());
        this.opd.reset();
      }, err => this.hand.onError(err));
      this.hand.endProc();
    }
  }

  getDrugs() {

  }
  ngOnInit() {

  }
}
