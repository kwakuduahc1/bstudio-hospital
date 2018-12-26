import { Component, OnInit } from '@angular/core';
import { ConsultHttpService } from '../../../http/consulting/consult-http.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IConsultation } from '../../../model/consult/IConsult';
import { PatientService } from '../../../providers/patient-service';
import { bsHandler } from '../../../providers/bsHandler';

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
  selected: string[]=[];
  constructor(route: ActivatedRoute, http: ConsultHttpService, fb: FormBuilder, pat: PatientService) {
    this.hist = route.snapshot.data['history'];
    this.form = fb.group({
      complaints: ["", Validators.compose([Validators.required, Validators.maxLength(500), Validators.minLength(3)])],
  });
  }

  add_ss(ss: string) {
    let ix = this.s_s.findIndex(x => x === ss);
    this.selected.unshift(ss);
    this.s_s.splice(ix, 1);
  }

  rem_ss(ss: string) {
    let ix = this.selected.findIndex(x => x === ss);
    this.s_s.unshift(ss);
    this.selected.splice(ix, 1);
  }

  add(con: string) {
    if (!this.con.selected.some(x => x === con)) {
      this.con.selected.unshift(con);
      this.con.form.reset();
    }
    else alert('Complains already added');
  }

  consult() {
    if (this.selected.length < 1) {
      alert("Type or select some signs and symptoms");
      return;
    }
    else if (confirm('Have you reviewed the data?')) {
      var ss = this.selected.join();
      let hist: IConsultation = { complaints: ss, patientsID: this.con.patient.patientsID } as IConsultation;
      this.add(hist);
    }
  }

  ngOnInit() {
  }

}
