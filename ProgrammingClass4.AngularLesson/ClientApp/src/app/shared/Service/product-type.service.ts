import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { ProductType } from "../models/product-type";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn:'root'
})
export class ProductTypeService{
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public GetAllProductTypes(): Observable<ProductType[]> {
    return this._http.get<ProductType[]>('/api/product-types');
  }

  public AddProductType(productType: ProductType): Observable<ProductType> {
    return this._http.post<ProductType>('/api/product-types', productType);
  }

  public GetProductType(id: number): Observable<ProductType> {
    return this._http.get<ProductType>('/api/product-types/' + id);
  }

  public UpdateProductType(productType: ProductType): Observable<ProductType> {
    return this._http.put<ProductType>('/api/product-types/' + productType.id, productType);
  }
}

