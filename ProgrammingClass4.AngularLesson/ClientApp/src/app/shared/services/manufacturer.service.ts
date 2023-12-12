import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { lastValueFrom } from "rxjs";
import { Manufacturer } from "../models/manufacturer";

@Injectable({
  providedIn: 'root'
})
export class ManufacturerService {
  constructor(private readonly _http: HttpClient) {

  }

  public getAll(): Promise<Manufacturer[]> {
    let observable = this._http.get<Manufacturer[]>('api/manufacturers');
    return lastValueFrom(observable);
  }
}
