import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioService } from 'src/app/Servicios/usuario.service';

@Component({
  selector: 'usuario-form-mantenimiento',
  templateUrl: './usuario-form-mantenimiento.component.html',
  styleUrls: ['./usuario-form-mantenimiento.component.css']
})
export class UsuarioFormMantenimientoComponent implements OnInit {
  usuario: FormGroup;
  titulo: string = "";
  parametro: string;
  tipoUsuarios: any;
  ver: boolean = true;

  constructor(private usuarioService: UsuarioService, private activatedRoute: ActivatedRoute,
    private router: Router) {

    this.usuario = new FormGroup({
      'idUsuario': new FormControl("0"),
      'nombreUsuario': new FormControl("", [Validators.required, Validators.maxLength(100)], this.noRepetirUsuario.bind(this)),
       'pass': new FormControl("", [Validators.required, Validators.maxLength(10)]),
      'pass2': new FormControl("", [Validators.required, Validators.maxLength(10),this.validarContraseña.bind(this)]),
      'rutUsuario': new FormControl("", [Validators.required, Validators.maxLength(10)]),
      'nombresUsuario': new FormControl("", [Validators.required, Validators.maxLength(100)]),
      'apellidosUsuario': new FormControl("", [Validators.required, Validators.maxLength(100)]),
      'correo': new FormControl("", [Validators.required, Validators.maxLength(100)]),
      'telefono': new FormControl("", [Validators.required, Validators.maxLength(10)]),
      'idtipoUsuario': new FormControl("", [Validators.required])
      // 'fechaNacimiento': new FormControl("", [Validators.required]),
       

    });



     this.activatedRoute.params.subscribe(param => {

      this.parametro = param["id"];
      if (this.parametro =="nuevo"){
        this.ver = true;
      } else {
        this.usuarioService.recuperarUsuario(this.parametro).subscribe(data =>{
          this.usuario.controls["idUsuario"].setValue(data.idUsuario);
          this.usuario.controls["nombreUsuario"].setValue(data.nombreUsuario);
          this.usuario.controls["rutUsuario"].setValue(data.rutUsuario);
          this.usuario.controls["nombresUsuario"].setValue(data.nombresUsuario);
          this.usuario.controls["apellidosUsuario"].setValue(data.apellidosUsuario);
          this.usuario.controls["correo"].setValue(data.correo);
          this.usuario.controls["telefono"].setValue(data.telefono);
          this.usuario.controls["idtipoUsuario"].setValue(data.idtipoUsuario);
          // this.usuario.controls["fechaNacimiento"].setValue(data.fechaNacimiento);
           
        this.usuario.controls["pass"].setValue("1");
           this.usuario.controls["pass2"].setValue("1");




        });
      }
     })

  }

  ngOnInit() {

  this.usuarioService.getTipoUsuario().subscribe(data => {
    this.tipoUsuarios = data
  });

  if (this.parametro == "nuevo") {
    this.titulo = "Agregar Usuario";
  } else {
    this.titulo = "Editar Usuario";
  }

  }

  noRepetirUsuario(control: FormControl) {

    var promesa = new Promise((resolve, reject) => {

      if (control.value != "" && control.value != null) {

        this.usuarioService.validarUsuario(this.usuario.controls["idUsuario"].value, control.value)
          .subscribe(data => {
            if (data == 1) {
              resolve({ yaExiste: true });
            } else {
              resolve(null);
            }

          })

      }


    });

    return promesa;
  }

  validarContraseña(control: FormControl) {

    if (control.value != "" && control.value != null) {

      if (this.usuario.controls["pass"].value != control.value) {
        return { noIguales: true };
      } else {
        return null;
      }
    }
  }

  GuardarUsuario() {
     if (this.usuario.valid == true) {
      this.usuarioService.guardarDatos(this.usuario.value).subscribe(resp => {
         this.router.navigate(["/mantenimiento-usuario"])
       })
     }
       console.log(this.usuario)
  }

}
