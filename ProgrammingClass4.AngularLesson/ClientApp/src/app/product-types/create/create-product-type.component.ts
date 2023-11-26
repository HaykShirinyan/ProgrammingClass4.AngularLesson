import { Component } from "@angular/core";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/Service/product-type.service";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Location } from '@angular/common';

@Component({
  templateUrl: './create-product-type.component.html'
})
export class CreateProductTypeComponent {
  public productType: ProductType = {}
  public isLoading: boolean = false;
 
  constructor(
    private readonly _productTypeService: ProductTypeService,
    private readonly _router: Router,
    private readonly _location:Location
  ) {

  }

  public createProductType(form:NgForm): void {
    if (form.valid) {
      this.isLoading = true;

      this._productTypeService.AddProductType(this.productType)
        .subscribe(() => {
          this._router.navigate(['/product-types'])
          this.isLoading = false;
        })
    }
  }

  public cancelCreating(): void {
    this._location.back();
  }
}
