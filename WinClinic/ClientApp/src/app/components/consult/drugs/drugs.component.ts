import { Component, OnInit } from '@angular/core';
import { IPatients } from '../../../model/IPatients';
import { IPatientDrugs } from '../../../model/consult/IPatientDrugs';
import { IDrugs } from '../../../model/consult/IDrugs';
import { ActivatedRoute } from '@angular/router';
import { DrugsHttpService } from '../../../http/consulting/drugs-http.service';
import { bsHandler } from '../../../providers/bsHandler';

@Component({
  selector: 'bs-drugs',
  templateUrl: './drugs.component.html',
  styleUrls: ['./drugs.component.css']
})
export class DrugsComponent implements OnInit {
  pat: IPatients;
  hist: IPatientDrugs[];
  drugs: IDrugs[];
  pt_drugs: IPatientDrugs[] = [];
  hand: bsHandler = new bsHandler();
  constructor(route: ActivatedRoute, private http: DrugsHttpService) {
    this.drugs = route.snapshot.data['drugs'];
    this.hist = route.snapshot.data['history'];
    this.pat = route.snapshot.data['patient'];
  }

  select(dg: IDrugs) {
    if (this.pt_drugs.some(x => x.drugsID === dg.drugsID)) {
      alert(`${dg.drugName} has already been requested for`);
    }
    else {
      let lb: IPatientDrugs = { amountPaid: 0, cost: 0, days: 0, drugsID: dg.drugsID, frequency: 0, patientsID: this.pat.patientsID, quantityRequested: 0, quantity: 0, patientAttendanceID:this.pat.patientAttendanceID } as IPatientDrugs;
      this.pt_drugs.unshift(lb);
    }
  }

  remove(ix: number) {
    this.pt_drugs.splice(ix, 1);
  }

  request() {
    if (confirm(`Continuing will request ${this.pt_drugs.length} lab for this patient at a cost of ${this.pt_drugs.reduce((p, c) => p + c.cost, 0)}`)) {
      this.http.add(this.pt_drugs).subscribe(() => {
        this.pt_drugs.splice(0, this.pt_drugs.length);
        alert("Request was successful");
        this.reload();
      }, err => this.hand.onError(err));
    }
  }

  reload() {
    this.http.list(this.pat.patientsID).subscribe(res => this.hist = res);
  }
  ngOnInit() {
  }

}
