import { Component, Input } from "@angular/core";


@Component({
  selector: 'app-back',
  templateUrl: './back.component.html',
  styleUrls: [
    './back.component.css'
  ]
})
export class BackComponent {
  @Input()
  public header?: string;

  @Input()
  public backRouter?: string[];

  @Input()
  public backRouterText?: string;

}
