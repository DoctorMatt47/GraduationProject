import {Component, EventEmitter, Input, Output} from "@angular/core";

@Component({
  selector: 'app-input',
  template: `
    <div class="form-group">
      <div class="row justify-content-center">
        <div class="col-10 col-md-6 col-xl-4">
          <label class="mt-3 mb-1 w-100">
            <ng-content></ng-content>
            <input type="text" [placeholder]="placeholder" class="form-control"
                   (change)="change.emit($event)" required>
          </label>
        </div>
      </div>
    </div>
  `,
})
export class AppInputComponent {
  @Input() placeholder: string = "";
  @Output() change = new EventEmitter<Event>();
}
