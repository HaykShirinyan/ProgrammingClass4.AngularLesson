import { Component, OnInit } from "@angular/core";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/Service/product-type.service";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Location } from '@angular/common';

@Component({
  templateUrl: './edit-product-type.component.html'
})
export class EditProductTypeComponent implements OnInit {
  public productType: ProductType = {};
  public isLoading: boolean = false;
  public spinnerMessage?: string;

  constructor(
    private readonly _productTypeService: ProductTypeService,
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _location: Location
  ) {

  }

  public ngOnInit(): void {
    this.isLoading = true;
    this.spinnerMessage = 'Loading Product Type'

    this._productTypeService.GetProductType(+this._activatedRoute.snapshot.paramMap.get('id')!)
      .subscribe(productType => {
        this.productType = productType;
        this.isLoading = false;
      });
  }

  public updateProductType(form: NgForm): void {
    if (form.valid) {
      this.isLoading = true;
      this.spinnerMessage ='Updating Product Type'

      this._productTypeService.UpdateProductType(this.productType)
        .subscribe(() => {
          this._router.navigate(['/product-types']);
          this.isLoading = false;
        });
    }
  }

  public cancelEditing(): void {
    this._location.back();
  }
}
