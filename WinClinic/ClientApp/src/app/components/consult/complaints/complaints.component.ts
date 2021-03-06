import { Component, OnInit } from '@angular/core';
import { ConsultHttpService } from '../../../http/consulting/consult-http.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IConsultation } from '../../../model/consult/IConsult';
import { bsHandler } from '../../../providers/bsHandler';
import { IPatients } from '../../../model/IPatients';

@Component({
  selector: 'bs-complaints',
  templateUrl: './complaints.component.html',
  styleUrls: ['./complaints.component.css']
})
export class ComplaintsComponent implements OnInit {
  hist: IConsultation[];
  form: FormGroup;
  hand: bsHandler = new bsHandler();
  s_s: string[] = ['Fever', 'Nausea', 'Vomiting', 'Cough', 'Abdominal pains', 'Headache', 'Malaise', 'Palor', 'Conjunctivitis', 'Diarrhea', 'Sneezing', 'Inflammation', 'Palpitation', 'Dizziness', 'Hallucination', 'Illusions', 'Toothache', 'Frequent micturation', 'Blood in stool', 'Dyspnea'];
  selected: string[] = [];
  pat: IPatients;
  constructor(route: ActivatedRoute, private http: ConsultHttpService, fb: FormBuilder) {
    this.hist = route.snapshot.data['history'];
    this.pat = route.snapshot.data['patient']
    this.form = fb.group({
      complaints: ["", Validators.compose([Validators.required, Validators.maxLength(500), Validators.minLength(3)])],
    });
  }

  add_ss(ss: string) {
    let ix = this.s_s.findIndex(x => x === ss);
    this.selected.unshift(ss);
    this.s_s.splice(ix, 1);
    this.form.reset();
  }

  rem_ss(ss: string) {
    let ix = this.selected.findIndex(x => x === ss);
    this.s_s.unshift(ss);
    this.selected.splice(ix, 1);
  }

  add(con: IConsultation) {
    this.selected.map(x => this.s_s.unshift(x));
    this.selected.splice(0, this.selected.length);
    this.form.reset();
    this.hist.unshift(con);
  }

  consult() {
    if (this.selected.length < 1) {
      alert("Type or select some signs and symptoms");
      return;
    }
    else if (confirm('Have you reviewed the data?')) {
      var ss = this.selected.join();
      let hist: IConsultation = { patientAttendanceID: this.pat.patientAttendanceID, complaints: ss, patientsID: this.pat.patientsID, physicianNotes: '', userName: '', dateAdded: new Date() } as IConsultation;
      this.http.add(hist).subscribe(() => this.add(hist), err => this.hand.onError(err));
    }
  }

  ngOnInit() {
  }

}
