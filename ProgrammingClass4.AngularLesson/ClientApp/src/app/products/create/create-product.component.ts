import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Product } from "../../shared/models/product";
import { ProductService } from "../../shared/services/product.service";

@Component({
  templateUrl: './create-product.component.html'
})
export class CreateProductComponent {
  public product: Product = {};
  public isLoading: boolean = false;

  constructor(
    private readonly _productService: ProductService,
    private readonly _router: Router//
  ) {
  }
  //creatProduct function kanchvuma Html ejic,event knopkaya (ngsubmit),kanchvuma save anelu hamar 
  public async createProduct(form: NgForm): Promise<void> {
    if (form.valid) {
      this.isLoading = true;

      await this._productService.addProduct(this.product);

      this._router.navigate(['/products']);//nra hamara vor texapoxvenq products ej
      this.isLoading = false;
    }
  }
}
