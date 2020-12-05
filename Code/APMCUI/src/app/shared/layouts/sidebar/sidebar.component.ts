import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonService } from 'src/app/common-feature/common.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent implements OnInit {
  currentUser: any; // session Cureent User
  navLinks: NavLink[];
  adminNavLink: NavLink[];
  merchantNavLink: NavLink[];
  driverNavLink: NavLink[];
  entryGateOperatorNavLink: NavLink[];
  exitGateOperatorNavLink: NavLink[];
  constructor(private commonService: CommonService, private router: Router) {
    this.currentUser = JSON.parse(sessionStorage.getItem('CurrentUser'));
    this.assignNavLink();
  }

  ngOnInit(): void {}

  private assignNavLink(): void {
    this.merchantNavLink = [
      new NavLink(
        'Dashboard',
        ['/merchant/dashboard'],
        'fas fa-tachometer-alt'
      ),
      new NavLink(
        'Stall Registration',
        ['/merchant/stallregistration'],
        'fas fa-graduation-cap'
      ),
      new NavLink('Create Indent', ['/merchant/creatindent'], 'fa fa-inbox'),
    ];
    this.driverNavLink = [
      new NavLink('Dashboard', ['/driver/dashboard'], 'fas fa-tachometer-alt'),
      new NavLink('Indent List', ['/driver/qrList'], 'fas fa-graduation-cap'),
    ];

    this.adminNavLink = [
      new NavLink('Dashboard', ['/admin/dashboard'], 'fas fa-tachometer-alt'),
      new NavLink(
        'Stall Registration Requests',
        ['/admin/dashboard/stallRegistrationList'],
        'fas fa-user-plus'
      ),
    ];

    this.entryGateOperatorNavLink = [
      new NavLink(
        'Dashboard',
        ['/entryGateOperator/dashboard'],
        'fas fa-tachometer-alt'
      ),
      new NavLink(
        'Indent List',
        ['/entryGateOperator/indentListRecord'],
        'fas fa-graduation-cap'
      ),
    ];

    this.exitGateOperatorNavLink = [
      new NavLink(
        'Dashboard',
        ['/exitGateOperator/dashboard'],
        'fas fa-tachometer-alt'
      ),
      new NavLink(
        'Vehicle List',
        ['/exitGateOperator/VehicleList'],
        'fas fa-graduation-cap'
      ),
    ];

    this.navLinks = this.roleBasedNavLinks(); // .concat(this.commonNavLink);
  }
  private roleBasedNavLinks(): NavLink[] {
    switch (this.currentUser.role) {
      case 'Merchant':
        return this.merchantNavLink;
      case 'Driver':
        return this.driverNavLink;
      case 'Admin':
        return this.adminNavLink;
      case 'EntryGateOperator':
        return this.entryGateOperatorNavLink;
      case 'ExitGateOperator':
        return this.exitGateOperatorNavLink;
    }
  }

  toggleSidebar(): void {
    this.commonService.toggleSidebar();
  }

  logout(): void {
    sessionStorage.clear();
    this.router.navigate(['/login']);
  }
}
class NavLink {
  constructor(
    public title: string,
    public route: string[],
    public iconClass: string,
    public queryParams?: { [key: string]: string | number }
  ) {}
}
