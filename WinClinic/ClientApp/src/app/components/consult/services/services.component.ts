import { Component, OnInit } from '@angular/core';
import { IPatients } from '../../../model/IPatients';
import { IServiceCodes, IPatientServices } from '../../../model/consult/IServices';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { bsHandler } from '../../../providers/bsHandler';
import { ActivatedRoute } from '@angular/router';
import { ServicesHttpService } from '../../../http/consulting/services-http.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'bs-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {
  pat: IPatients;
  hist: IPatientServices[];
  services: IServiceCodes[];
  //pt_srs: IServices[] = [];
  sForms: FormGroup[] = [];
  hand: bsHandler = new bsHandler();
  constructor(route: ActivatedRoute, private http: ServicesHttpService, private fb: FormBuilder, title: Title) {
    title.setTitle("Request Services")
    this.services = route.snapshot.data['services'];
    this.hist = route.snapshot.data['history'];
    this.pat = route.snapshot.data['patient'];
  }

  select(dg: IServiceCodes) {
    if (dg.isSelected) {
      alert(`${dg.service} has already been requested`);
    }
    else {
      this.sForms.unshift(this.fb.group({
        serviceCodesID: [dg.serviceCodesID, Validators.compose([Validators.required, Validators.minLength(dg.serviceCodesID.length), Validators.maxLength(dg.serviceCodesID.length)])],
        frequency: [1, Validators.compose([Validators.required, Validators.min(1), Validators.max(6)])],
        numberOfDays: [1, Validators.compose([Validators.required, Validators.max(7), Validators.min(1)])],
        service: [dg.service, Validators.compose([Validators.required, Validators.minLength(dg.service.length), Validators.maxLength(dg.service.length)])]
      }));
      dg.isSelected = true;
    }
  }

  remove(ix: number) {
    var id = this.sForms[ix].controls['serviceCodesID'].value;
    var num = this.services.findIndex(x => x.serviceCodesID === id);
    this.services[num].isSelected = false;
    this.sForms.splice(ix, 1);
  }

  request(services: FormGroup[]) {
    let _servs: IPatientServices[] = [];
    services.map(x => _servs.unshift({
      serviceCost: 0, numberOfDays: x.controls['numberOfDays'].value,
      serviceCodesID: x.controls['serviceCodesID'].value,
      frequency: x.controls['frequency'].value,
      patientAttendanceID: this.pat.patientAttendanceID
    } as IPatientServices));
    if (confirm(`Continuing will request ${this.sForms.length} services for this patient`)) {
      this.http.add(_servs).subscribe(() => {
        this.sForms.splice(0, this.sForms.length);
        alert("Request was successful");
        this.reload();
      }, err => this.hand.onError(err));
    }
  }

  reload() {
    this.services.map(x => x.isSelected = false);
    this.http.list(this.pat.patientsID).subscribe(res => this.hist = res);
  }

  formsValid(): boolean {
    return !this.sForms.every(x => x.valid);
  }

  ngOnInit() {
  }
}
