using Microsoft.EntityFrameworkCore;
public class facturas{
    
    public int id {get; set;}
    public string RNC {get; set;}

    public DateTime Date {get; set;}

    public string NombreFat{get; set;}

    public decimal total{get; set;}
    
}


public class facturasContext : DbContext{


    public DbSet<facturas> Facturas {get; set;}
    public facturasContext(){

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=facturas.db");
    }

}