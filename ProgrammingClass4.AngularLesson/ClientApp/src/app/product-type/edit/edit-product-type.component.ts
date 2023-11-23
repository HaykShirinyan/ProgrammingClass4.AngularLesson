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
  public isLoading: boolean = false;
  public spinnerMessage?: string;

  constructor(
    private readonly _productTypeService: ProductTypeService,
    private readonly _activeRoute: ActivatedRoute,
    private readonly _router: Router
  ) {

  }

  public ngOnInit(): void {
    this.isLoading = true;
    this._productTypeService.getProductType(+this._activeRoute.snapshot.paramMap.get('id')!)
      .subscribe(productType => {
        this.productType = productType;
        this.isLoading = false;
      });
  }

  public editProductType(form: NgForm): void {
    if (form.valid) {
      this.isLoading = true;
      this.spinnerMessage = 'Updating Product';

      this._productTypeService.updateProductType(this.productType)
        .subscribe(() => {
          this._router.navigate(['/productTypes']);
          this.isLoading = false;
        });
    }
  }
}

