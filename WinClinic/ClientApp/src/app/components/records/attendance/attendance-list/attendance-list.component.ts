import { Component, OnInit } from '@angular/core';
import { IAttendanceVm } from '../../../../model/IAttendace';
import { ActivatedRoute } from '@angular/router';
import { AttendanceHttpService } from '../../../../http/attendance-http-service';

@Component({
  selector: 'app-attendance-list',
  templateUrl: './attendance-list.component.html',
  styleUrls: ['./attendance-list.component.css']
})
export class AttendanceListComponent implements OnInit {

  list: IAttendanceVm[];
  constructor(route: ActivatedRoute,private http: AttendanceHttpService) {
    this.list = route.snapshot.data['list'];
  }

  ngOnInit() {
  }

  refresh() {
    this.http.list().subscribe(res => this.list = res);
  }
}
