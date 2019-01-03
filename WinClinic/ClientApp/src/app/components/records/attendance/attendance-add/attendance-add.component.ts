import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AttendanceHttpService } from '../../../../http/attendance-http-service';
import { IPatients } from '../../../../model/IPatients';
import { bsHandler } from '../../../../providers/bsHandler';
import { HttpErrorResponse } from '@angular/common/http';
import { IAttendance } from '../../../../model/IAttendace';
import { VisitTypes, EVisitTypes } from '../../../../model/EVisitTypes';

@Component({
  selector: 'app-attendance-add',
  templateUrl: './attendance-add.component.html',
  styleUrls: ['./attendance-add.component.css']
})
export class AttendanceAddComponent implements OnInit {
  @Output() onAadded = new EventEmitter();
  hand: bsHandler;
  pat: IPatients | undefined
  form: FormGroup;
  visits: string[];
  att_form: FormGroup;
  constructor(fb: FormBuilder, private http: AttendanceHttpService) {
    this.hand = new bsHandler();
    this.visits = VisitTypes();
    this.form = fb.group({
      patientsID: ["", Validators.compose([Validators.required, Validators.minLength(15), Validators.maxLength(20)])],
    });

    this.att_form = fb.group({
      visitType: ["", Validators.compose([Validators.required])]
    })
  }

  find(id: string) {
    this.http.findPat(id).subscribe(res => this.pat = res, (err: HttpErrorResponse) => this.hand.onError(err));
  }

  add(typ: EVisitTypes) {
    let visit: IAttendance = { patientsID: this.pat.patientsID, visitType: typ, sessionName: 'next session', dateSeen: new Date(), userName: 'user name' } as IAttendance;
    this.http.add(visit).subscribe(() => {
      this.onAadded.emit();
      this.form.reset();
      this.att_form.reset();
    }, (err: HttpErrorResponse) => this.hand.onError(err));
  }
  ngOnInit() {
  }

}
