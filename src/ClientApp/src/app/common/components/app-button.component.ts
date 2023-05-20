import {Component, EventEmitter, Input, Output} from "@angular/core";

@Component({
    selector: 'app-button',
    template: `
      <button [type]="type" class="btn btn-secondary w-100" (click)="click.emit($event)">
        <ng-content></ng-content>
      </button>
    `,
    styles: [``],
})
export class AppButtonComponent {
  @Input() type: "button" | "submit" | "reset" = "button";
  @Output() click = new EventEmitter<MouseEvent>();
}
