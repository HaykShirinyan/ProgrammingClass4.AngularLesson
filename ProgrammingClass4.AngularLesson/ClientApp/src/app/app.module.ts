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
import { ProductTypeListComponent } from './product-types/list/product-type-list.component';
import { UnitOfMeasureListComponent } from './unit-of-measures/unit-of-measure-list.component';
import { CreateProductComponent } from './products/create/create-product.component';
import { EditProductComponent } from './products/edit/edit-product.component';
import { CreateProductTypeComponent } from './product-types/create/create-product-type.component';
import { EditProductTypeComponent } from './product-types/edit/edit-product-type.component';
import { CreateUnitOfMeasureComponent } from './unit-of-measures/create/create-unit-of-measure.component';
import { EditUnitOfMeasureComponent } from './unit-of-measures/edit/edit-unit-of-measure.component';
import { LoadingSpinnerComponent } from './shared/components/loading-spinner/loading-spinner.component';
import { CancelComponent } from './shared/components/cancel/cancel.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CreateProductComponent,
    EditProductComponent,
    ProductListComponent,
    ProductTypeListComponent,
    UnitOfMeasureListComponent,
    CreateProductTypeComponent,
    EditProductTypeComponent,
    CreateUnitOfMeasureComponent,
    EditUnitOfMeasureComponent,
    LoadingSpinnerComponent,
    CancelComponent
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
      { path: 'product-types', component: ProductTypeListComponent },
      { path: 'unit-of-measures', component:UnitOfMeasureListComponent },
      { path: 'products', component: ProductListComponent },
      { path: 'products/create', component: CreateProductComponent },
      { path: 'products/edit/:id', component: EditProductComponent },
      { path: 'product-types/create', component: CreateProductTypeComponent },
      { path: 'product-types/edit/:id', component: EditProductTypeComponent },
      { path: 'unit-of-measures/create', component: CreateUnitOfMeasureComponent },
      { path: 'unit-of-measures/edit/:id', component:EditUnitOfMeasureComponent}
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
