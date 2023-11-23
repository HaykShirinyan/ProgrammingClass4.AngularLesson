import { Component, OnInit } from "@angular/core";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
  templateUrl: './edit-unit-of-measure.component.html'
})

export class EditUnitOfMeasureComponent implements OnInit {
  public unitOfMeasure: UnitOfMeasure = {};
  public isLoading: boolean = false;
  public spinnerMessage?: string;

  constructor(
    private readonly _unitOfMeasureService: UnitOfMeasureService,
    private readonly _activeRoute: ActivatedRoute,
    private readonly _router: Router
  ) {

  }

  public ngOnInit(): void {
    this.isLoading = true;
    this.spinnerMessage = 'Loading UnitOfMeasure';

    this._unitOfMeasureService.getUnitOfMeasure(+this._activeRoute.snapshot.paramMap.get('id')!)
      .subscribe(unitOfMeasure => {
        this.unitOfMeasure = unitOfMeasure;
        this.isLoading = false;
      });
  }

  public editUnitOfMeasure(form: NgForm): void {
    if (form.valid) {
      this.isLoading = true;
      this._unitOfMeasureService.updateUnitOfMeasure(this.unitOfMeasure)
        .subscribe(() => {
          this._router.navigate(['/unitOfMeasures']);
          this.isLoading = false;
        });
    }
  }
}
