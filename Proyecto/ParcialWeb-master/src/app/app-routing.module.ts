import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {RegistroEstudianteComponent} from './registro-estudiante/registro-estudiante.component';
import {ConsultaEstudianteComponent} from './consulta-estudiante/consulta-estudiante.component';
import { CommonModule } from '@angular/common';



const routes: Routes = [
  {
    path: 'estudianteRegistro',
    component: RegistroEstudianteComponent
  },
  {
    path:'estudianteConsulta',
    component: ConsultaEstudianteComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes),
  CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
