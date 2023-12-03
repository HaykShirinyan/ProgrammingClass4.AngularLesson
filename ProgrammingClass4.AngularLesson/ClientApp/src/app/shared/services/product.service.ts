import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { lastValueFrom, Observable } from "rxjs";
import { Product } from "../models/product";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getAllProducts(): Promise<Product[]> {
    let observable = this._http.get<Product[]>('/api/products');
    return lastValueFrom(observable);
  }

  public addProduct(product: Product): Promise<Product> {
    let observable = this._http.post<Product>('/api/products', product);
    return lastValueFrom(observable);
  }

  public getProduct(id: number): Promise<Product> {
    let observable = this._http.get<Product>('/api/products/' + id);
    return lastValueFrom(observable);
  }

  public updateProduct(product: Product): Promise<Product> {
    let observable = this._http.put<Product>('/api/products/' + product.id, product);
    return lastValueFrom(observable);
  }
}
