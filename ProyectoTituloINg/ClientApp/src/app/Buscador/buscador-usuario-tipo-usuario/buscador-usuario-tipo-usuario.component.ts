import { Component, OnInit,Output, EventEmitter } from '@angular/core';
import { UsuarioService } from 'src/app/Servicios/usuario.service';

@Component({
  selector: 'buscador-usuario-tipo-usuario',
  templateUrl: './buscador-usuario-tipo-usuario.component.html',
  styleUrls: ['./buscador-usuario-tipo-usuario.component.css']
})
export class BuscadorUsuarioTipoUsuarioComponent implements OnInit {
  tipoUsuarios: any;
  @Output() tipoUsuario: EventEmitter<any>;
  constructor(private usuarioService: UsuarioService) { 
    this.tipoUsuario = new EventEmitter();

  }

  ngOnInit() {
    this.usuarioService.getTipoUsuario().subscribe(data =>{this.tipoUsuarios=data})
  }


filtrar(tipo){
  this.tipoUsuario.emit(tipo);
}

}
