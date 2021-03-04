import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Group } from '../_models/Group';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class GroupService {
    private baseUrl: string = environment.baseUrl + 'api/';

    constructor(private http: HttpClient) { }

    public addGroup(group: Group) {
        return this.http.post(this.baseUrl + 'group', group);
    }

    public updateGroup(id: number, group: Group) {
        return this.http.put(this.baseUrl + 'group/' + id, group);
    }

    public getGroup(): Observable<Group[]> {
        return this.http.get<Group[]>(this.baseUrl + `group`);
    }

    public deleteGroup(id: number) {
        return this.http.delete(this.baseUrl + 'group/' + id);
    }

    public getGroupById(id): Observable<Group> {
        return this.http.get<Group>(this.baseUrl + 'group/' + id);
    }    

    //confirm service name
    public searchGroup(searchedValue: string): Observable<Group[]> {
        return this.http.get<Group[]>(`${this.baseUrl}group/search-book-with-category/${searchedValue}`);
    }
}