import { Country } from '../models/country.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5062/Country/List';

  getList(): Observable<Country[]> {
    return this.http.get<Country[]>(this.apiUrl);
  }
}