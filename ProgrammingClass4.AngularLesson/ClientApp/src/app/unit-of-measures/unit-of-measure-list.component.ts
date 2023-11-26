import { HttpClient } from "@angular/common/http";
import { UnitOfMeasure } from "../shared/models/unit-of-measure";
import { Component } from "@angular/core";
import { UnitOfMeasureService } from "../shared/Service/unit-of-measure.service";

@Component({
  templateUrl:'unit-of-measure-list.component.html'
})
export class UnitOfMeasureListComponent {
  private readonly _unitOfMeasureService:UnitOfMeasureService

  public measures?: UnitOfMeasure[];
  public isLoading: boolean = false;

  constructor(unitOfMeasureService:UnitOfMeasureService) {
    this._unitOfMeasureService = unitOfMeasureService
  }

  public ngOnInit(): void {
    this.isLoading = true;

    this._unitOfMeasureService.getAllUnitOfMeasures()
      .subscribe(apiMeasures => {
        this.measures = apiMeasures
        this.isLoading = false;
      });
  }
}
