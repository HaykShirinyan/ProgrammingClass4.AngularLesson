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

  public async ngOnInit(): Promise<void> {
    this.isLoading = true;
    this.spinnerMessage = 'Loading UnitOfMeasure';

    this.unitOfMeasure = await this._unitOfMeasureService.getUnitOfMeasure(+this._activeRoute.snapshot.paramMap.get('id')!)

    this.isLoading = false;
     
  }

  public async editUnitOfMeasure(form: NgForm): Promise<void> {
    if (form.valid) {
      this.isLoading = true;

      await this._unitOfMeasureService.updateUnitOfMeasure(this.unitOfMeasure)
        
      this._router.navigate(['/unitOfMeasures']);
      this.isLoading = false;
    }
  }
}
