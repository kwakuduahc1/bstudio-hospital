import { Component, OnInit } from '@angular/core';
import { IOpd } from '../../../model/IOpd';
import { ActivatedRoute } from '@angular/router';
import { OpdHttpService } from '../../../http/opd-http.service';

@Component({
  selector: 'bs-list-opd',
  templateUrl: './list-opd.component.html',
  styleUrls: ['./list-opd.component.css']
})
export class ListOpdComponent implements OnInit {

  list: IOpd[];
  constructor(route: ActivatedRoute, private http:OpdHttpService) {
    this.list = route.snapshot.data['list'];
  }

  refresh() {
    this.http.list().subscribe(res => this.list = res);
  }

  ngOnInit() {
  }

}
