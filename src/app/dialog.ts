import { Component, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
    selector: 'dialog',
    templateUrl: 'dialog.html',
  })


export class DialogElementsExampleDialog {
    message: string = "Are you sure?"
  confirmButtonText = "Yes"
  cancelButtonText = "Cancel"

  constructor(
    @Inject(MAT_DIALOG_DATA) private data: any,
    private dialogRef: MatDialogRef<DialogElementsExampleDialog>
    ) 
    {
      if(data){
        this.message = data.message || this.message;
        if (data.buttonText) {
        this.confirmButtonText = data.buttonText.ok || this.confirmButtonText;
        this.cancelButtonText = data.buttonText.cancel || this.cancelButtonText;
        }
      }
  }

  onConfirmClick(): void {
    this.dialogRef.close(true);
  }
  
}