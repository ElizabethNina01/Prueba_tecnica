
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Validators, FormGroup, FormBuilder, FormControl, FormGroupDirective,
   NgForm} from '@angular/forms';
import { Item } from '../item.model';
import { ItemService } from '../item.service';


@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
})
export class DialogComponent implements OnInit {
  opcion= '';
  itemModel: Item = new Item();
  id=0;
  cod='';
  nameArt='';
  descArt='';
  cant=0;
  constructor(@Inject(MAT_DIALOG_DATA) public data: string, 
    private matDialogRef: MatDialogRef<DialogComponent>, private service: ItemService) {

    this.opcion=data; 
    
  }

  ngOnInit(): void {
    
  }
  enviar(){
    
    switch(this.opcion){
      case 'Insertar':{
        this.itemModel.cod = this.cod;
        this.itemModel.nameArt = this.nameArt;
        this.itemModel.descArt = this.descArt;
        this.itemModel.cant = this.cant;
        this.service.postItem(this.itemModel).subscribe();
        this.reloadPage();
      };break;

      case 'Modificar':{
        this.itemModel.cod = this.cod;
        this.itemModel.nameArt = this.nameArt;
        this.itemModel.descArt = this.descArt;
        this.itemModel.cant = this.cant;
        this.service.updateItembyId(this.id,this.itemModel).subscribe();
        this.reloadPage();
      };break;

      case 'Eliminar':{
        this.service.deleteItem(this.id).subscribe()
        this.reloadPage();
      };break;
    }
    this.matDialogRef.close();

  }
  reloadPage(){
    window.location.reload()
  }
}
