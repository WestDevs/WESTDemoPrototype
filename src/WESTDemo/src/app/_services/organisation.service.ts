import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Organisation } from '../_models/Organisation';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class OrganisationService {
  private baseUrl: string = environment.baseUrl + 'api/';

  constructor(private http: HttpClient) {}

  public addOrganisation(organisation: Organisation) {
    return this.http.post(this.baseUrl + 'organisation', organisation);
  }

  public updateOrganisation(id: number, organisation: Organisation) {
    return this.http.put(this.baseUrl + 'organisation/' + id, organisation);
  }

  public getOrganisation(): Observable<Organisation[]> {
    return this.http.get<Organisation[]>(this.baseUrl + `organisation`);
  }

  public deleteOrganisation(id: number) {
    return this.http.delete(this.baseUrl + 'organisation/' + id);
  }

  public getOrganisationById(id): Observable<Organisation> {
    return this.http.get<Organisation>(this.baseUrl + 'organisation/' + id);
  }

  //confirm service name
  public searchOrganisation(searchedValue: string): Observable<Organisation[]> {
    return this.http.get<Organisation[]>(`${this.baseUrl}organisation/search/${name}`);
  }
}
