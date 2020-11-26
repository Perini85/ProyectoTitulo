import { Component, OnInit ,Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'buscador-cliente-nombre-completo',
  templateUrl: './buscador-cliente-nombre-completo.component.html',
  styleUrls: ['./buscador-cliente-nombre-completo.component.css']
})
export class BuscadorClienteNombreCompletoComponent implements OnInit {
@Output() buscarCliente: EventEmitter<any>;
  constructor() { 
    this.buscarCliente = new EventEmitter();
  }

  ngOnInit() {
  }

  buscar(nombreCompleto){
    this.buscarCliente.emit(nombreCompleto)
  }
}
