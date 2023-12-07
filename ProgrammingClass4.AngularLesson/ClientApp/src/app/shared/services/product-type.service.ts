import { Injectable } from "@angular/core";
import { Observable, lastValueFrom } from "rxjs";
import { ProductType } from "../models/product-type";
import { HttpClient } from "@angular/common/http";
import { promises } from "dns";

@Injectable({
  providedIn: 'root'
})

export class ProductTypeService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getAll(): Promise<ProductType[]> {
    let observable = this._http.get<ProductType[]>("/api/productTypes");
    return lastValueFrom(observable);
  }
  public addProductType(productType: ProductType): Promise<ProductType> {
    let observable = this._http.post<ProductType>('/api/productTypes', productType);
    return lastValueFrom(observable);
  }

  public getProductType(id: number): Promise<ProductType> {
    let observable = this._http.get<ProductType>('/api/productTypes/' + id);
    return lastValueFrom(observable);
  }

  public updateProductType(productType: ProductType): Promise<ProductType> {
    let observable = this._http.put<ProductType>('/api/productTypes/' + productType.id, productType);
    return lastValueFrom(observable);
  }
}
