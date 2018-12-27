import { Component, OnInit } from '@angular/core';
import { IOpd } from '../../../model/IOpd';
import { ActivatedRoute } from '@angular/router';
import { OpdHttpService } from '../../../http/opd-http.service';
import { bsHandler } from '../../../providers/bsHandler';

@Component({
  selector: 'bs-list-opd',
  templateUrl: './list-opd.component.html',
  styleUrls: ['./list-opd.component.css']
})
export class ListOpdComponent implements OnInit {

  list: IOpd[];
  hand = new bsHandler();
  constructor(route: ActivatedRoute, private http:OpdHttpService) {
    this.list = route.snapshot.data['list'];
  }

  refresh() {
    this.http.list().subscribe(res => this.list = res,err=>this.hand.onError(err));
  }

  ngOnInit() {
  }

}
