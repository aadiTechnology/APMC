import { Component, OnInit } from '@angular/core';
import { EntryGateOperatorService } from '../entry-gate-operator.service';
import { IndentDetail } from '../../entities/indent-detail';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Indent } from 'src/app/merchant/entities/indent';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-indent-details',
  templateUrl: './indent-details.component.html',
  styleUrls: ['./indent-details.component.scss'],
})
export class IndentDetailsComponent implements OnInit {
  IndentList: Indent[];
  IndentOrder: IndentDetail;
  orderNo: any;
  actionType: string;
  entryDetails: { entryTime: string; weight: number; entryFee: number };
  qrCode: string;
  qrCodeVerified = false;

  constructor(
    private router: Router,
    private entryGateOperatorService: EntryGateOperatorService,
    private activeRoute: ActivatedRoute,
    private spinner: NgxSpinnerService
  ) {
    this.IndentList = new Array<Indent>();
    this.IndentOrder = new IndentDetail();
    this.entryDetails = { entryTime: null, weight: null, entryFee: null };
  }

  ngOnInit(): void {
    this.orderNo = this.activeRoute.snapshot.queryParams.orderNo;
    this.actionType = this.activeRoute.snapshot.queryParams.type;
    this.getAllIndentDetails(this.orderNo);
  }
  getAllIndentDetails(Id): void {
    this.spinner.show();
    this.entryGateOperatorService.getAllIndentDetails(Id).subscribe(
      (arg) => {
        if (!arg.HasErrors) {
          this.IndentOrder = arg;
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

  verifyIndent(VerifyIndentForm: NgForm): void {}

  GetIndentDetails(form: NgForm): void {
    if (form.valid && this.qrCode) {
      this.spinner.show();
      const qrData = this.qrCode.split('|');
      const qrCodeDetails = {
        indentId: +this.qrCode.slice(0, 5),
        merchantId: +this.qrCode.slice(5, 10),
        driverId: +this.qrCode.slice(10, 15),
      };
      this.entryGateOperatorService
        .GetDetailsByQRCode(
          qrCodeDetails.indentId,
          qrCodeDetails.merchantId,
          qrCodeDetails.driverId
        )
        .subscribe(
          (arg) => {
            if (!arg.HasErrors) {
              this.spinner.hide();
              this.qrCodeVerified = true;
            } else {
              this.spinner.hide();
              this.qrCodeVerified = false;
            }
          },
          (err) => {
            this.spinner.hide();
          }
        );
    }
  }
}
