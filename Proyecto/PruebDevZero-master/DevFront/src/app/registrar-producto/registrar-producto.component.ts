import { Component, OnInit } from '@angular/core';
import { Producto } from '../models/producto';
import { Proveedor } from '../models/proveedor';
import { ProductoServiceService } from '../services/producto-service.service';
import { ProveedorService } from '../services/proveedor.service';

@Component({
  selector: 'app-registrar-producto',
  templateUrl: './registrar-producto.component.html',
  styleUrls: ['./registrar-producto.component.css']
})
export class RegistrarProductoComponent implements OnInit {
 
  proveedores : Proveedor[]=[]
  proveedor : Proveedor = new Proveedor();
  producto : Producto;
  selected: string;
  constructor(private proveedorService: ProveedorService, private productoService: ProductoServiceService) {
    this.producto = new Producto();
   }

  ngOnInit(): void {
    this.get();
  }

  get(){
    this.proveedorService.get().subscribe(resultado=>{
      if(resultado!=null){
        this.proveedores=resultado;
      }
     });
  }

  add(){
    this.producto.proveedor=this.proveedor
    console.log(this.producto)
    this.productoService.post(this.producto).subscribe(result=>{
      if(result!=null){
        console.log(result)
      }
    });
  }

 
  

  CambiarProveedor(event){
    const value = event.target.value;
    this.selected = value;
    this.proveedor=this.proveedores.find(p=>p.idProveedor==this.selected)
  }

}
