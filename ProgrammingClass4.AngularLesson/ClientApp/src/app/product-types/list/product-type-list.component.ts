import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { ProductType } from "../../shared/models/product-type";
import { ProductTypeService } from "../../shared/Service/product-type.service";

@Component({
  templateUrl:'./product-type-list.component.html'
})
export class ProductTypeListComponent {
  private readonly _productTypeService:ProductTypeService

  public productTypes?: ProductType[];
  public isLoading: boolean = false;

  constructor(productTypeService:ProductTypeService) {
    this._productTypeService = productTypeService;
  }

  public ngOnInit(): void {
    this.isLoading = true;

    this._productTypeService.GetAllProductTypes()
      .subscribe(apiProductTypes => {
        this.productTypes = apiProductTypes
        this.isLoading = false;
      });
  }
}
