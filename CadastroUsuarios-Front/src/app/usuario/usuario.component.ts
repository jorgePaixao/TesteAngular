import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService, BsDatepickerModule } from 'ngx-bootstrap';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { defineLocale, BsLocaleService, ptBrLocale } from 'ngx-bootstrap';
import { UsuarioService } from '../servicos/usuario.service';
import { Usuario } from '../modelos/Usuario';
import { template } from '@angular/core/src/render3';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {


  usuarios: Usuario[];
  usuario: Usuario;
  modalRef: BsModalRef;
  registerForm: FormGroup;
  modoSalvar: string;
  bodyDeletarUsuario = '';
  ErroApi = '';
  today: Date;

  Escolaridades = { 
    'Infantil': 1,
    'Fundamental': 2,
    'Medio': 3,
    'Superior': 4
   }



  constructor(private usuarioServico: UsuarioService, private modalService: BsModalService,
    private localeService: BsLocaleService) {
    this.localeService.use('pt-br');
  }

  ngOnInit() {
    this.validation();
    this.getUsuarios();
  }

  excluirUsuario(_usuario: Usuario, template: any) {
    this.openModal(template);
    this.usuario = _usuario;
    this.bodyDeletarUsuario = `Tem certeza que deseja excluir o usuário: ${_usuario.nome} , código: ${_usuario.usuarioId}`
  }


  editarUsuario(_usuario: Usuario, template: any) {
    this.modoSalvar = "put";
    this.openModal(template);
    this.usuario = _usuario;
    this.registerForm.patchValue(this.usuario);
    this.getSelected(this.usuario.escolaridade);
    
  }

  objectKeys = Object.keys;

  getSelected(valor:number){
    for(const key in this.Escolaridades){
      if(this.Escolaridades[key] === valor) return key;
    }
  }
  
  selectEscolaridade(evt){
    this.getEscolaridadeType(evt.target.value);
  }
  
  getEscolaridadeType(country: any) {
    for (let element in this.Escolaridades) {
      if (element !== country) {
        this.Escolaridades[element] = false;
      } else {
        this.Escolaridades[element] = true;
      }
    }
  }

  novoUsuario(template: any) {
    this.modoSalvar = "post";
    this.openModal(template);
  }

  openModal(template: any) {
    this.registerForm.reset();
    this.ErroApi = '';
    template.show();
  }

  validation() {
    this.registerForm = new FormGroup({
      nome: new FormControl('', Validators.required),
      sobrenome: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      dataNascimento: new FormControl('', Validators.required),
      escolaridade: new FormControl('', Validators.required)
    });
  }

  confirmeDelete(template: any) {
    this.usuarioServico.deleteUsuario(this.usuario.usuarioId).subscribe(
      () => {
        template.hide();
        this.getUsuarios();
      },
      error => {
        console.log(error);
      }
    );
  }

  salvarAlteracao(template: any) {

    if (this.registerForm.valid) {

      if (this.modoSalvar === "post") {
        this.usuario = Object.assign({}, this.registerForm.value);
        this.usuarioServico.postUsuario(this.usuario).subscribe(
          (UsuarioCriado: Usuario) => {
            console.log(UsuarioCriado);
            template.hide();
            this.getUsuarios();
          }, error => {
            this.ErroApi = error.error;            
            console.log(error);
          }
        );
      }
      else {
        this.usuario = Object.assign({ usuarioId: this.usuario.usuarioId }, this.registerForm.value);
        this.usuarioServico.putUsuario(this.usuario).subscribe(
          (UsuarioCriado: Usuario) => {
            console.log(UsuarioCriado);
            template.hide();
            this.getUsuarios();
          }, error => {
            console.log(error);
          }
        );
      }
    }
  }
  getUsuarios() {
    this.usuarioServico.getTodosUsuarios().subscribe(
      (_usuarios: Usuario[]) => {
        this.usuarios = _usuarios
        console.log(_usuarios);
      }
      ,
      error => { console.log(error) }
    );
  }

}


