import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
  selector: 'app-loading-spinner',
  templateUrl: './loading-spinner.component.html',
  styleUrls: [
    './loading-spinner.component.css'
  ]
})
export class LoadingSpinnerComponent {
  @Input()
  public message?: string;

  @Input()
  public canCancel: boolean = false;

  @Output()
  public cancel: EventEmitter<void> = new EventEmitter();

  public onCancel(): void {
    this.cancel.emit();
  }
}
