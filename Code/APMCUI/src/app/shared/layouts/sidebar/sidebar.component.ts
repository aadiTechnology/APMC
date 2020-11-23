import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  currentUser: any; // session Cureent User
  constructor() {
    this.currentUser = JSON.parse(sessionStorage.getItem("CurrentUser"));
   }

  ngOnInit(): void {
  }


}
