import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Centre } from '../_models/Centre';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class CentreService {
    private baseUrl: string = environment.baseUrl + 'api/';

    constructor(private http: HttpClient) { }

    public addCentre(centre: Centre) {
        return this.http.post(this.baseUrl + 'centre', centre);
    }

    public updateCentre(id: number, centre: Centre) {
        return this.http.put(this.baseUrl + 'centre/' + id, centre);
    }

    public getCentre(): Observable<Centre[]> {
        return this.http.get<Centre[]>(this.baseUrl + `centre`);
    }

    public deleteCentre(id: number) {
        return this.http.delete(this.baseUrl + 'centre/' + id);
    }

    public getCentreById(id): Observable<Centre> {
        return this.http.get<Centre>(this.baseUrl + 'centre/' + id);
    }    

    //confirm service name
//     public searchCentre(searchedValue: string): Observable<Centre[]> {
//         return this.http.get<Centre[]>(`${this.baseUrl}centre/search-centre/${searchedValue}`);
//     }
}