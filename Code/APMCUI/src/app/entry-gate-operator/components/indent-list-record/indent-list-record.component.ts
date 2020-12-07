import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { EntryGateOperatorService } from '../entry-gate-operator.service';
import { Indent } from '../../entities/indent';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-indent-list-record',
  templateUrl: './indent-list-record.component.html',
  styleUrls: ['./indent-list-record.component.scss'],
})
export class IndentListRecordComponent implements OnInit {
  myDate = Date.now();
  IndentList: Indent[];
  term: string;
  constructor(
    private router: Router,
    private entryGateOperatorService: EntryGateOperatorService,
    private spinner: NgxSpinnerService
  ) {
    this.IndentList = new Array<Indent>();
  }

  ngOnInit(): void {
    this.getAllNotScannedIndent();
  }

  getAllNotScannedIndent(): void {
    this.spinner.show();
    this.entryGateOperatorService.getAllNotScannedIndent().subscribe(
      (arg) => {
        if (!arg.HasErrors) {
          this.IndentList = arg.rows;
          this.spinner.hide();
        } else {
          this.spinner.hide();
        }
      },
      (err) => {
        this.spinner.hide();
      }
    );
  }

  viewIndentRow(indentData): void {
    this.router.navigate(['/entryGateOperator/indentDetail'], {
      queryParams: {
        orderNo: indentData,
        type: 'VIEW',
      },
    });
  }

  scanIndentCode(indentData): void {
    this.router.navigate(['/entryGateOperator/indentDetail'], {
      queryParams: {
        orderNo: indentData,
        type: 'SCAN',
      },
    });
  }
}
