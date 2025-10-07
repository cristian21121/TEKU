import { CommonModule } from '@angular/common';
import { Component, inject, ViewChild } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormField, MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { SupplierCreateComponent } from '../supplier-create.component/supplier-create.component';

import { SupplierService } from '../../core/services/supplier.service';

import { Country } from '../../core/models/country.model';
import { UISupplier } from '../../core/models/supplier.model';

@Component({
  selector: 'app-supplier.component',
  imports: [
    CommonModule,
    MatButtonModule,
    MatDialogModule,
    MatExpansionModule,
    MatFormField,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatLabel,
    MatPaginator,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
  ],
  templateUrl: './supplier.component.html',
  styleUrl: './supplier.component.css'
})
export class SupplierComponent {
  private supplierService = inject(SupplierService);

  suppliers: UISupplier[] = [];

  displayedColumns: string[] = ['nombre', 'nit', 'correo', 'servicios', 'campos', 'acciones'];
  dataSource = new MatTableDataSource<UISupplier>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
    this.loadSuppliers();
  }

  loadSuppliers() {
    this.supplierService.getSuppliers().subscribe({
      next: (data) => {
        this.suppliers = data.map(s => ({ ...s, expanded: false }));
        this.suppliers = this.suppliers.sort((a, b) => b.id - a.id);
        this.dataSource.data = this.suppliers
      },
      error: (err) => console.error('Error cargando proveedores:', err),
    });
  }

  getCountriesName(countries: Country[]): string {
    return countries.map(c => c.name).join(', ')
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  showModalCreateSupplier(): void {
    const dialogRef = this.dialog.open(SupplierCreateComponent, {
      width: '2000px',
      data: { title: 'Nuevo proveedor' }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('El modal se cerró con:', result);

      if (result === 'created') {
        this.loadSuppliers();
      }
    });
  }

  editSupplier(supplier: any): void {
    const dialogRef = this.dialog.open(SupplierCreateComponent, {
      width: '90%',
      height: '90%',
      data: supplier,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadSuppliers();
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}