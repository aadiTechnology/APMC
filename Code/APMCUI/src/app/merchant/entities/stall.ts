export class Stall {
  public Id: number;
  public UserId: number;
  public StallId: number;
  public IsApproved: boolean;
  public IsRejected: boolean;
  public ApproveBy: number;
  public CreatedDate: Date;
  public ApprovedDate: Date;
  public RejectReason: string;
  constructor() {
    this.Id = null;
    this.UserId = null;
    this.StallId = null;
    this.IsApproved = false;
    this.IsRejected = false;
    this.ApproveBy = null;
    this.CreatedDate = null;
    this.ApprovedDate = null;
    this.RejectReason = null;
  }
}
