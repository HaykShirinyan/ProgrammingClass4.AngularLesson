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
    return this._http.get<ProductType[]>('/api/product-types')
  }
}

