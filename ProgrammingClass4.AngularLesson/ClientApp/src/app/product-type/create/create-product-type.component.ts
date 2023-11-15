import { Component } from "@angular/core";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/services/product-type.service";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
  templateUrl: './create-product-type.component.html'
})
export class CreateProductTypeComponent {
  public productType: ProductType = {};

  constructor(
    private readonly _productTypeService: ProductTypeService,
    private readonly _router: Router
  ) {
  }

  public createProductType(form: NgForm): void {
    if (form.valid) {
      this._productTypeService.addProductType(this.productType)
        .subscribe(() => {
          this._router.navigate(['/productTypes']);
        });
    }
  }
}
