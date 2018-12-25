import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IPatients } from '../../../model/IPatients';
import { RegisterHttpService } from '../../../http/register-http.service';
import { bsHandler } from '../../../providers/bsHandler';

@Component({
  selector: 'bs-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  form: FormGroup;
  hand: bsHandler;
  list: IPatients[] = [];
  constructor(fb: FormBuilder, private http: RegisterHttpService) {
    this.hand = new bsHandler();
    this.form = fb.group({
      query: ["", Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(20)])],
    });
  }

  search(qry: string) {
    this.http.search(qry).subscribe(res => this.list = res);
  }

  ngOnInit() {
  }

}
