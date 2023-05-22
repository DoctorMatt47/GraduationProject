import {Injectable} from "@angular/core";
import {Observable} from "rxjs";

export interface FileRecord {
  name: string;
  sizeInBytes: number;
  extension: string;
  date: string;
  isDirectory: boolean;
}

@Injectable()
export class FileService {
  private files: FileRecord[] = [
    {
      name: "file1",
      sizeInBytes: 2000000,
      extension: "txt",
      date: "2019-01-01",
      isDirectory: false
    },
    {
      name: "file2",
      sizeInBytes: 20000,
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

  public getFilesByDirectory(directory: string): FileRecord[] {
    return [...this.files];
  }

  public uploadFile(file: any): Observable<FileRecord> {
    console.log(file)
    const newFile: FileRecord = {
      name: file.name,
      sizeInBytes: file.size,
      extension: file.name.split(".").pop(),
      date: new Date().getUTCDate().toString(),
      isDirectory: false,
    };

    this.files.push(newFile);

    return new Observable<FileRecord>(observer => {
      observer.next(newFile);
      observer.complete();
    });
  }

  public uploadFolder(path: string): Observable<FileRecord> {
    const folder = {
      name: path,
      sizeInBytes: 0,
      extension: "",
      date: new Date().toUTCString(),
      isDirectory: true,
    };

    this.files.push(folder)

    return new Observable<FileRecord>(observer => {
      observer.next(folder);
      observer.complete();
    });
  }
}
