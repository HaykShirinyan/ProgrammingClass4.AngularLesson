import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";



@Component({
  templateUrl: './unit-of-measure-list.component.html'
})
export class UnitOfMeasureListComponent {
  private readonly _http: HttpClient;

  public unitOfMeasures?: UnitOfMeasure[];

  constructor(http: HttpClient) {
    this._http = http;
  }

  public ngOnInit(): void {
    this._http.get<UnitOfMeasure[]>('/api/unitOfMeasures')
      .subscribe(apiUnitOfMeasures => {
        this.unitOfMeasures = apiUnitOfMeasures
      });
  }
}
