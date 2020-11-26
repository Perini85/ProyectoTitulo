import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder,Validators} from '@angular/forms';
import { ActivatedRoute,Router } from '@angular/router';
import { Cliente } from 'src/app/Models/cliente';
import { ClienteService } from 'src/app/Servicios/cliente.service';

@Component({
  selector: 'guardar-cliente',
  templateUrl: './guardar-cliente.component.html',
  styleUrls: ['./guardar-cliente.component.css']
})
export class GuardarClienteComponent implements OnInit {
  clientes: FormGroup
  cliente: Cliente

  constructor(private clienteService: ClienteService, private fb: FormBuilder,
     private route:ActivatedRoute,private router: Router) { 

      this.clientes = this.fb.group({
        nombreCliente:['',Validators.required],
        apellidosCliente:['',Validators.required],
        correo:['',Validators.required],
        direccionCliente:['',Validators.required],
        numero:['',Validators.required],
        rutCliente:['',Validators.required],
        //  idcomuna:['']
      


       


      });

     }

  ngOnInit() {
  }

  agregarCliente(){
    
    const cliente: Cliente = {
     // idCliente: this.clientes.get('idCliente').value,
      rutCliente: this.clientes.get('rutCliente').value,

      nombreCliente: this.clientes.get('nombreCliente').value,
      apellidosCliente: this.clientes.get('apellidosCliente').value,
      correo: this.clientes.get('correo').value,
      direccionCliente: this.clientes.get('direccionCliente').value,
      numero: this.clientes.get('numero').value,
      //  idcomuna: this.clientes.get('idcomuna').value
    /*--  idtipoCliente: this.clientes.get('idtipoCliente').value,
      ,--*/

     // idTipoCliente: this.clientes.get('idTipoCliente').value,
     

      



    };
    console.log(cliente)
    this.clienteService.agregar2(cliente).subscribe(resp =>{
      this.router.navigate(['/mantenimiento-cliente'])

    });
}
}