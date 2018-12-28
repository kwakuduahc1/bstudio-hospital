import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'bs-consult-home',
  templateUrl: './consult-home.component.html',
  styleUrls: ['./consult-home.component.css']
})
export class ConsultHomeComponent implements OnInit {
  paths: Array<{ url: string, path: string, clicked: boolean }> = [{ url: 'complaints', path: 'Sign & symptoms', clicked: false }, { url: 'diagnose', path: 'Diagnoses', clicked: false }, { url: 'vitals', path: 'Vital Signs', clicked: false }, { url: 'labs', path: 'Labs', clicked: false }, { path: 'Lab History', url: 'labs', clicked: false }, { url: 'drugs', path: 'Drugs', clicked: false }, { url: 'drugs-history', path: 'Drug History', clicked: false }, { url: 'services', path: 'Services', clicked: false }, { url: 'serve-history', path: 'Service History', clicked: false }, { url: 'summary', path: 'History', clicked: false }];

  constructor() {
    this.paths[2].clicked = true;
  }

  clicked(ix: number) {
    this.paths.map(x => x.clicked = false);
    this.paths[ix].clicked = true;
  }
  ngOnInit() {
  }

}
