import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AttendanceHttpService } from '../../../../http/attendance-http-service';

@Component({
  selector: 'app-attendance-add',
  templateUrl: './attendance-add.component.html',
  styleUrls: ['./attendance-add.component.css']
})
export class AttendanceAddComponent implements OnInit {

  form: FormGroup;
  constructor(fb: FormBuilder, private http: AttendanceHttpService) {
    this.form = fb.group({
      patientsID: ["", Validators.compose([Validators.required, Validators.minLength(6), Validators.maxLength(15)])],
      visitType: ["", Validators.compose([Validators.required])]
    })
  }

  ngOnInit() {
  }

}
