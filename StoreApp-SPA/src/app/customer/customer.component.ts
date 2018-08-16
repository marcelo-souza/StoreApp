import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customers: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get('http://localhost:5000/api/customers').subscribe(result => {
      this.customers = result;
    });
  }

}
