import { Component, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/Servicios/cliente.service';

@Component({
  selector: 'app-filtro-cliente-nombre-completo',
  templateUrl: './filtro-cliente-nombre-completo.component.html',
  styleUrls: ['./filtro-cliente-nombre-completo.component.css']
})
export class FiltroClienteNombreCompletoComponent implements OnInit {
clientes: any
  constructor(private clienteService: ClienteService) { }

  ngOnInit() {
  }


buscar(nombreCompleto){

  this.clienteService.getFiltrarCliente(nombreCompleto.value).subscribe(
    resp => this.clientes = resp
  );
}

}
