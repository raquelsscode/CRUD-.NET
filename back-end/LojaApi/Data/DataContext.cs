using Microsoft.EntityFrameworkCore;
using LojaAPI.Models;

namespace LojaAPI.Data{
    
    public class DataContext: DbContext{
        public DataContext(DbContextOptions<DataContext> options): base(options){

        }

        public DbSet<Categoria> Categorias {get;set;}
    }
}