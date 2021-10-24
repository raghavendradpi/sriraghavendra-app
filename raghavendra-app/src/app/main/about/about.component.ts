import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss'],
})
export class AboutComponent implements OnInit {
  constructor() {}
  ids = [...Array(9).keys()].map((el) => 'link-' + el);
  info = [
    { id: 'link-1', title: 'Dharmapuri Temple', description: '' },
    { id: 'link-2', title: 'Daily Events', description: '' },
    { id: 'link-3', title: 'Early Life', description: '' },
    { id: 'link-4', title: 'Poorvashrama Miracles', description: '' },
    { id: 'link-5', title: 'Diwaan of Adoni', description: '' },
    { id: 'link-6', title: 'Panchamuki', description: '' },
    { id: 'link-7', title: 'Jeeva Samadhi', description: '' },
    { id: 'link-8', title: 'Sri Appanacharya and Sri Raghavendra Stotra', description: '' },
  ];

  ngOnInit(): void {}
}
