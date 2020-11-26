import { Component, OnInit, Input } from '@angular/core';
import { ClienteService } from '../../Servicios/cliente.service';


@Component({
  selector: 'tabla-cliente',
  templateUrl: './tabla-cliente.component.html',
  styleUrls: ['./tabla-cliente.component.css']
})
export class TablaClienteComponent implements OnInit {
  @Input() clientes: any;
  @Input() isMantenimiento = false;
  p: number = 1;


  cabeceras: string[] = ["Id Cliente", "Nombre completo", "Telefono", "Correo"];


  constructor(private clienteService: ClienteService) { }

  ngOnInit() {

    this.clienteService.getCliente().subscribe(resp => {this.clientes = resp})
  }



  eliminar(idCliente){
    if (confirm(" Desea eliminar el cliente de la tabla?") == true) {
     this.clienteService.eliminarCliente(idCliente).subscribe(data =>{
       this.clienteService.getCliente().subscribe(dato =>{this.clientes = dato})
     })
    }
  }
  

}
