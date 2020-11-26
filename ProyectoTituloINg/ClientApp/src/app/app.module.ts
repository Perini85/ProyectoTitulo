import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TablaClienteComponent } from './Tablas/tabla-cliente/tabla-cliente.component';
import { FiltroClienteNombreCompletoComponent } from './Filtrar/filtro-cliente-nombre-completo/filtro-cliente-nombre-completo.component';
import { BuscadorClienteNombreCompletoComponent } from './Buscador/buscador-cliente-nombre-completo/buscador-cliente-nombre-completo.component';
import { ClienteFormMantenimientoComponent } from './Mantenedores/cliente-form-mantenimiento/cliente-form-mantenimiento.component';
import { MantenimientoClienteComponent } from './RutaMantenedor/mantenimiento-cliente/mantenimiento-cliente.component';
import { GuardarClienteComponent } from './Guardar/guardar-cliente/guardar-cliente.component';
import { TablaUsuarioComponent } from './Tablas/tabla-usuario/tabla-usuario.component';
import { UsuarioFormMantenimientoComponent } from './Mantenedores/usuario-form-mantenimiento/usuario-form-mantenimiento.component';
import { FiltradoUsuarioTipoUsuarioComponent } from './Filtrar/filtrado-usuario-tipo-usuario/filtrado-usuario-tipo-usuario.component';
import { BuscadorUsuarioTipoUsuarioComponent } from './Buscador/buscador-usuario-tipo-usuario/buscador-usuario-tipo-usuario.component';
import { MantenimientoUsuarioComponent } from './RutaMantenedor/mantenimiento-usuario/mantenimiento-usuario.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TablaClienteComponent,
    FiltroClienteNombreCompletoComponent,
    BuscadorClienteNombreCompletoComponent,
    MantenimientoClienteComponent,
    ClienteFormMantenimientoComponent,
    GuardarClienteComponent,
    TablaUsuarioComponent,
    UsuarioFormMantenimientoComponent,
    FiltradoUsuarioTipoUsuarioComponent,
    BuscadorUsuarioTipoUsuarioComponent,
    MantenimientoUsuarioComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: TablaClienteComponent },
      { path: 'filtradoClienteNombreCompleto', component: FiltroClienteNombreCompletoComponent },
      { path: 'mantenimiento-cliente', component: MantenimientoClienteComponent },
      { path: 'cliente-form-mantenimiento/:id', component: ClienteFormMantenimientoComponent },
      { path: 'guardar-cliente', component: GuardarClienteComponent },
      { path: 'usuario-form-mantenimiento/:id', component: UsuarioFormMantenimientoComponent},
      { path: 'filtradoUsuarioTipo', component: FiltradoUsuarioTipoUsuarioComponent},
      {path: 'mantenimiento-usuario', component: MantenimientoUsuarioComponent}


    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
