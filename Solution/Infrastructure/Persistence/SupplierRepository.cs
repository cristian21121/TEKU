using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SupplierRepository : ISupplierRepository
    {
        private AppDbContext dbContext;

        public SupplierRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Supplier supplier)
        {
            //Obtener todos los códigos de país
            List<String> allCodes = supplier.Services
                .SelectMany(s => s.Countries)
                .Select(c => c.Code)
                .Distinct()
                .ToList();

            //Cargar los países existentes de la BD
            Dictionary<String, Country> existingCountries = dbContext.COUNTRY
                .Where(c => allCodes.Contains(c.Code))
                .ToDictionary(c => c.Code, c => c);

            //Reemplazar todas las instancias por trackeadas
            foreach (Service service in supplier.Services)
            {
                List<Country> updatedCountries = new();

                foreach (Country country in service.Countries)
                {
                    if (existingCountries.TryGetValue(country.Code, out Country? existing))
                    {
                        //Reutilizar la instancia existente
                        updatedCountries.Add(existing);
                    }
                    else
                    {
                        //País nuevo, agregarlo al diccionario para seguimiento
                        existingCountries[country.Code] = country;
                        updatedCountries.Add(country);
                    }
                }

                service.Countries = updatedCountries;
            }

            //Agregar el supplier completo
            dbContext.SUPPLIER.Add(supplier);
            dbContext.SaveChanges();
        }


        public Supplier? Get(int id)
        {
            return dbContext.SUPPLIER.AsNoTracking().FirstOrDefault(s => s.Id == id);
        }

        public List<Supplier> GetList()
        {
            return dbContext.SUPPLIER
                .AsNoTracking()
                .Include(s => s.CustomFields)
                .Include(s => s.Services).ThenInclude(s => s.Countries).ToList();
        }

        public void Update(Supplier supplier)
        {
            //Cargar el proveedor existente desde la base de datos incluyendo sus servicios y los países asociados
            Supplier existingSupplier = dbContext.SUPPLIER
                .Include(s => s.Services)
                    .ThenInclude(sv => sv.Countries)
                .FirstOrDefault(s => s.Id == supplier.Id)!;

            //Actualizar las propiedades del proveedor
            existingSupplier.Nit = supplier.Nit;
            existingSupplier.Name = supplier.Name;
            existingSupplier.Email = supplier.Email;
            existingSupplier.CustomFields = supplier.CustomFields;

            //Obtener todos los códigos de país de los servicios del proveedor que se quieren actualizar
            List<String> allCodes = supplier.Services
                .SelectMany(s => s.Countries) //Aplanar la lista de países de todos los servicios
                .Select(c => c.Code) //Tomar solo el código de cada país
                .Distinct() //Eliminar códigos duplicados
                .ToList();

            //Crear un diccionario con los países existentes en la base de datos, usando el código como clave
            Dictionary<String, Country> trackedCountries = dbContext.COUNTRY
                .Where(c => allCodes.Contains(c.Code)) //Solo los países que aparecen en los servicios
                .ToDictionary(c => c.Code, c => c); //Clave = código, valor = entidad Country

            //Recorrer todos los servicios enviados en la actualización
            foreach (Service service in supplier.Services)
            {
                //Buscar si el servicio ya existe en el proveedor existente
                Service? existingService = existingSupplier.Services.FirstOrDefault(s => s.Id == service.Id);

                if (existingService != null)
                {
                    //Si el servicio existe, actualizar sus propiedades simples
                    existingService.Name = service.Name;
                    existingService.HourValue = service.HourValue;

                    //Sincronizar los países del servicio
                    //Identificar los países que ya no están en la nueva lista y eliminarlos
                    List<Country> toRemove = existingService.Countries
                        .Where(c => !service.Countries.Any(sc => sc.Code == c.Code))
                        .ToList();

                    foreach (Country c in toRemove)
                        existingService.Countries.Remove(c);

                    //Agregar los nuevos países que no estaban previamente asociados
                    foreach (Country c in service.Countries)
                    {
                        if (!existingService.Countries.Any(ec => ec.Code == c.Code))
                        {
                            //Reutilizar la instancia existente del país si ya está trackeada
                            if (!trackedCountries.TryGetValue(c.Code, out Country? country))
                            {
                                country = c; //Si no existe, usar la nueva instancia
                                trackedCountries[c.Code] = country; //Agregar al diccionario para seguimiento
                            }
                            existingService.Countries.Add(country); //Asociar el país al servicio
                        }
                    }
                }
                else
                {
                    //Si el servicio es nuevo, preparar la lista de países usando instancias trackeadas
                    List<Country> newCountries = new();

                    foreach (Country c in service.Countries)
                    {
                        if (!trackedCountries.TryGetValue(c.Code, out Country? country))
                        {
                            country = c;
                            trackedCountries[c.Code] = country;
                        }
                        newCountries.Add(country);
                    }

                    service.Countries = newCountries; //Asignar la lista de países al servicio
                    existingSupplier.Services.Add(service); //Agregar el servicio nuevo al proveedor
                }
            }

            //Guardar todos los cambios en la base de datos
            dbContext.SaveChanges();
        }
    }
}