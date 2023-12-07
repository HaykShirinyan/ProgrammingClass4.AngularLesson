import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, lastValueFrom } from "rxjs";
import { UnitOfMeasure } from "../models/unit-of-measure";

@Injectable({
  providedIn: 'root'
})

export class UnitOfMeasureService {
  private readonly _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getAll(): Promise<UnitOfMeasure[]> {
    let observable = this._http.get<UnitOfMeasure[]>('./api/unitOfMeasures');
    return lastValueFrom(observable);
  }
  public addUnitOfMeasure(unitOfMeasure: UnitOfMeasure): Promise<UnitOfMeasure> {
    let observable = this._http.post<UnitOfMeasure>('/api/unitOfMeasures', unitOfMeasure);
    return lastValueFrom(observable);
  }

  public getUnitOfMeasure(id: number): Promise<UnitOfMeasure> {
    let observable = this._http.get<UnitOfMeasure>('/api/unitOfMeasures/' + id);
    return lastValueFrom(observable);
  }

  public updateUnitOfMeasure(unitOfMeasure: UnitOfMeasure): Promise<UnitOfMeasure> {
    let observable = this._http.put<UnitOfMeasure>('/api/unitOfMeasures/' + unitOfMeasure.id, unitOfMeasure);
    return lastValueFrom(observable);
  }
}
