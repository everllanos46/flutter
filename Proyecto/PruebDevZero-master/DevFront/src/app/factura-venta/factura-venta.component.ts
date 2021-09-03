import { Component, OnInit } from '@angular/core';
import { Producto } from '../models/producto';
import { ProductoServiceService } from '../services/producto-service.service';

@Component({
  selector: 'app-factura-venta',
  templateUrl: './factura-venta.component.html',
  styleUrls: ['./factura-venta.component.css']
})
export class FacturaVentaComponent implements OnInit {
  productos: Producto[]=[]
  constructor(private productoService: ProductoServiceService) { }

  ngOnInit(): void {
    this.get()
  }

  get(){
    this.productoService.get().subscribe(resultado=>{
      if(resultado!=null){
        this.productos=resultado;
      }
     });
  }

}
