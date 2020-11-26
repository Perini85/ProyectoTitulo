import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder,FormControl, Validators } from '@angular/forms';
import { ClienteService } from 'src/app/Servicios/cliente.service';
import { Router, ActivatedRoute } from '@angular/router';



@Component({
  selector: 'cliente-form-mantenimiento',
  templateUrl: './cliente-form-mantenimiento.component.html',
  styleUrls: ['./cliente-form-mantenimiento.component.css']
})
export class ClienteFormMantenimientoComponent implements OnInit {
cliente: FormGroup
titulo: string = "";
 parametro: string ;
tipoClientes: any;
comunas: any;

  constructor(private clienteService: ClienteService,private fb: FormBuilder,
    private route: Router,
    private activatedRoute: ActivatedRoute) { 

    this.cliente = new FormGroup(
      {
  'idCliente': new FormControl("0"),
  'rutCliente':new FormControl("", [Validators.required,Validators.maxLength(10)]),
  'nombreCliente':new FormControl("", [Validators.required,Validators.maxLength(50)]),
  'apellidosCliente':new FormControl("", [Validators.required,Validators.maxLength(50)]),
  'direccionCliente':new FormControl("", [Validators.required,Validators.maxLength(50)]),
  'numero':new FormControl("", [Validators.required,Validators.maxLength(10)]),
  //'idtipoCliente':new FormControl("", [Validators.required]),
  //'idcomuna':new FormControl("", [Validators.required]),
  'correo': new FormControl("", [Validators.required, Validators.maxLength(25), Validators.pattern("^[^@]+@[^@]+\.[a-zA-Z]{2,}$")])

  
   });

   this.activatedRoute.params.subscribe(parametro => {
    this.parametro = parametro["id"];
    if (this.parametro == "nuevo") {
      this.route.navigate(["/guardar-cliente"])
     // this.titulo = "Agregando una nueva persona";
    } else {
      this.titulo = "Editando a la persona";
    }
  });


  }

  ngOnInit() {
  

   this.clienteService.getTipoCliente().subscribe(data =>{
     this.tipoClientes = data
   });

   this.clienteService.getComuna().subscribe(data =>{
     this.comunas = data
   })


    if (this.parametro != "nuevo"){
      this.clienteService.recuperarCliente(this.parametro).subscribe(param => {

        this.cliente.controls["idCliente"].setValue(param.idCliente);
        this.cliente.controls["rutCliente"].setValue(param.rutCliente);
        this.cliente.controls["nombreCliente"].setValue(param.nombreCliente);
        this.cliente.controls["apellidosCliente"].setValue(param.apellidosCliente);
        this.cliente.controls["direccionCliente"].setValue(param.direccionCliente);
        this.cliente.controls["numero"].setValue(param.numero);
        this.cliente.controls["correo"].setValue(param.correo);
        //this.cliente.controls["idtipoCliente"].setValue(param.idtipoCliente);
        //this.cliente.controls["idcomuna"].setValue(param.idtipoCliente);
        //this.cliente.controls["habilitado"].setValue("1");









      });


    } 


  }


  GuardarCliente(){
    
    if(this.cliente.valid == true){
      if(this.parametro =="nuevo"){
        this.clienteService.agregar2(this.cliente.value).subscribe(data =>{
          this.route.navigate(["/mantenimiento-cliente"])
        });
      }
      this.clienteService.agregarCliente(this.cliente.value).subscribe(data => {
       
        this.route.navigate(["/mantenimiento-cliente"])
      })
    }
  }

}
