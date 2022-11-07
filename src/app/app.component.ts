import {Component, OnInit} from '@angular/core';
import { Item } from './item.model';
import { ItemService } from './item.service';
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {DialogElementsExampleDialog} from './dialog';
import { DialogComponent } from './dialog/dialog.component';
import { Router } from '@angular/router';
const ELEMENT_DATA: Item[] = [
  {id: 1, cod: 'ART0001', nameArt: 'Detergente', descArt: 'Descripción', cant: 3},
  {id: 2, cod: 'ART0002', nameArt: 'Comida enlatada', descArt: 'Descripción', cant: 4},
  {id: 3, cod: 'ART0003', nameArt: 'Jabón', descArt: 'Descripción', cant: 5},
  {id: 4, cod: 'ART0004', nameArt: 'Shampoo', descArt: 'Descripción', cant: 1},
];
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  displayedColumns: string[] = ['id', 'cod', 'nameArt', 'descArt', 'cant'];
  dataSource = ELEMENT_DATA;
  items: Item[]= [];

  constructor(
    private itemService: ItemService,
    private dialog: MatDialog, public router:Router
  ) { }

  openDialog(opcion: string) {
    
    this.dialog.open(DialogComponent,{data: opcion});
    
  }

  ngOnInit(): void {
    this.itemService.getItems().subscribe((result) => {
      this.items = result;
    });
  }
  
}
