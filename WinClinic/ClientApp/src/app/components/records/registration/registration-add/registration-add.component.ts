import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { IPatients } from '../../../../model/IPatients';
import { HttpErrorResponse } from '@angular/common/http';
import { RegisterHttpService } from '../../../../http/register-http.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration-add',
  templateUrl: './registration-add.component.html',
  styleUrls: ['./registration-add.component.css']
})
export class RegistrationAddComponent implements OnInit {
  ngOnInit(): void {

  }

  message: string = "";
  isProcessing: boolean = false;
  isError: boolean = false;
  isDismissed: boolean = false;
  form: FormGroup;
  constructor(private http: RegisterHttpService, fb: FormBuilder) {
    this.http = http;
    this.form = fb.group({
      surname: ["Kwaku", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
      otherNames: ["Ibrahim", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
      gender: ["Male", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
      town: ["Feyiase", Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(200)])],
      dateOfBirth: ["12/November/2016", Validators.compose([Validators.required, /*CustomValidators.date, CustomValidators.maxDate(new Date().toDateString())*/])],
      mobileNumber: ["0245266188", Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(10)])],
      patientsID: ["1111111111111111", Validators.compose([Validators.required, Validators.minLength(15), Validators.maxLength(20)])],
    });

  }


  beginProc(): void {
    this.isProcessing = true;
    this.isDismissed = true;
    this.isError = false;
  }

  endProc(): void {
    this.isProcessing = false;
    this.isDismissed = this.isError ? true : false;
  }

  add(item: IPatients) {
    this.beginProc();
    this.http.add(item).subscribe(res => this.onAdded(res), (err: HttpErrorResponse) => this.onError(err));
    this.endProc();
  }

  onError(err: HttpErrorResponse) {
    if (err.error!.message) {
      this.message = err.error.message;
    }
    else {
      switch (err.status) {
        case 500:
          this.message = "A server error occurred. Contact support";
          break;
        case 400:
          this.message = err.error!.message;
          break;
        default:
          this.message = "An unexpected error occurred. Contact support";
          break;
      }
    }
    this.isError = true;
    alert(this.message);
  }

  onAdded(item: IPatients) {
    this.form.reset();
    alert("New patient was added");
  }

}
