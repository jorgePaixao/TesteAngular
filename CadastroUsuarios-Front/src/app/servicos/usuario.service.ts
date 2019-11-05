import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../modelos/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }

  baseurl = "http://localhost:5000/api/usuario/";

  getTodosUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.baseurl);
  }

  getUsuario(id: number): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.baseurl}${id}`);
  }

  postUsuario(usuario: Usuario) {
    return this.http.post<Usuario>(this.baseurl, usuario);
  }

  putUsuario(usuario: Usuario) {
    return this.http.put<Usuario>(`${this.baseurl}${usuario.usuarioId}`, usuario);    
  }

  deleteUsuario(id: number) {
    return this.http.delete(`${this.baseurl}${id}`);
  }
}


