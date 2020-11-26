import { Inject, Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  urlBase: string = "";


  httpOtions = {
    headers: new HttpHeaders ({
    'Content-Type': 'application/json'
    })
};



  constructor(private http: HttpClient, @Inject('BASE_URL') url: string) {
    this.urlBase = url;

   }


   getTipoUsuario(){
    return this.http.get(this.urlBase + "api/Usuario/listarTipoUsuario", this.httpOtions);
   }

   getUsuario(){

    return this.http.get(this.urlBase +"api/Usuario/listarUsuario", this.httpOtions);

   }

   filtrarUsuarioPorTipo(idTipo) {
    return this.http.get(this.urlBase + "api/Usuario/filtrarUsuarioPorTipo/" + idTipo, this.httpOtions)
   }

   validarUsuario(idUsuario, nombre) {

    return this.http.get(this.urlBase + "api/Usuario/validarUsuario/" + idUsuario + "/" + nombre, this.httpOtions)
  }

  guardarDatos(usuarioCLS):Observable<any>{

    return this.http.post(this.urlBase + "api/Usuario/guardarDatos", usuarioCLS, this.httpOtions)
  }

  eliminarUsuario(idUsuario) {

    return this.http.get(this.urlBase + "api/Usuario/eliminarUsuario/" + idUsuario,this.httpOtions )
  }

  recuperarUsuario(idUsuario):Observable<any>{
    return this.http.get(this.urlBase + "api/Usuario/recuperarUsuario/" + idUsuario, this.httpOtions)
  }

}
