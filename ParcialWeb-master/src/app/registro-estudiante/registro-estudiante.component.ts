import { Component, OnInit } from '@angular/core';
import { Estudiante } from '../models/estudiante';
import {EstudianteService} from '../services/estudiante.service';


@Component({
  selector: 'app-registro-estudiante',
  templateUrl: './registro-estudiante.component.html',
  styleUrls: ['./registro-estudiante.component.css']
})
export class RegistroEstudianteComponent implements OnInit {

  estudiante: Estudiante;

  constructor(private estudianteService: EstudianteService) { 
    this.estudiante= new Estudiante()
  }


  ngOnInit(): void {

  }

  add(){
    this.estudianteService.post(this.estudiante).subscribe(resultado=>{
      if(resultado!=null){
        alert("Estudiante Guardado");
      }
    });
  }

}
