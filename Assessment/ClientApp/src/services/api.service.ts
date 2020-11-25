
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Person } from '../app/home/home.component';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ApiService {

  baseURL: string = "http://localhost:51298/";

  constructor(private http: HttpClient) {
  }

  getPeople(): Observable<Person[]> {
    console.log('getPeople ' + this.baseURL + 'api/Person')
    return this.http.get<Person[]>(this.baseURL + 'api/Person')
  }

  addPerson(person: Person): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(person);
    console.log(body)
    return this.http.post(this.baseURL + 'api/Person', body, { 'headers': headers })
  }

}
