import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Product } from "../../shared/models/product";
import { ProductService } from "../../shared/services/product.service";

@Component({
  templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit {
  private readonly _productService: ProductService

  public products?: Product[];
  public isLoading: boolean = false;

  constructor(productService: ProductService) {
    this._productService = productService;
  }

  public ngOnInit(): void {
    this.isLoading = true;

    this._productService.getAllProducts()
      .subscribe(apiProducts => {
        this.products = apiProducts;
        this.isLoading = false;
      });
  }

  public cancelLoadingProducts(): void {
    this.isLoading = false;
  }
}
