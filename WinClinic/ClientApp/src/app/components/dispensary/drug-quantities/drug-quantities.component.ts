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
  drugForms: FormGroup[] = [];
  hand: bsHandler;
  opd: FormGroup;
  constructor(private fb: FormBuilder, private http: DrugQuantitiesHttpService) {
    this.opd = this.fb.group({
      patientsID: ["", Validators.compose([Validators.required, Validators.minLength(15), Validators.maxLength(20)])],
    });
    this.hand = new bsHandler();
  }

  find(id: string) {
    this.http.findPat(id).subscribe(res => this.pat = res, (err: HttpErrorResponse) => this.hand.onError(err));
  }

  request(vs: FormGroup[]) {
    if (confirm(`Do you want to add vitals signs for this ${this.pat!.fullName}`)) {
      this.hand.beginProc();
      var drugs = this.extract(vs);
      this.http.set(drugs).subscribe(res => {
        this.drugForms.forEach(o => o.reset());
        this.drugForms.splice(0, this.drugForms.length);
        this.opd.reset();
      }, err => this.hand.onError(err));
      this.hand.endProc();
    }
  }

  getDrugs() {
    this.http.get(this.pat.patientAttendanceID).subscribe(res => this.setForms(res), err => this.hand.onError(err));
  }

  extract(fgs: FormGroup[]): IPatientDrugs[] {
    let drugs: IPatientDrugs[] = [];
    fgs.forEach(x => drugs.push(x.value));
    return drugs;
  }

  setForms(drug: IPatientDrugs[]) {
    this.drugForms.splice(0, this.drugForms.length);
    drug.map(x => {
      this.drugForms.push(this.fb.group({
        id: [x.id, Validators.compose([Validators.required])],
        drugName: [x.drugName, Validators.compose([Validators.required, Validators.minLength(x.drugName.length), Validators.maxLength(x.drugName.length)])],
        numberOfDays: [x.numberOfDays, Validators.compose([Validators.required, Validators.min(x.numberOfDays), Validators.max(x.numberOfDays)])],
        frequency: [x.frequency, Validators.compose([Validators.required, Validators.min(x.frequency), Validators.max(x.frequency)])],
        quantityRequested: [1, Validators.compose([Validators.min(1), Validators.required, Validators.max(100)])]
      }))
    })
  }

  ngOnInit() {

  }

  formsValid() {
    return !this.drugForms.every(x => x.valid);
  }
}
