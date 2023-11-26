import { Component } from "@angular/core";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure"
import { UnitOfMeasureService } from "../../shared/Service/unit-of-measure.service";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Location } from '@angular/common';

@Component({
  templateUrl:'./create-unit-of-measure.component.html'
})
export class CreateUnitOfMeasureComponent {
  public unitOfMeasure: UnitOfMeasure = {};
  public isLoading: boolean = false;

  constructor(
    private readonly _unitOfMeasureService: UnitOfMeasureService,
    private readonly _router: Router,
    private readonly _location:Location
  ) {
  }

  public createUnitOfMeasure(form: NgForm): void {
    if (form.valid) {
      this.isLoading = true;

      this._unitOfMeasureService.addUnitOfMeasure(this.unitOfMeasure)
        .subscribe(() => {
          this._router.navigate(['/unit-of-measures'])
          this.isLoading = false;
        })
    }
  }

  public cancelCreating(): void {
    this._location.back();
  }
}
