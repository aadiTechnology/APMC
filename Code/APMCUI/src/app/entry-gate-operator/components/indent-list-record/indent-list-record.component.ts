import { Component, OnInit } from "@angular/core";
import { from } from "rxjs";
import { EntryGateOperatorService } from "../entry-gate-operator.service";
import{IndentList} from "../../entities/indentDetails";

@Component({
  selector: "app-indent-list-record",
  templateUrl: "./indent-list-record.component.html",
  styleUrls: ["./indent-list-record.component.scss"],
})
export class IndentListRecordComponent implements OnInit {
  myDate = Date.now(); //date
  IndentList: IndentList[];

  constructor(private entryGateOperatorService: EntryGateOperatorService) {
    this.IndentList= new Array<IndentList>();
  }

  ngOnInit(): void {
    this.getAllNotScannedIndent();
    //this.getAllIndentDetails(Id);
  }
  getAllNotScannedIndent() {
    this.entryGateOperatorService.getAllNotScannedIndent().subscribe((arg) => {
      if (arg) {
      this.IndentList=arg.rows;
      alert(JSON.stringify(this.IndentList));
      }
    });
  }
  // getAllIndentDetails(Id){
  //   this.entryGateOperatorService.getAllIndentDetails(Id).subscribe((arg) => {
  //     if (arg) {
  //     }
  //   });
  // }
}
