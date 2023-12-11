
import { Manufacturer } from "./manufacturer";
import { ProductType } from "./product-type";
import { UnitOfMeasure } from "./unit-of-measure";

export interface Product {
  id?: number;
  name?: string;
  description?: string;
  quantity?: number;
  unitPrice?: number;
  manufacturer?: Manufacturer;
  unitOfMeasure?: UnitOfMeasure;
  productType?: ProductType;
}
