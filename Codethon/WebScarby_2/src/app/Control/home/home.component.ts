import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { pharmacy } from 'src/app/Models/pharmacy';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  searchForm: FormGroup;
  pharmacys: pharmacy[] = [];
  isNoRecord: boolean = false;
  constructor(private router: Router, private httpClient: HttpClient, private fromBulider: FormBuilder) { }

  ngOnInit() {
    this.searchForm = this.fromBulider.group({
      txtSearch: [''],
      txtPincode: ['', [Validators.required, Validators.minLength(6)]],
      isOnlyInsuranceCovered: [false]
    });
  }
  searchDetail(ev) {
    ev.preventDefault();
    console.log(this.searchForm.value);
    var pincode = this.searchForm.value.txtPincode;
    let _params = {};

    if (!this.searchForm.valid) {
      alert("Please Enter Pincode");
      return false;
    }
    else if (pincode.length != 0 && pincode.length != 6) {
      alert("pincode must be in Six Degit!.");
      return false;
    }

    let url = "https://localhost:5001/api/pharmacy";
    url = url + "/" + pincode;

    if (this.searchForm.value.txtSearch.length != 0) { _params["keyName"] = this.searchForm.value.txtSearch; }

    this.httpClient.get(url, { params: _params })
      .subscribe((success: any[]) => {
        this.pharmacys = success;
        success.length == 0 ? this.isNoRecord = true : this.isNoRecord = false;
      }, error => {
        console.log(error);
      });
  }
}
