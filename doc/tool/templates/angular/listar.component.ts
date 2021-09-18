import { Component, OnInit } from '@angular/core';

import { LocalStorageUtils } from 'src/app/utils/localstorage';
import { ToastAppService } from 'src/app/services/toastapp.service';

 

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css']
})
export class ListarComponent implements OnInit {

  public lstModels: #NomeModel#[];
  public storage = new LocalStorageUtils();
  public componentRoute : string  = '/#nomemodel#es';

  constructor(
    private toastr: ToastAppService,
    private service: #NomeModel#Service<#NomeModel#>
    ) { }

  ngOnInit(): void {
    this.listar();
  }
  
  listar(): void {
    this.service.listarTodos()
      .subscribe(
        data => this.lstModels = data,
        falha => this.toastr.error(falha)
      )
  }
 
  excluir(model: #NomeModel#): void {    

    let mens: string[] = ['Excluído com sucesso!'];

    this.service.excluir(model.id)
      .subscribe(
        () => { this.toastr.success(mens); this.listar(); },
        error => this.toastr.error(error)
      );
  }

}
