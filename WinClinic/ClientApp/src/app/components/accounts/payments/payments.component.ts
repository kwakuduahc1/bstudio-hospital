import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { bsHandler } from '../../../providers/bsHandler';
import { AttendanceHttpService } from '../../../http/attendance-http-service';
import { IPatients } from '../../../model/IPatients';
import { HttpErrorResponse } from '@angular/common/http';
import { PaymnentsHttpService } from '../../../http/payments/payments-http-service';

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
  att_form: FormGroup;
  constructor(fb: FormBuilder, private http: PaymnentsHttpService) {
    this.hand = new bsHandler();
    this.form = fb.group({
      patientsID: ["", Validators.compose([Validators.required, Validators.minLength(15), Validators.maxLength(20)])],
    });
  }

  find(id: string) {
    this.http.findPat(id).subscribe(res => this.pat = res, (err: HttpErrorResponse) => this.hand.onError(err));
  }

  get(id: string) {
    console.log(id);
    this.http.list(id).subscribe();
  }
  ngOnInit(): void {

  }

}
