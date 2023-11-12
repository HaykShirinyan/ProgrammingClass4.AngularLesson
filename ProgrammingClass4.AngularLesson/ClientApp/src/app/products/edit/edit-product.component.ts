import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Product } from "../../shared/models/product";
import { ProductService } from "../../shared/services/product.service";

@Component({
  templateUrl: './edit-product.component.html'
})
export class EditProductComponent implements OnInit {
  public product: Product = {};

  constructor(
    private readonly _productService: ProductService,
    private readonly _activeRoute: ActivatedRoute,
    private readonly _router: Router
  ) {

  }

  public ngOnInit(): void {
    this._productService.getProduct(+this._activeRoute.snapshot.paramMap.get('id')!)
      .subscribe(product => {
        this.product = product;
      });
  }

  public updateProduct(form: NgForm): void {
    if (form.valid) {
      this._productService.updateProduct(this.product)
        .subscribe(() => {
          this._router.navigate(['/products']);
        });
    }
  }
}