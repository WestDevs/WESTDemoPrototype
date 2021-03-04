import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from '../_models/Course';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class CourseService {
    private baseUrl: string = environment.baseUrl + 'api/';

    constructor(private http: HttpClient) { }

    public addCourse(course: Course) {
        return this.http.post(this.baseUrl + 'course', course);
    }

    public updateCourse(id: number, course: Course) {
        return this.http.put(this.baseUrl + 'course/' + id, course);
    }

    public getCourse(): Observable<Course[]> {
        return this.http.get<Course[]>(this.baseUrl + `course`);
    }

    public deleteCourse(id: number) {
        return this.http.delete(this.baseUrl + 'course/' + id);
    }

    public getCourseById(id): Observable<Course> {
        return this.http.get<Course>(this.baseUrl + 'course/' + id);
    }    

    //confirm service name
    // public searchCourse(searchedValue: string): Observable<Course[]> {
    //     return this.http.get<Course[]>(`${this.baseUrl}course/search-course/${searchedValue}`);
    // }
}