import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { bsHandler } from '../../../providers/bsHandler';
import { AttendanceHttpService } from '../../../http/attendance-http-service';
import { IPatients } from '../../../model/IPatients';
import { HttpErrorResponse } from '@angular/common/http';
import { PaymnentsHttpService } from '../../../http/payments/payments-http-service';
import { IPatientPayments } from '../../../model/payments/IPatientPayments';

@Component({
  selector: 'bs-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.css']
})
export class PaymentsComponent implements OnInit {

  hand: bsHandler;
  pat: IPatients | undefined
  form: FormGroup;
  visits: string[];
  pays: IPatientPayments | undefined;
  constructor(fb: FormBuilder, private http: PaymnentsHttpService) {
    this.hand = new bsHandler();
    this.form = fb.group({
      patientsID: ["", Validators.compose([Validators.required, Validators.minLength(15), Validators.maxLength(20)])],
    });
    this.pays = { amount: 0, drugs: [], fullName: '', groups: [], isActive: false, patientAttendanceID: '', patientsID: '', paymentMethod: '', receipt: '', services: [] };
  }

  find(id: string) {
    this.http.findPat(id).subscribe(res => this.pat = res, (err: HttpErrorResponse) => this.hand.onError(err));
  }

  get(id: string) {
    this.http.list(id).subscribe(res => this.pays = res, err => this.hand.onError(err));
  }

  ngOnInit(): void {

  }

  checkDrugs() {
    this.pays.drugs.map(x => x.hasPaid = !x.hasPaid);
  }

  checkLab() {
    this.pays.groups.map(x => x.hasPaid = !x.hasPaid);
  }

  dTot(): number {
    if (this.pays.drugs.length < 1) {
      return 0;
    }
    return this.pays.drugs.reduce((p, c) => p + c.unitCost, 0);
  }

  lTot(): number {
    if (this.pays.groups.length < 1) {
      return 0;
    }
    return this.pays.groups.reduce((p, c) => p + c.cost, 0);
  }

  sTot(): number {
    if (this.pays.services.length < 1) {
      return 0;
    }
    return this.pays.services.reduce((p, c) => p + c.serviceCost, 0);
  }
}
