import { Component, OnInit } from '@angular/core';
import { CommonService } from 'src/app/common-feature/common.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  constructor(private commonService: CommonService) {}
  isCollapsed = true;
  ngOnInit(): void {}

  toggleSidebarPin(): void {
    this.commonService.toggleSidebarPin();
  }
  toggleSidebar(): void {
    this.commonService.toggleSidebar();
  }
}
