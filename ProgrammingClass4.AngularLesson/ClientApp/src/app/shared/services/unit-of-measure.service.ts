import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UnitOfMeasure } from "../models/unit-of-measure";

@Injectable({
  providedIn: 'root'
})

export class UnitOfMeasureService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getAll(): Observable<UnitOfMeasure[]> {
    return this._http.get<UnitOfMeasure[]>('./api/unitOfMeasures');
  }
  public addUnitOfMeasure(unitOfMeasure: UnitOfMeasure): Observable<UnitOfMeasure> {
    return this._http.post<UnitOfMeasure>('/api/unitOfMeasures', unitOfMeasure);
  }

  public getUnitOfMeasure(id: number): Observable<UnitOfMeasure> {
    return this._http.get<UnitOfMeasure>('/api/unitOfMeasures/' + id);
  }

  public updateUnitOfMeasure(unitOfMeasure: UnitOfMeasure): Observable<UnitOfMeasure> {
    return this._http.put<UnitOfMeasure>('/api/products/' + unitOfMeasure.id, unitOfMeasure);
  }
}
