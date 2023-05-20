import {Component, EventEmitter, Output} from "@angular/core";

@Component({
    selector: 'submit-app-button',
    template: `
      <div class="form-group">
        <div class="text-center">
          <div class="row justify-content-center">
            <div class="col-10 col-md-6 col-xl-4">
              <app-button type="submit" class="mt-5 mb-3 w-100" (click)="click.emit($event)">
                <ng-content></ng-content>
              </app-button>
            </div>
          </div>
        </div>
      </div>
    `,
    styles: [``],
})
export class SubmitAppButtonComponent {
  @Output() click = new EventEmitter<MouseEvent>();
}
