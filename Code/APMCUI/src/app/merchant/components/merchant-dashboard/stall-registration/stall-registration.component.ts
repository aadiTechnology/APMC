import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-stall-registration',
  templateUrl: './stall-registration.component.html',
  styleUrls: ['./stall-registration.component.scss']
})
export class StallRegistrationComponent implements OnInit {
  selected: string;
  states = [
    'Fruits',
    'Vegetables',
    'Flowers',
    'Dry Fruits',
    'Spices',
    'Fertilizers & Manures',
    'Dairy',
    'Packaging Material',
    'Farm Equipments',
    'Grains',
    'Fishery',
    'Pulses',
    'Cereals',
    ];
  constructor() { }

  ngOnInit(): void {
  }

}
