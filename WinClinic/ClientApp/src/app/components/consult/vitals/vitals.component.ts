import { Component, OnInit } from '@angular/core';
import { IOpd } from '../../../model/IOpd';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'bs-vitals',
  templateUrl: './vitals.component.html',
  styleUrls: ['./vitals.component.css']
})
export class VitalsComponent implements OnInit {

  vitals: IOpd[];
  constructor(route: ActivatedRoute) {
    this.vitals = route.snapshot.data['vitals']
  }

  ngOnInit() {
  }

}
