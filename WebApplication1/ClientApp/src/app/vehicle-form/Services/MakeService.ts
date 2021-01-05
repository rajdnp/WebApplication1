import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, throwError } from 'rxjs';

@Injectable()
export class VehicleService  {

  constructor(private httpClient: HttpClient) { }

  getMakes(): Observable<Make[]> {
    return this.httpClient.get<Make[]>('https://localhost:44313/api/makes');
  }

  getFeatures(): Observable<Feature[]> {
    return this.httpClient.get<Feature[]>("https://localhost:44313/api/features");
  }
}

export interface Make {
  Id: number;
  Name: string;
  Models: Model[];
}

export interface Model {
  Id: number;
  Name: string;
}

export interface Feature {
  Id: number;
  Name: string;
}
