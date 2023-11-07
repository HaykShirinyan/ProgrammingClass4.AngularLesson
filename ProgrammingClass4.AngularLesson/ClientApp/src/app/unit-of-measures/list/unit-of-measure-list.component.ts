import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";



@Component({
  templateUrl: './unit-of-measure-list.component.html'
})
export class UnitOfMeasureListComponent {
  private readonly _unitOfMeasureService:UnitOfMeasureService;

  public unitOfMeasures?: UnitOfMeasure[];

  constructor(unitOfMeasureService: UnitOfMeasureService) {
    this._unitOfMeasureService = unitOfMeasureService
  }

  public ngOnInit(): void {
    this._unitOfMeasureService.getAll()
      .subscribe(apiUnitOfMeasures => {
        this.unitOfMeasures = apiUnitOfMeasures
      });
  }
}
