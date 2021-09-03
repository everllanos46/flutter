import { Inject, Injectable } from '@angular/core';
import {HttpHeaders, HttpClient} from "@angular/common/http";
import { Observable } from 'rxjs';
import {tap} from 'rxjs/operators';
import { Proveedor } from '../models/proveedor';

@Injectable({
  providedIn: 'root'
})
export class ProveedorService {
  ruta: String="https://localhost:5001/";
  constructor(private http:HttpClient) { }

  get():Observable<Proveedor[]>{
    debugger
    return this.http.get<Proveedor[]>(this.ruta+"api/Proveedor").pipe(
      tap(()=>console.log("Consultado correctamente"))
    )
  }
}
