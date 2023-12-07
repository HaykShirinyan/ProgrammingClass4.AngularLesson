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

  public async ngOnInit(): Promise<void> {
    this.isLoading = true;

    this.productType = await this._productTypeService.getProductType(+this._activeRoute.snapshot.paramMap.get('id')!)
      
    this.isLoading = false;
      
  }

  public async editProductType(form: NgForm): Promise<void> {
    if (form.valid) {
      this.isLoading = true;
      this.spinnerMessage = 'Updating Product';

      await this._productTypeService.updateProductType(this.productType)
     
      this._router.navigate(['/productTypes']);
      this.isLoading = false;
    }
  }
}

