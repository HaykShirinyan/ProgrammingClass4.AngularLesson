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
    private readonly _router: Router
  ) {
  }

  public createProduct(form: NgForm): void {
    if (form.valid) {
      this.isLoading = true;

      this._productService.addProduct(this.product)
        .subscribe(() => {
          this._router.navigate(['/products']);
          this.isLoading = false;
        });
    }
  }
}
