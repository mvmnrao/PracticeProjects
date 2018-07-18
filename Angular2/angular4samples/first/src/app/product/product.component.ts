import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  productsList = ["Laptop", "Desktop", "Mobile"];
  newItem = "";
  constructor() { }

  ngOnInit() {
  }

  pushItem = function(){
    if(this.newItem != "")
    {
      this.productsList.push(this.newItem);
      this.newItem = "";
    }
  }

  removeItem = function(index){
    this.productsList.splice(index, 1);
  }

}
