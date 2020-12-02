export class UpdateParkingCharge {
  Id: number;
  IndentId: string;
  VehicleTypeId: string;
  VehicleNumber: string;
  EntryFee: string;
  InTime: string;
  OutTime: string;
  NoParkingFee: string;
  ExtraTimeFee: number;
  ExtraTime: number;
  FineCharges: string;
  UpdatedById: number;
  UpdatedDate: string;

  constructor() {
    this.Id = null;
    this.IndentId = null;
    this.VehicleTypeId = null;
    this.VehicleNumber = null;
    this.EntryFee = null;
    this.InTime = null;
    this.OutTime = null;
    this.NoParkingFee = null;
    this.ExtraTimeFee = null;
    this.ExtraTime = null;
    this.FineCharges = null;
    this.UpdatedById = null;
    this.UpdatedDate = null;
  }
}
