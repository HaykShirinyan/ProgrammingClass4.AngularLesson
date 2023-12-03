import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { lastValueFrom } from "rxjs";
import { Manufactuer } from "../models/manufactuer";

@Injectable({
  providedIn: 'root'
})
export class ManufacturerService {
  constructor(private readonly _http: HttpClient) {

  }

  public getAll(): Promise<Manufactuer[]> {
    let observable = this._http.get<Manufactuer[]>('api/manufacturers');
    return lastValueFrom(observable);
  }
}
