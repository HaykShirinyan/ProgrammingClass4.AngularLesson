import { Manufactuer } from "./manufactuer";

export interface Product {
  id?: number;
  name?: string;
  description?: string;
  quantity?: number;
  unitPrice?: number;
  manufacturer?: Manufactuer;
}
