import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IOpd } from '../../../model/IOpd';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { bsHandler } from '../../../providers/bsHandler';
import { OpdHttpService } from '../../../http/opd-http.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IPatients } from '../../../model/IPatients';

@Component({
  selector: 'bs-add-opd',
  templateUrl: './add-opd.component.html',
  styleUrls: ['./add-opd.component.css']
})
export class AddOpdComponent implements OnInit {
  @Output() reload = new EventEmitter();
  pat: IPatients | undefined;
  form: FormGroup;
  hand: bsHandler;
  opd: FormGroup;
  constructor(fb: FormBuilder, private http: OpdHttpService) {
    this.opd = fb.group({
      patientsID: ["", Validators.compose([Validators.required, Validators.minLength(15), Validators.maxLength(20)])],
    });

    this.form = fb.group({
      systolic: ["", Validators.compose([Validators.min(60.0), Validators.max(250.0), Validators.required])],
      diastolic: ["", Validators.compose([Validators.min(40.0), Validators.max(160.0), Validators.required])],
      temperature: ["", Validators.compose([Validators.min(33.0), Validators.max(45.0), Validators.required])],
      weight: ["", Validators.compose([Validators.required, Validators.min(2.0), Validators.max(200.0)])],
      pulse: ["", Validators.compose([Validators.min(30.0), Validators.max(150.0), Validators.required])],
      respiration: ["", Validators.compose([Validators.min(16.0), Validators.max(26.0), Validators.required])]
    });
    this.hand = new bsHandler();
  }

  find(id: string) {
    this.http.findPat(id).subscribe(res => this.pat = res, (err: HttpErrorResponse) => this.hand.onError(err));
  }

  add(vs: IOpd) {
    if (confirm(`Do you want to add vitals signs for this ${this.pat!.fullName}`)) {
      this.hand.beginProc();
      vs.patientsID = this.pat.patientsID;
      this.http.add(vs).subscribe(() => {
        this.reload.emit();
        this.form.reset();
        this.opd.reset();
      }, err => this.hand.onError(err));
      this.hand.endProc();
    }
  }

  ngOnInit() {
  }

}
