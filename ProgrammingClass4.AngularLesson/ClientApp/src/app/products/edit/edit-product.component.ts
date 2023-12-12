import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Manufacturer } from "../../shared/models/manufacturer";
import { Product } from "../../shared/models/product";
import { ManufacturerService } from "../../shared/services/manufacturer.service";
import { ProductService } from "../../shared/services/product.service";
import { ProductTypeService } from "../../shared/services/product-type.service";
import { UnitOfMeasureService } from "../../shared/services/unit-of-measure.service";
import { ProductType } from "../../shared/models/product-type";
import { UnitOfMeasure } from "../../shared/models/unit-of-measure";

@Component({
  templateUrl: './edit-product.component.html'
})
export class EditProductComponent implements OnInit {
  public product: Product = {};
  public isLoading: boolean = false;
  public spinnerMessage?: string;

  public manufacturers: Manufacturer[] = [];
  public productTypes: ProductType[] = [];
  public unitOfMeasures: UnitOfMeasure[] = [];
  constructor(
    private readonly _productService: ProductService,
    private readonly _activeRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _manufacturerService: ManufacturerService,
    private readonly _productTypeService: ProductTypeService,
    private readonly _unitOfMeasureService:UnitOfMeasureService
  ) {

  }

  public async ngOnInit(): Promise<void> {
    this.isLoading = true;
    this.spinnerMessage = 'Loading Product';

    this.product = await this._productService.getProduct(+this._activeRoute.snapshot.paramMap.get('id')!);
    this.manufacturers = await this._manufacturerService.getAll();
    this.productTypes = await this._productTypeService.getAll();
    this.unitOfMeasures = await this._unitOfMeasureService.getAll();

    this.isLoading = false;    
  }

  public async updateProduct(form: NgForm): Promise<void> {
    if (form.valid) {
      this.isLoading = true;
      this.spinnerMessage = 'Updating Product';

      await this._productService.updateProduct(this.product);

      this._router.navigate(['/products']);
      this.isLoading = false;
    }
  }

  public manufacturerChanged(manufacturerId: number): void {
    if (manufacturerId) {
      this.product.manufacturer = {
        id: manufacturerId
      };
    } else {
      this.product.manufacturer = undefined;
    }
  }
  public productTypeChanged(productTypeId: number): void {
    if (productTypeId) {
      this.product.productType = {
        id: productTypeId
      };
    } else {
      this.product.productType = undefined;
    }
  }
  public unitOfMeasureChanged(unitOfMeasureId: number): void {
    if (unitOfMeasureId) {
      this.product.unitOfMeasure = {
        id: unitOfMeasureId
      };
    } else {
      this.product.unitOfMeasure = undefined;
    }
  }
}
