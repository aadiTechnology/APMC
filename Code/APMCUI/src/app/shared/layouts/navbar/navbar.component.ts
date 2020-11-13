import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonService } from 'src/app/common-feature/common.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  constructor(private commonService: CommonService, private router: Router) {}
  isCollapsed = true;
  ngOnInit(): void {}

  toggleSidebarPin(): void {
    this.commonService.toggleSidebarPin();
  }
  toggleSidebar(): void {
    this.commonService.toggleSidebar();
  }
  logout(): void {
    sessionStorage.clear();
    this.router.navigate(['/login']);
  }
}
