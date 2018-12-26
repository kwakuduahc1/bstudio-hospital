import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'bs-consult-home',
  templateUrl: './consult-home.component.html',
  styleUrls: ['./consult-home.component.css']
})
export class ConsultHomeComponent implements OnInit {
  paths = [{ url: 'diagnose', path: 'Diagnoses', clicked: false }, { url: 'vitals', path: 'Vital Signs', clicked: false }, { url: 'labs', path: 'Labs', clicked: false }, { path: 'Lab History', url: 'labs', clicked: false }, { url: 'drug', path: 'Drugs', clicked: false }, { url: 'drugs-history', path: 'Drug History', clicked: false }, { url: 'services', path: 'Services', clicked: false }, { url: 'serve-history', path: 'Service History', clicked: false }, { url: 'summary', path: 'History', clicked: false }];
  constructor() { }

  clicked(ix: number) {
    this.paths.map(x => x.clicked = false);
    this.paths[ix].clicked = true;
  }
  ngOnInit() {
  }

}
