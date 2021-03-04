import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usertype } from '../_models/Usertype';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})

export class UsertypeService {
  private baseUrl: string = environment.baseUrl + 'api/';

  constructor(private http: HttpClient) {}

  public addUsertype(usertype: Usertype) {
    return this.http.post(this.baseUrl + 'usertype', usertype);
  }

  public updateUsertype(id: number, usertype: Usertype) {
    return this.http.put(this.baseUrl + 'usertype/' + id, usertype);
  }

  public getUsertype(): Observable<Usertype[]> {
    return this.http.get<Usertype[]>(this.baseUrl + `usertype`);
  }

  public deleteUsertype(id: number) {
    return this.http.delete(this.baseUrl + 'usertype/' + id);
  }

  public getUsertypeById(id): Observable<Usertype> {
    return this.http.get<Usertype>(this.baseUrl + 'usertype/' + id);
  }

  //confirm service name
  public searchUsertype(searchedValue: string): Observable<Usertype[]> {
    return this.http.get<Usertype[]>(
      `${this.baseUrl}usertype/search/${name}`
    );
  }
}
