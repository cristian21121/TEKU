import { Country } from './country.model';

export interface Service {
  id: number;
  supplierId: number;
  name: string;
  hourValue: number;
  countries: Country[];
}