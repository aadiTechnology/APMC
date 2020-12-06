export class IndentDetail {
  driverName: string;
  driverNo: string;
  etaDate: Date;
  etaTime: string;
  indentDetails: string;
  indentId: number;
  orderNo: string;
  parkingCharges: null;
  products: ProductDetail[];
  stallCreatedBy: string;
  stallName: string;
  stallNo: string;
  supplierName: string;
  supplierNo: string;
  vehicleNo: string;
  qrId: string;
  constructor() {
    this.driverName = null;
    this.driverNo = null;
    this.etaDate = null;
    this.etaTime = null;
    this.indentDetails = null;
    this.indentId = null;
    this.orderNo = null;
    this.parkingCharges = null;
    this.products = new Array<ProductDetail>();
    this.stallCreatedBy = null;
    this.stallName = null;
    this.stallNo = null;
    this.supplierName = null;
    this.supplierNo = null;
    this.vehicleNo = null;
    this.qrId = null;
  }
}

export class ProductDetail {
  productCategory: string;
  productName: string;
  productQuantity: string;
  unit: string;
  constructor() {
    this.productCategory = null;
    this.productName = null;
    this.productQuantity = null;
    this.unit = null;
  }
}
