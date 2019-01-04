import { Component, OnInit } from '@angular/core';
import { IPatients } from '../../../model/IPatients';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { bsHandler } from '../../../providers/bsHandler';
import { HttpErrorResponse } from '@angular/common/http';
import { IPatientDrugs } from '../../../model/consult/IPatientDrugs';
import { IPatientServices } from '../../../model/consult/IServices';
import { ServeServicesHttpService } from '../../../http/services/serve-services-http.service';

@Component({
  selector: 'bs-serve-service',
  templateUrl: './serve-service.component.html',
  styleUrls: ['./serve-service.component.css']
})
export class ServeServiceComponent implements OnInit {

  pat: IPatients | undefined;
  hand: bsHandler;
  opd: FormGroup;
  services: IPatientServices[] = [];
  constructor(private fb: FormBuilder, private http: ServeServicesHttpService) {
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
      var servs = this.services.filter(x => x.isServed);
      this.http.add(servs).subscribe(() => {
        this.opd.reset();
        this.services.splice(0, this.services.length);
        this.pat = null;
        alert("Success");
      }, err => this.hand.onError(err));
      this.hand.endProc();
    }
  }

  serve(drug: IPatientDrugs) {
    drug.isServed = !drug.isServed;
  }

  ready(): boolean {
    return this.services.some(x => x.isServed);
  }

  get() {
    this.http.list(this.pat.patientAttendanceID).subscribe(res => this.services = res, err => this.hand.onError(err));
  }

  ngOnInit() {

  }
}
