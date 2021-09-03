import { Inject, Injectable } from '@angular/core';
import {HttpHeaders, HttpClient} from "@angular/common/http";
import { Observable } from 'rxjs';
import { Producto } from '../models/producto';
import {tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductoServiceService {
  ruta: String="https://localhost:5001/";
  constructor( private http:HttpClient) {
    
   }

   get():Observable<Producto[]>{
    return this.http.get<Producto[]>(this.ruta+"api/Producto").pipe(
      tap(()=>console.log("Consultado correctamente"))
    )
  }

  post(producto: Producto){
    return this.http.post(this.ruta+"api/Producto",producto).pipe(
      tap(()=>console.log("Se ha registrado"))
    );
  }



}
