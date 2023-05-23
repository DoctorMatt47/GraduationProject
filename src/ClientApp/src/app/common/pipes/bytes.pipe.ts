import {Pipe, PipeTransform} from "@angular/core";

@Pipe({
  name: 'bytes'
})
export class BytesPipe implements PipeTransform {
  transform(value: number): string {
    if (value < 1024) return value + " B";
    if (value < 1024 * 1024) return Math.round(value * 10 / 1024) / 10 + " KB";
    return Math.round(value * 10 / 1024 / 1024) / 10 + " MB";
  }
}
