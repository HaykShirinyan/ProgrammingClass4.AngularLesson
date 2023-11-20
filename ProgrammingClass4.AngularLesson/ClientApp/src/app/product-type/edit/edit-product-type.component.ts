import { Component, OnInit } from "@angular/core";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/services/product-type.service";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
  templateUrl: './edit-product-type.component.html'
})
export class EditProductTypeComponent implements OnInit {
  public productType: ProductType = {};

  constructor(
    private readonly _productTypeService: ProductTypeService,
    private readonly _activeRoute: ActivatedRoute,
    private readonly _router: Router
  ) {

  }

  public ngOnInit(): void {
    this._productTypeService.getProductType(+this._activeRoute.snapshot.paramMap.get('id')!)
      .subscribe(productType => {
        this.productType = productType;
      });
  }

  public editProductType(form: NgForm): void {
    if (form.valid) {
      this._productTypeService.updateProductType(this.productType)
        .subscribe(() => {
          this._router.navigate(['/productTypes']);
        });
    }
  }
}

