import { Component, OnInit } from '@angular/core';
import {Estudiante} from '../models/estudiante';
import {EstudianteService} from '../services/estudiante.service';

@Component({
  selector: 'app-consulta-estudiante',
  templateUrl: './consulta-estudiante.component.html',
  styleUrls: ['./consulta-estudiante.component.css']
})
export class ConsultaEstudianteComponent implements OnInit {
  estudiantes: Estudiante[]=[];
  
  constructor(private estudianteService: EstudianteService) { }

  get(): Estudiante[]{
    return JSON.parse(localStorage.getItem('estudiantes') || '{}');
  }
  ngOnInit(): void {
    if(this.get()!=null){
      this.estudiantes=this.get();
    }
  }

  traerTotalSubsidio(){
    return this.estudianteService.totalSubsidio(this.estudiantes);
  }




}
