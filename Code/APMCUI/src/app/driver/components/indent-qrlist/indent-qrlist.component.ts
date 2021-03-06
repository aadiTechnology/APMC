import { Component, OnInit } from "@angular/core";
import { DriverService } from "../../driver.service";
import { IndentDetails } from "../../entities/indentDetails";

@Component({
  selector: "app-indent-qrlist",
  templateUrl: "./indent-qrlist.component.html",
  styleUrls: ["./indent-qrlist.component.scss"],
})
export class IndentQRListComponent implements OnInit {
  myDate = Date.now();
  indentDetailList: any;
  indentDetails: any;
  constructor(private driverService: DriverService) {
    this.indentDetails = new Array<IndentDetails>();
  }

  ngOnInit(): void {
    this.getIndentWithMerchantName();
  }

  getIndentWithMerchantName() {
    this.driverService.getIndentWithMerchantName().subscribe((arg) => {
      if (arg) {
        this.indentDetailList = arg.rows;
        //alert(JSON.stringify(this.indentDetailList));
      }
    });
  }
}
