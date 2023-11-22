import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ProductType } from "../models/product-type";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})

export class ProductTypeService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getAll(): Observable<ProductType[]> {
    return this._http.get<ProductType[]>("/api/productTypes");
  }
  public addProductType(productType: ProductType): Observable<ProductType> {
    return this._http.post<ProductType>('/api/productTypes', productType);
  }

  public getProductType(id: number): Observable<ProductType> {
    return this._http.get<ProductType>('/api/productTypes/' + id);
  }

  public updateProductType(productType: ProductType): Observable<ProductType> {
    return this._http.put<ProductType>('/api/productTypes/' + productType.id, productType);
  }
}
