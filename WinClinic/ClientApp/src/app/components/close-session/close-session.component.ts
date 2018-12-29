import { Component, OnInit } from '@angular/core';
import { IAttendanceVm } from '../../model/IAttendace';
import { ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { AttendanceHttpService } from '../../http/attendance-http-service';
import { bsHandler } from '../../providers/bsHandler';

@Component({
  selector: 'bs-close-session',
  templateUrl: './close-session.component.html',
  styleUrls: ['./close-session.component.css']
})
export class CloseSessionComponent implements OnInit {
  sessions: IAttendanceVm[];
  hand = new bsHandler();
  constructor(route: ActivatedRoute, title:Title, private http:AttendanceHttpService) {
    this.sessions = route.snapshot.data['sessions'];
    title.setTitle("Active Sessions");
  }

  ngOnInit() {
  }

  close(att: IAttendanceVm) {
    if (confirm("If you close this session for this patient, you would have to create a new session before the patient can be consulted. Press OK to continue")) {
      this.http.close(att).subscribe(() => {
        let ix = this.sessions.findIndex(x => x.patientAttendanceID == att.patientAttendanceID);
        this.sessions[ix].isActive = false;
      },err=>this.hand.onError(err))
    }
  }
}
