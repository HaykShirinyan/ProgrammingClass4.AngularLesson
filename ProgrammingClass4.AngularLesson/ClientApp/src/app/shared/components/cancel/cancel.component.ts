import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
  selector: 'app-cancel',
  templateUrl: './cancel.component.html',
})
export class CancelComponent {
  @Input()
  public message?: string;

  @Input()
  public canCancel: boolean = false;

  @Output()
  public cancel: EventEmitter<void> = new EventEmitter();

  public onCancel(): void { 
    this.cancel.emit()
  }
}
