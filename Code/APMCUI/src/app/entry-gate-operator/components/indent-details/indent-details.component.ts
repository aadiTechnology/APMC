import { Component, OnInit } from "@angular/core";
import { EntryGateOperatorService } from "../entry-gate-operator.service";
import { IndentList } from "../../entities/indentDetails";
import { Router, ActivatedRoute } from "@angular/router";
@Component({
  selector: "app-indent-details",
  templateUrl: "./indent-details.component.html",
  styleUrls: ["./indent-details.component.scss"],
})
export class IndentDetailsComponent implements OnInit {
  IndentList: IndentList[];
  IndentOrder: any;
  orderNo: any;
  constructor(
    private router: Router,
    private entryGateOperatorService: EntryGateOperatorService,
    private activeRoute: ActivatedRoute
  ) {
    this.IndentList = new Array<IndentList>();
  }

  ngOnInit(): void {
    this.orderNo = this.activeRoute.snapshot.queryParams.orderNo;
    this.getAllIndentDetails(this.orderNo);
  }
  getAllIndentDetails(Id) {
    this.entryGateOperatorService.getAllIndentDetails(Id).subscribe((arg) => {
      if (arg) {
        this.IndentOrder = arg.rows[0];
      }
    });
  }
}
