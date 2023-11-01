import { HttpClient } from "@angular/common/http";
import { UnitOfMeasure } from "../shared/models/unit-of-measure";
import { Component } from "@angular/core";


@Component({
  templateUrl:'unit-of-measure-list.component.html'
})
export class UnitOfMeasureListComponent {
  private readonly _http: HttpClient;

  public measures?: UnitOfMeasure[];
  constructor(http: HttpClient) {
    this._http = http
  }

  public ngOnInit(): void {
    this._http.get<UnitOfMeasure[]>('/api/unit-of-measures')
      .subscribe(apiMeasures => {
        this.measures = apiMeasures
      });
  }
}
