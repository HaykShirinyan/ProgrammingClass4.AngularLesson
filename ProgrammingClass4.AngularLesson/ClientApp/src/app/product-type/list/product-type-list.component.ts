import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { ProductType } from "../../shared/models/product-type";


@Component({
  templateUrl: './product-type-list.component.html'
})
export class ProductTypeListComponent {
  private readonly _http: HttpClient;

  public productTypes?: ProductType[];
  constructor(http: HttpClient) {
    this._http = http;
  }

  public ngOnInit(): void {
    this._http.get<ProductType[]>('/api/productTypes')
      .subscribe(apiProductTypes => {
        this.productTypes = apiProductTypes
      });
  }
}
