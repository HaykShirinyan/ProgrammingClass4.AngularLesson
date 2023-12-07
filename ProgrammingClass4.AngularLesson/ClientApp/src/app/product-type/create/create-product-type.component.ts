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
  public isLoading: boolean = false;

  constructor(
    private readonly _productTypeService: ProductTypeService,
    private readonly _router: Router
  ) {
  }

  public async createProductType(form: NgForm): Promise<void> {
    if (form.valid) {
      this.isLoading = true;

      await this._productTypeService.addProductType(this.productType)
        
      this._router.navigate(['/productTypes']);
      this.isLoading = false;
    }
  }
}
