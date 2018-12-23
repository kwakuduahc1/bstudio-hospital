import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { IPatients } from '../../../../model/IPatients';
import { HttpErrorResponse } from '@angular/common/http';
import { RegisterHttpService } from '../../../../http/register-http.service';
import { Router } from '@angular/router';
import { CustomValidators } from 'ng2-validation'
import { bsHandler } from '../../../../providers/bsHandler';

@Component({
  selector: 'app-registration-add',
  templateUrl: './registration-add.component.html',
  styleUrls: ['./registration-add.component.css']
})
export class RegistrationAddComponent implements OnInit {

  hand: bsHandler;
  ngOnInit(): void {

  }

  form: FormGroup;
  constructor(private http: RegisterHttpService, fb: FormBuilder) {
    this.http = http;
    this.form = this.initForm(fb);
    this.hand = new bsHandler();
  }

  initForm(fb: FormBuilder) {
    return fb.group({
      surname: ["Kwaku", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
      otherNames: ["Ibrahim", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
      gender: ["Male", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
      town: ["Feyiase", Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(200)])],
      dateOfBirth: ["12/November/2016", Validators.compose([Validators.required, CustomValidators.date, CustomValidators.maxDate(new Date().toDateString())])],
      mobileNumber: ["0245266188", Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(10)])],
      patientsID: ["1111111111111111", Validators.compose([Validators.required, Validators.minLength(15), Validators.maxLength(20)])],
    });
  }

  add(pat: IPatients) {
    this.hand.beginProc();
    this.http.add(pat).subscribe(res => this.onAdded(res), (err: HttpErrorResponse) => this.hand.onError(err));
    this.hand.endProc();
  }


  onAdded(item: IPatients) {
    this.form.reset();
    alert("New patient was added");
  }
}
