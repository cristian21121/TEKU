import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationRequest } from '../models/authentication-request.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  
  private apiUrl = 'http://localhost:5062/Authentication';
  
  login(credentials: AuthenticationRequest): Observable<boolean> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<boolean>(this.apiUrl, credentials, { headers });
  }
}