import { Component, OnInit } from '@angular/core';
import { Announcement } from '../models/Announcement';
import { DataService } from '../_services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [DataService]
})
export class HomeComponent implements OnInit {
  /** Based on the screen size, switch from standard to one column per row */
  cards: Announcement[] = [];

  constructor(public dataService: DataService) { }

  ngOnInit() {
    this.dataService.getAnnouncements().subscribe(
      (data: any[]) => this.cards = data);
    console.log('loaded successfuly');
  }
}
