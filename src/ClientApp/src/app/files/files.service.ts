import {Injectable} from "@angular/core";

export interface FileRecord {
  name: string;
  sizeInBytes: number;
  extension: string;
  date: string;
  isDirectory: boolean;
}

@Injectable()
export class FilesService {
    public getFilesByDirectory(directory: string) : FileRecord[] {
        return [
          {
            name: "file1",
            sizeInBytes: 100,
            extension: "txt",
            date: "2019-01-01",
            isDirectory: false
          },
          {
            name: "file2",
            sizeInBytes: 200,
            extension: "txt",
            date: "2019-01-01",
            isDirectory: false,
          },
          {
            name: "dir1",
            sizeInBytes: 0,
            extension: "",
            date: "2019-01-01",
            isDirectory: true,
          }
        ];
    }
}
