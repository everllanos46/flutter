import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Estudiante } from '../models/estudiante';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class EstudianteService {

  constructor() { }

  get(): Estudiante[] {
    return JSON.parse(localStorage.getItem('estudiantes') || '{}')
  }

  post(estudiante: Estudiante): Observable<any> {
    let estudiantes: Estudiante[] = []
    if (this.get().length > 0) {
      estudiantes = this.get()
    }
    var valorSubsidiado = this.validarPresupuesto(estudiantes);
    var respuesta=estudiantes.find(e=>e.identificacion===estudiante.identificacion);
    if(respuesta!=undefined){
      alert('Estudiante ya solicitó el subsidio'); 
      return of (null);
    } 

    
    if (valorSubsidiado >= 100000000) {
      alert("Tope alcanzado")
      return of (null);
    } else {
      var subsidio = this.calcularSubsidio(estudiante);
      if ((valorSubsidiado + subsidio.subsidio) > 100000000) {
        alert("Supera el topoe")
        return of (null);
      }else{
        debugger
        estudiante.subsidio = subsidio.subsidio;
        estudiante.matriculaInicial=estudiante.matricula;
        estudiante.matricula=estudiante.matricula-estudiante.subsidio;
        estudiante.porcentaje=subsidio.porcentaje;
        estudiantes.push(estudiante);
        localStorage.setItem('estudiantes', JSON.stringify(estudiantes));
        return of(estudiante);
      }
    }
    return of (null);
  }

  calcularSubsidio(estudiante: Estudiante) {
    if (estudiante.sisben == "A" || estudiante.sisben == "B") {
      return {porcentaje:100, subsidio:estudiante.matricula};
    } else if (estudiante.sisben == "C") {
      var subsidio=estudiante.matricula*0.6;
      return {porcentaje:60, subsidio:subsidio};
    } else {
      return {porcentaje:0, subsidio:0};
    }
  }

  validarPresupuesto(estudiantes: Estudiante[]) {
    var valorSubsidiado = 0;
    estudiantes.forEach(e => {
      valorSubsidiado += e.subsidio;
    }); 
    return valorSubsidiado;
  }

  totalSubsidio(estudiantes: Estudiante[]){
    var totalSubsidio=0;
    estudiantes.forEach(e => {totalSubsidio+=e.subsidio;
    });
    return totalSubsidio;
  }

}
