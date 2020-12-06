export class Merchantindent {
  productcategory: number;
  productlist: number;
  productquantity: number;
  Unit: number;
  DriverId: string;
  DriverNo: number;
  ETADate: number;
  ETATime: string;
  VehicleNo: number;
  SupplierName: string;
  SupplierNo: number;

  constructor() {
    (this.productcategory = null),
      (this.productlist = null),
      (this.productquantity = null),
      (this.Unit = null),
      (this.DriverId = null),
      (this.DriverNo = null),
      (this.ETADate = null),
      (this.ETATime = null),
      (this.VehicleNo = null),
      (this.SupplierName = null),
      (this.SupplierNo = null);
  }
}
