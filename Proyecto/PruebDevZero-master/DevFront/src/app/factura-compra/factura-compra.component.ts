
import { Component, OnInit } from '@angular/core';
import { Detalle } from '../models/detalle';
import { Producto } from '../models/producto';
import { ProductoServiceService } from '../services/producto-service.service';

@Component({
  selector: 'app-factura-compra',
  templateUrl: './factura-compra.component.html',
  styleUrls: ['./factura-compra.component.css']
})
export class FacturaCompraComponent implements OnInit {
  productos: Producto[]=[]
  productoCard : Producto;
  agregado: boolean=false;
  subtotal: number=0;
  productosCarrito : Detalle[]=[];
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

  productoTabla(pos: number){
    this.productoCard=this.productos[pos]
    
  }

  agregarCarrito(){
    let detalle: Detalle = new Detalle();
    this.agregado=true;
    detalle.cantidadProducto=this.productoCard.cantidad;
    detalle.productoId=this.productoCard.codigo;
    detalle.descuento=this.productoCard.descuento;
    detalle.valorProducto=this.productoCard.precio;
    detalle.nombre=this.productoCard.nombre;
    if(this.productosCarrito.find(p=>p.productoId==detalle.productoId)==null)
    this.productosCarrito.push(detalle)
  }

  calcularSubtotal(event){
     this.productosCarrito.forEach(f=>{
       this.subtotal+=f.valorProducto
     });
  }

}
