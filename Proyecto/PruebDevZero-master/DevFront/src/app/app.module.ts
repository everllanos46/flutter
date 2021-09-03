import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NavComponent } from './nav/nav.component';
import { ConsultarProductosComponent } from './consultar-productos/consultar-productos.component';
import { HttpClientModule } from '@angular/common/http';
import { RegistrarClienteComponent } from './registrar-cliente/registrar-cliente.component';
import { RegistrarProductoComponent } from './registrar-producto/registrar-producto.component';
import { FacturaCompraComponent } from './factura-compra/factura-compra.component';
import { FacturaVentaComponent } from './factura-venta/factura-venta.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavComponent,
    ConsultarProductosComponent,
    RegistrarClienteComponent,
    RegistrarProductoComponent,
    FacturaCompraComponent,
    FacturaVentaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
