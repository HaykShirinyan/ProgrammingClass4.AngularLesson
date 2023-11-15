import { Component, OnInit } from "@angular/core";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/Service/product-type.service";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
  templateUrl: './edit-product-type.component.html'
})
export class EditProductTypeComponent implements OnInit {
  public productType: ProductType = {};

  constructor(
    private readonly _productTypeService: ProductTypeService,
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router
  ) {

  }

  public ngOnInit(): void {
    this._productTypeService.GetProductType(+this._activatedRoute.snapshot.paramMap.get('id')!)
      .subscribe(productType => {
        this.productType = productType;
      });
  }

  public updateProductType(form: NgForm): void {
    if (form.valid) {
      this._productTypeService.UpdateProductType(this.productType)
        .subscribe(() => {
          this._router.navigate(['/product-types']);
        });
      
    }
  }
}
