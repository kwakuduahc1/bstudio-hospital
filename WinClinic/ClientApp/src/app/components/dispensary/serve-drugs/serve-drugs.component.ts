import { Component, OnInit } from '@angular/core';
import { IPatients } from '../../../model/IPatients';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { bsHandler } from '../../../providers/bsHandler';
import { HttpErrorResponse } from '@angular/common/http';
import { IPatientDrugs } from '../../../model/consult/IPatientDrugs';
import { DrugQuantitiesHttpService } from '../../../http/dispensary/drug-quantities-http-service';
import { DrugsHttpService } from '../../../http/consulting/drugs-http.service';

@Component({
  selector: 'bs-serve-drugs',
  templateUrl: './serve-drugs.component.html',
  styleUrls: ['./serve-drugs.component.css']
})
export class ServeDrugsComponent implements OnInit {

  pat: IPatients | undefined;
  hand: bsHandler;
  opd: FormGroup;
  drugs: IPatientDrugs[] = [];
  constructor(private fb: FormBuilder, private http: DrugsHttpService) {
    this.opd = this.fb.group({
      patientsID: ["", Validators.compose([Validators.required, Validators.minLength(15), Validators.maxLength(20)])],
    });
    this.hand = new bsHandler();
  }

  find(id: string) {
    this.http.findPat(id).subscribe(res => this.pat = res, (err: HttpErrorResponse) => this.hand.onError(err));
  }

  request() {
    if (!this.ready()) {
      alert("You must serve a drug");
    }
    if (confirm(`Have you served this/these drugs for the patient ${this.pat!.fullName}`)) {
      this.hand.beginProc();
      var drugs = this.drugs.filter(x => x.isServed);
      this.http.add(drugs).subscribe(() => {
        this.opd.reset();
        this.drugs.splice(0, this.drugs.length);
        this.pat = null;
        alert("Payments were successful");
      }, err => this.hand.onError(err));
      this.hand.endProc();
    }
  }

  serve(drug: IPatientDrugs) {
    drug.isServed = !drug.isServed;
  }

  ready(): boolean {
    return this.drugs.some(x => x.isServed);
  }

  getDrugs() {
    this.http.list(this.pat.patientAttendanceID).subscribe(res => this.drugs = res, err => this.hand.onError(err));
  }

  ngOnInit() {

  }
}
