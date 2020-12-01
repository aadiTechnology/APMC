export class Exitgate {
  id: number;
  indentId: number;
  vehicleTypeId: number;
  vehicleNumber: string;
  entryFee: number;
  inTime: number;
  outTime: number;
  noParkingFee: number;
  extraTimeFee: number;
  extraTime: number;
  fineCharges: number;
  updatedById: number;
  updatedDate: string;

  constructor() {
    this.id= null;
    this.indentId= null;
    this.vehicleTypeId= null;
    this.vehicleNumber = null;
    this.entryFee = null;
    this.inTime = null;
    this.outTime = null;
    this.noParkingFee = null;
    this.extraTimeFee = null;
    this.extraTime = null;
    this.fineCharges = null;
    this.updatedById = null;
    this.updatedDate = null;
  }
}
