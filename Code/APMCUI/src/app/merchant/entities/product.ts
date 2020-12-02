export class Product {
    CategoryId: number;
    CategoryName: string;
    ProductId: number;
    ProductName: string;
    ProductQuantity: number;
    Unit: string;
    UnitId: number;
  static CategoryName: any;
  static CategoryId: number;
    
    constructor(){
       this.CategoryId=null,
       this.CategoryName=null,
       this.ProductId=null,
       this.ProductName=null,
       this.ProductQuantity=null,
       this.Unit=null,
       this.UnitId=null
       
    }
}