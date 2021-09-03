import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario';
import { UsuarioServiceService } from '../services/usuario-service.service';

@Component({
  selector: 'app-registrar-cliente',
  templateUrl: './registrar-cliente.component.html',
  styleUrls: ['./registrar-cliente.component.css']
})
export class RegistrarClienteComponent implements OnInit {

  usuario: Usuario;
  constructor(private usuarioService: UsuarioServiceService) {
    this.usuario= new Usuario();
   }

  ngOnInit(): void {
  }

  add(){
    this.usuarioService.post(this.usuario).subscribe(result=>{
      if(result!=null){
        console.log(result)
      }
    });
  }

}
