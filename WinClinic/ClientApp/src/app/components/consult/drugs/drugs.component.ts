import { Component, OnInit } from '@angular/core';
import { IPatients } from '../../../model/IPatients';
import { IPatientDrugs } from '../../../model/consult/IPatientDrugs';
import { IDrugs } from '../../../model/consult/IDrugs';
import { ActivatedRoute } from '@angular/router';
import { DrugsHttpService } from '../../../http/consulting/drugs-http.service';
import { bsHandler } from '../../../providers/bsHandler';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'bs-drugs',
  templateUrl: './drugs.component.html',
  styleUrls: ['./drugs.component.css']
})
export class DrugsComponent implements OnInit {
  pat: IPatients;
  hist: IPatientDrugs[];
  drugs: IDrugs[];
  pt_drugs: IDrugs[] = [];
  drugForms: FormGroup[] = [];
  hand: bsHandler = new bsHandler();
  constructor(route: ActivatedRoute, private http: DrugsHttpService, private fb: FormBuilder, title: Title) {
    title.setTitle("Prescribe Drugs")
    this.drugs = route.snapshot.data['drugs'];
    this.hist = route.snapshot.data['history'];
    this.pat = route.snapshot.data['patient'];
  }

  select(dg: IDrugs) {
    if (this.pt_drugs.some(x => x.drugsID === dg.drugsID)) {
      alert(`${dg.drugName} has already been requested for`);
    }
    else {
      this.pt_drugs.unshift(dg);
      this.drugForms.unshift(this.fb.group({
        quantityRequested: [1, Validators.compose([Validators.required, Validators.min(1), Validators.max(50)])],
        drugCodesID: [dg.drugCodesID, Validators.compose([Validators.required, Validators.min(dg.drugsID), Validators.max(dg.drugsID)])],
        frequency: [2, Validators.compose([Validators.required, Validators.min(0), Validators.max(6)])],
        numberOfDays: [5, Validators.compose([Validators.required, Validators.max(90), Validators.min(1)])],
        drugName: [dg.drugName, Validators.compose([Validators.required, Validators.minLength(dg.drugName.length), Validators.maxLength(dg.drugName.length)])]
      }));
    }
  }

  remove(ix: number) {
    this.pt_drugs.splice(ix, 1);
  }

  request(drugs: FormGroup[]) {
    let ptdgs: IPatientDrugs[] = [];
    drugs.map(x => ptdgs.unshift({
      amountPaid: 0, cost: 0, numberOfDays: x.controls['numberOfDays'].value,
      drugCodesID: x.controls['drugCodesID'].value,
      quantityRequested: x.controls['quantityRequested'].value,
      drugsID: x.controls['drugCodesID'].value,
      frequency: x.controls['frequency'].value,
      quantity: x.controls['quantityRequested'].value,
      patientAttendanceID: this.pat.patientAttendanceID
    } as IPatientDrugs));
    if (confirm(`Continuing will request ${this.pt_drugs.length} lab for this patient`)) {
      this.http.add(ptdgs).subscribe(() => {
        this.pt_drugs.splice(0, this.pt_drugs.length);
        alert("Request was successful");
        this.drugForms.splice(0, this.drugForms.length);
        this.pt_drugs.splice(0, this.pt_drugs.length);
        this.reload();
      }, err => this.hand.onError(err));
    }
  }

  reload() {
    this.http.current(this.pat.patientAttendanceID).subscribe(res => this.hist = res);
  }

  formsValid(): boolean {
    return !this.drugForms.every(x => x.valid);
  }

  ngOnInit() {
  }

}
