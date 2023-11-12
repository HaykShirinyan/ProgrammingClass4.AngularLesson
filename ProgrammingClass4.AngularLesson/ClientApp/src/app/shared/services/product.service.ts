import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../models/product";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getAllProducts(): Observable<Product[]> {
    return this._http.get<Product[]>('/api/products');
  }

  public addProduct(product: Product): Observable<Product> {
    return this._http.post<Product>('/api/products', product);
  }

  public getProduct(id: number): Observable<Product> {
    return this._http.get<Product>('/api/products/' + id);
  }

  public updateProduct(product: Product): Observable<Product> {
    return this._http.put<Product>('/api/products/' + product.id, product);
  }
}
