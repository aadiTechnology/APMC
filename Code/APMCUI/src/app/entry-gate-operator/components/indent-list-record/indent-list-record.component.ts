import { Component, OnInit } from "@angular/core";
import { from } from "rxjs";
import { EntryGateOperatorService } from "../entry-gate-operator.service";
import { IndentList } from "../../entities/indentDetails";
import { Router } from "@angular/router";

@Component({
  selector: "app-indent-list-record",
  templateUrl: "./indent-list-record.component.html",
  styleUrls: ["./indent-list-record.component.scss"],
})
export class IndentListRecordComponent implements OnInit {
  myDate = Date.now();
  IndentList: IndentList[];
  term:string;
  constructor(
    private router: Router,
    private entryGateOperatorService: EntryGateOperatorService
  ) {
    this.IndentList = new Array<IndentList>();
  }

  ngOnInit(): void {
    this.getAllNotScannedIndent();
  }
  getAllNotScannedIndent() {
    this.entryGateOperatorService.getAllNotScannedIndent().subscribe((arg) => {
      if (arg) {
        this.IndentList = arg.rows;
        //  alert(JSON.stringify(this.IndentList));
      }
    });
  }
  selectedIndentRow(indentData) {
    this.router.navigate(["/entryGateOperator/indentDetail"], {
      queryParams: {
        orderNo: indentData,
      },
    });
  }
}
