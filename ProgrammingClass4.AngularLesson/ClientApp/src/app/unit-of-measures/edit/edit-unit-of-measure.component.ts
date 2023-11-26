import { Component, OnInit } from "@angular/core";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { UnitOfMeasureService } from "../../shared/Service/unit-of-measure.service";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Location } from '@angular/common';

@Component({
  templateUrl: './edit-unit-of-measure.component.html'
})
export class EditUnitOfMeasureComponent implements OnInit {
  public unitOfMeasure: UnitOfMeasure = {};
  public isLoading: boolean = false;
  public spinnerMessage?: string;

  constructor(
    private readonly _unitOfMeasureService: UnitOfMeasureService,
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _location: Location
  ) {

  }

  public ngOnInit(): void {
    this.isLoading = true;
    this.spinnerMessage = 'Loading Unit Of Measure'

    this._unitOfMeasureService.getUnitOfMeasure(+this._activatedRoute.snapshot.paramMap.get('id')!)
      .subscribe(unitOfMeasure => {
        this.unitOfMeasure = unitOfMeasure;
        this.isLoading = false;
      });
  }

  public updateUnitOfMeasure(form: NgForm): void {
    if (form.valid) {
      this.isLoading = true;
      this.spinnerMessage = 'Updating Unit Of Measure'

      this._unitOfMeasureService.updateUnitOfMeasure(this.unitOfMeasure)
        .subscribe(() => {
          this._router.navigate(['/unit-of-measures']);
          this.isLoading = false;
        })
    }
  }

  public cancelEditing(): void {
    this._location.back();
  }
}
