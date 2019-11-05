import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { NavComponent } from './nav/nav.component';
import { ModalModule ,BsDropdownModule, BsDatepickerModule } from 'ngx-bootstrap';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DateFormatPipePipe } from './help/DateFormatPipe.pipe';

@NgModule({
   declarations: [
      AppComponent,
      UsuarioComponent,
      NavComponent,
      DateFormatPipePipe
   ],
   imports: [
      BrowserModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      ModalModule.forRoot(),
      BsDatepickerModule.forRoot(),
      AppRoutingModule,
      HttpClientModule,
      ReactiveFormsModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
