import { Service } from './service.model';
import { CustomField } from './custom-field.model';

export interface Supplier {
  id: number;
  nit: number;
  name: string;
  email: string;
  services: Service[];
  customFields: CustomField[];
}

export interface UISupplier extends Supplier {
  expanded?: boolean;
}
