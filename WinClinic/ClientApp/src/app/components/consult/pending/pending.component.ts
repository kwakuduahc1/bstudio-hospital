import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { IPatients } from '../../../model/IPatients';
import { bsHandler } from '../../../providers/bsHandler';
import { AttendanceHttpService } from '../../../http/attendance-http-service';
import { HttpErrorResponse } from '@angular/common/http';
import { PatientService } from '../../../providers/patient-service';

@Component({
  selector: 'bs-pending',
  templateUrl: './pending.component.html',
  styleUrls: ['./pending.component.css']
})
export class PendingComponent implements OnInit {
  hand: bsHandler;
  opd: FormGroup;
  pat: IPatients | undefined;
  constructor(title: Title, fb: FormBuilder, private http: AttendanceHttpService, private patSer: PatientService) {
    title.setTitle("Begin Consulting");
    this.hand = new bsHandler();
    this.opd = fb.group({
      patientsID: ["", Validators.compose([Validators.required, Validators.minLength(15), Validators.maxLength(20)])],
    });
  }

  find(id: string) {
    this.http.findPat(id).subscribe(res => this.pat = this.patSer.patient = res, (err: HttpErrorResponse) => this.hand.onError(err));
  }

  ngOnInit() {
  }

}
