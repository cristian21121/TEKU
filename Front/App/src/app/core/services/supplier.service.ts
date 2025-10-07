import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Supplier } from '../models/supplier.model';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {
  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5062/Supplier';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  getSuppliers(): Observable<Supplier[]> {
    return this.http.get<Supplier[]>(`${this.apiUrl}/List`);
  }

  getSupplierById(id: number): Observable<Supplier> {
    return this.http.get<Supplier>(`${this.apiUrl}/${id}`);
  }

  createSupplier(supplier: Supplier): Observable<Supplier> {
    return this.http.post<Supplier>(this.apiUrl, supplier, this.httpOptions);
  }

  updateSupplier(supplier: Supplier): Observable<void> {
    return this.http.put<void>(this.apiUrl, supplier, this.httpOptions);
  }

  deleteSupplier(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}