import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Learner } from '../_models/Learner';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class LearnerService {
    private baseUrl: string = environment.baseUrl + 'api/';

    constructor(private http: HttpClient) { }

    public addLearner(learner: Learner) {
        return this.http.post(this.baseUrl + 'learner', learner);
    }

    public updateLearner(id: number, learner: Learner) {
        return this.http.put(this.baseUrl + 'learner/' + id, learner);
    }

    public getLearner(): Observable<Learner[]> {
        return this.http.get<Learner[]>(this.baseUrl + `learner`);
    }

    public deleteLearner(id: number) {
        return this.http.delete(this.baseUrl + 'learner/' + id);
    }

    public getLearnerById(id): Observable<Learner> {
        return this.http.get<Learner>(this.baseUrl + 'learner/' + id);
    }

    public searchLearner(searchedValue: string): Observable<Learner[]> {
        return this.http.get<Learner[]>(`${this.baseUrl}learner/search/${searchedValue}`);
    }
}