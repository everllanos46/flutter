import { Component, OnInit } from '@angular/core';
import { Producto } from '../models/producto';
import { ProductoServiceService } from '../services/producto-service.service';

@Component({
  selector: 'app-consultar-productos',
  templateUrl: './consultar-productos.component.html',
  styleUrls: ['./consultar-productos.component.css']
})
export class ConsultarProductosComponent implements OnInit {
  productos: Producto[]=[]
  productoCard : Producto;
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
    console.log(this.productoCard)
    
  }

}
