export class StallRequestList {

    public id: number;
    public userId: number;
    public stallId: number;
    public isApproved: boolean;
    public isRejected: boolean;
    public approveBy: number;
    public createdDate: Date;
    public approvedDate: Date;
    public rejectReason: string;

    constructor(){
        this.id = null;
        this.userId = null;
        this.stallId = null;
        this.isApproved = false;
        this.isRejected = false;
        this.approveBy = null;
        this.createdDate = null;
        this.approvedDate = null;
        this.rejectReason = null;
    }
}