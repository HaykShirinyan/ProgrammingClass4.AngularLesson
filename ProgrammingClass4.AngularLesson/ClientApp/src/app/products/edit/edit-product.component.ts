import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Manufactuer } from "../../shared/models/manufactuer";
import { Product } from "../../shared/models/product";
import { ManufacturerService } from "../../shared/services/manufacturer.service";
import { ProductService } from "../../shared/services/product.service";

@Component({
  templateUrl: './edit-product.component.html'
})
export class EditProductComponent implements OnInit {
  public product: Product = {};
  public isLoading: boolean = false;
  public spinnerMessage?: string;

  public manufacturers: Manufactuer[] = [];

  constructor(
    private readonly _productService: ProductService,
    private readonly _activeRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _manufacturerService: ManufacturerService
  ) {

  }

  public async ngOnInit(): Promise<void> {
    this.isLoading = true;
    this.spinnerMessage = 'Loading Product';

    this.product = await this._productService.getProduct(+this._activeRoute.snapshot.paramMap.get('id')!);
    this.manufacturers = await this._manufacturerService.getAll();

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
}
