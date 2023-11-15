import { Component } from "@angular/core";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
  templateUrl: './create-unit-of-measure.component.html'
})
export class CreateUnitOfMeasureComponent {
  public unitOfMeasure: UnitOfMeasure = {};

  constructor(
    private readonly _unitOfMeasureService: UnitOfMeasureService,
    private readonly _router: Router
  ) {
  }

  public createUnitOfMeasure(form: NgForm): void {
    if (form.valid) {
      this._unitOfMeasureService.addUnitOfMeasure(this.unitOfMeasure)
        .subscribe(() => {
          this._router.navigate(['/unitOfMeasures']);
        });
    }
  }
}
