import { Injectable, Inject } from '@angular/core';
//import { Http } from '@angular/http';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Cliente } from '../Models/cliente';



@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  urlBase: string = "";

  httpOtions = {
    headers: new HttpHeaders ({
    'Content-Type': 'application/json'
    })
};



  constructor(private http: HttpClient, @Inject('BASE_URL') url: string) {
    this.urlBase = url;

  }

  getCliente() {

    return this.http.get(this.urlBase + "api/cliente/listarClientes",this.httpOtions)
  }

  getTipoCliente(){
    return this.http.get(this.urlBase + "api/TipoCliente/listarTipoClientes",this.httpOtions)

  }

  getComuna(){
    return this.http.get(this.urlBase + "api/Comuna/listarComunas",this.httpOtions)

  }


  getFiltrarCliente(nombreCompleto){
   return this.http.get(this.urlBase + "api/cliente/filtrarClientes/" + nombreCompleto,this.httpOtions)
  }

  agregarCliente(cliente):Observable<any>{
   return  this.http.post(this.urlBase + "api/cliente/guardarCliente",cliente,this.httpOtions)
  }

  agregar2(cliente: Cliente):Observable<Cliente>{
    return  this.http.post<Cliente>(this.urlBase + "api/cliente/guardar",cliente,this.httpOtions)

  }


  recuperarCliente(idCliente):Observable<any>{
    return this.http.get(this.urlBase + "api/cliente/recuperarCliente/" + idCliente,this.httpOtions)
  }


  eliminarCliente(idCliente){
    return this.http.get(this.urlBase + "api/cliente/eliminarCliente/" + idCliente, this.httpOtions)
  }

  ValidarCorreo(idCliente,correo){
    return this.http.get(this.urlBase + "api/cliente/validarCorreo/" + idCliente + "/" + correo,this.httpOtions)
  }

  listarClienteCombo(){
    return this.http.get(this.urlBase +"api/cliente/listarComboCliente", this.httpOtions)
  }
}
