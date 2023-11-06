import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UnitOfMeasure } from "../models/unit-of-measure";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn:'root'
})
export class UnitOfMeasureService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getAllUnitOfMeasures(): Observable<UnitOfMeasure[]> {
    return this._http.get<UnitOfMeasure[]>('/api/unit-of-measures')
  }
}
