import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ProductListComponent } from './products/list/product-list.component';
import { UnitOfMeasureListComponent } from './unit-of-measures/list/unit-of-measure-list.component';
import { ProductTypeListComponent } from './product-type/list/product-type-list.component';
import { CreateProductComponent } from './products/create/create-product.component';
import { EditProductComponent } from './products/edit/edit-product.component';
import { CreateProductTypeComponent } from './product-type/create/create-product-type.component';
import { CreateUnitOfMeasureComponent } from './unit-of-measures/create/create-unit-of-measure.component';
import { EditUnitOfMeasureComponent } from './unit-of-measures/edit/edit-unit-of-measure.component';
import { EditProductTypeComponent } from './product-type/edit/edit-product-type.component';
import { LoadingSpinnerComponent } from './shared/components/loading-spinner/loading-spinner.component';
import { BackComponent } from './shared/components/back/back.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductListComponent,
    UnitOfMeasureListComponent,
    ProductTypeListComponent,
    CreateProductComponent,
    EditProductComponent,
    CreateProductTypeComponent,
    CreateUnitOfMeasureComponent,
    EditUnitOfMeasureComponent,
    EditProductTypeComponent,
    LoadingSpinnerComponent,
    BackComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'products', component: ProductListComponent },
      { path: 'unitOfMeasures', component: UnitOfMeasureListComponent },
      { path: 'productTypes', component: ProductTypeListComponent },
      { path: 'products/create', component: CreateProductComponent },
      { path: 'products/edit/:id', component: EditProductComponent },
      { path: 'productTypes/create', component: CreateProductTypeComponent },
      { path: 'unitOfMeasures/create', component: CreateUnitOfMeasureComponent },
      { path: 'unitOfMeasures/edit/:id', component: EditUnitOfMeasureComponent },
      { path: 'productTypes/edit/:id', component: EditProductTypeComponent}
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
