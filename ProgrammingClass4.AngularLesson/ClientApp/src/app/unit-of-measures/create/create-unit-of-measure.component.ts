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
  public isLoading: boolean = false;

  constructor(
    private readonly _unitOfMeasureService: UnitOfMeasureService,
    private readonly _router: Router
  ) {
  }

  public async createUnitOfMeasure(form: NgForm): Promise<void> {
    if (form.valid) {
      this.isLoading = true;

      await this._unitOfMeasureService.addUnitOfMeasure(this.unitOfMeasure)
        
      this._router.navigate(['/unitOfMeasures']);
      this.isLoading = false;
    }
  }
}
