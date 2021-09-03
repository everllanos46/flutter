import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../models/usuario';
import {catchError, map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UsuarioServiceService {
  ruta: String="https://localhost:5001/";
  constructor(private http:HttpClient) { }

  post(usuario: Usuario){
    return this.http.post(this.ruta+"api/Usuario",usuario).pipe(
      tap(()=>console.log("Se ha registrado"))
    );
  }


}
