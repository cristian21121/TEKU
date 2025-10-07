import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, MinLengthValidator, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatOption, MatSelect } from '@angular/material/select';

import { CountryService } from '../../core/services/country.service';

import { Country } from '../../core/models/country.model';
import { SupplierService } from '../../core/services/supplier.service';

@Component({
  selector: 'app-supplier-create.component',
  imports: [
    CommonModule,
    CommonModule,
    MatButtonModule,
    MatButtonModule,
    MatCardModule,
    MatDialogModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatOption,
    MatSelect,
    ReactiveFormsModule,
  ],
  templateUrl: './supplier-create.component.html',
  styleUrl: './supplier-create.component.css'
})
export class SupplierCreateComponent implements OnInit {
  countries: Country[] = [];

  supplierForm: FormGroup;

  constructor(
    private supplierService: SupplierService,
    private countryService: CountryService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<SupplierCreateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    this.supplierForm = this.fb.group({
      id: [0],
      nit: [0, [Validators.required, Validators.pattern(/^\d{9,}$/)]],
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      services: this.fb.array([]),
      customFields: this.fb.array([])
    });
  }

  get services() {
    return this.supplierForm.get('services') as FormArray;
  }

  get customFields() {
    return this.supplierForm.get('customFields') as FormArray;
  }

  ngOnInit(): void {
    this.getCountries();

    if (this.data) {
      this.loadSupplierData(this.data);
    }
  }

  getCountries() {
    return this.countryService.getList().subscribe({
      next: (res) => this.countries = res
    })
  }

  loadSupplierData(supplier: any): void {
    this.supplierForm.patchValue({
      id: supplier.id,
      nit: supplier.nit,
      name: supplier.name,
      email: supplier.email,
    });

    supplier.services?.forEach((srv: any) => {
      const srvGroup = this.fb.group({
        id: [srv.id],
        supplierId: [srv.supplierId],
        name: [srv.name, Validators.required],
        hourValue: [srv.hourValue, Validators.required],
        countries: this.fb.array([]),
      });

      srv.countries?.forEach((c: any) => {
        const countryGroup = this.fb.group({
          code: [c.code],
          name: [c.name],
        });
        (srvGroup.get('countries') as FormArray).push(countryGroup);
      });

      this.services.push(srvGroup);
    });

    supplier.customFields?.forEach((f: any) => {
      const fieldGroup = this.fb.group({
        id: [f.id],
        supplierId: [f.supplierId],
        name: [f.name, Validators.required],
        value: [f.value, Validators.required],
      });
      this.customFields.push(fieldGroup);
    });
  }

  getCountriesSupplier(serviceIndex: number) {
    return this.services.at(serviceIndex).get('countries') as FormArray;
  }

  addService() {
    const serviceGroup = this.fb.group({
      id: [0],
      supplierId: [0],
      name: ['', Validators.required],
      hourValue: [0, Validators.required],
      countries: this.fb.array([])
    });
    this.services.push(serviceGroup);
  }

  removeService(index: number) {
    this.services.removeAt(index);
  }

  addCountry(serviceIndex: number) {
    const countries = this.services.at(serviceIndex).get('countries') as FormArray;
    const countryGroup = this.fb.group({
      code: [''],
      name: ['']
    });
    countries.push(countryGroup);
  }

  removeCountry(serviceIndex: number, countryIndex: number) {
    const countries = this.services.at(serviceIndex).get('countries') as FormArray;
    countries.removeAt(countryIndex);
  }

  addCustomField() {
    const fieldGroup = this.fb.group({
      id: [0],
      supplierId: [0],
      name: ['', Validators.required],
      value: ['', Validators.required]
    });
    this.customFields.push(fieldGroup);
  }

  removeCustomField(index: number) {
    this.customFields.removeAt(index);
  }

  onSubmit(): void {
    if (this.supplierForm.invalid) return;

    const supplierData = this.supplierForm.value;

    if (supplierData.id && supplierData.id !== 0) {
      this.supplierService.updateSupplier(supplierData).subscribe({
        next: () => window.location.reload()
      });
    } else {
      this.supplierService.createSupplier(supplierData).subscribe({
        next: () => window.location.reload()
      });
    }
  }

  close(): void {
    this.dialogRef.close('Modal cerrado');
  }
}