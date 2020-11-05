import { Component, OnInit } from '@angular/core';
import { CommonService } from 'src/app/common-feature/common.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss'],
})
export class MainLayoutComponent implements OnInit {
  constructor(private commonService: CommonService) {}

  ngOnInit(): void {}

  getClasses(): any {
    const classes = {
      'pinned-sidebar': this.commonService.getSidebarStat().isSidebarPinned,
      'toggeled-sidebar': this.commonService.getSidebarStat().isSidebarToggeled,
    };
    return classes;
  }
  toggleSidebar(): void {
    this.commonService.toggleSidebar();
  }
}
