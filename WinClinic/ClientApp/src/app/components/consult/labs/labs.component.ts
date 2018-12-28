import { Component, OnInit } from '@angular/core';
import { ILaboratoryServices } from '../../../model/consult/ILabServices';
import { ActivatedRoute } from '@angular/router';
import { IPatientLabs } from '../../../model/consult/IPatientLabs';
import { IPatients } from '../../../model/IPatients';
import { LabsHttpService } from '../../../http/consulting/labs-http.service';
import { bsHandler } from '../../../providers/bsHandler';

@Component({
  selector: 'bs-labs',
  templateUrl: './labs.component.html',
  styleUrls: ['./labs.component.css']
})
export class LabsComponent implements OnInit {

  labs: ILaboratoryServices;
  hist: IPatientLabs[];
  pt_labs: IPatientLabs[] = [];
  pat: IPatients;
  hand: bsHandler = new bsHandler();
  constructor(route: ActivatedRoute, private http: LabsHttpService) {
    this.labs = route.snapshot.data['labs'];
    this.hist = route.snapshot.data['history'];
    this.pat = route.snapshot.data['patient'];
  }

  select(lab: ILaboratoryServices) {
    if (this.pt_labs.some(x => x.labGroupsID === lab.labGroupsID)) {
      alert(`${lab.groupName} has already been requested for`);
    }
    else {
      let lb: IPatientLabs = { lab: lab.groupName, patientsID: this.pat.patientsID, labGroupsID: lab.labGroupsID, laboratoryServicesID: lab.laboratoryServicesID, patientAttendanceID: this.pat.patientAttendanceID, groupName: lab.groupName } as IPatientLabs;
      this.pt_labs.unshift(lb);
    }
  }

  remove(ix: number) {
    this.pt_labs.splice(ix, 1);
  }

  request() {
    if (confirm(`Continuing will request ${this.pt_labs.length} lab for this patient at a cost of ${this.pt_labs.reduce((p, c) => p + c.cost, 0)}`)) {
      this.http.add(this.pt_labs).subscribe(() => {
        this.pt_labs.splice(0, this.pt_labs.length);
        alert("Request was successful");
        this.reload();
      }, err => this.hand.onError(err));
    }
  }

  reload() {
    this.http.current(this.pat.patientsID).subscribe(res => this.hist = res);
  }
  ngOnInit() {
  }

}
