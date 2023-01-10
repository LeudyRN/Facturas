class Manejador{

   public static string input(string msg){
       Console.Write(msg);
       return Console.ReadLine()??"";
   }

   public static string confirmar(string campo, string valor){
       string final = valor;

       var tmp_nuevo = input($@"El nombre actual de {campo} es: {valor}
       
       Escriba el nuevo valor o Presione Enter para salir
       ");

       if(tmp_nuevo != ""){
           final = tmp_nuevo;
       }

       return final;
   }



public static void agregarFactura()
{
    Console.Clear();

    Console.WriteLine("---AGREGANDO FACTURAS---\n");

    var p = new facturas();
    
    Console.Write("INTRODUCIR EL RNC O ID DE LA FACTURA: ");
    p.RNC = Console.ReadLine();
    
    // Utiliza ToShortDateString en lugar de ToString con el formato "dd/MM/yyyy"
    string fecha = p.Date.ToShortDateString();
    Console.Write("INTRODUCIR FECHA DE LA FACTURA (dd/MM/yyyy): ");
    fecha = Console.ReadLine();

    Console.Write("INTRODUCIR NOMBRE DE LA EMPRESA: ");
    p.NombreFat = Console.ReadLine();

    string monto = p.total.ToString("0.00");
    Console.Write("INTRODUCIR EL TOTAL PAGADO DE LA FACTURA: ");
    monto = Console.ReadLine();
    

    DateTime fechaValida;

    if (DateTime.TryParse(fecha, out fechaValida))
    {
       p.Date = fechaValida;
    }
    else
    {
        Console.WriteLine("La fecha introducida no es válida. Debe tener el formato dd/MM/yyyy");
        return;
    }

    decimal montoValido;
    if (decimal.TryParse(monto, out montoValido))
    {
        p.total = montoValido;
    }
    else
    {
        Console.WriteLine("El monto introducido no es válido. Debe ser un número decimal con dos decimales.");
        return;
    }
    
    using (facturasContext context = new facturasContext())
    {
        context.Facturas.Add(p);
        context.SaveChanges();
    }
}


    public static void mostrarFacturas(){

        using (facturasContext context = new facturasContext()){

         var facturas = context.Facturas;
         foreach (facturas p in facturas){
         Console.WriteLine($"{p.id} |{p.RNC} | {p.Date} | {p.NombreFat} | {p.total} |");
            }




    try
    {
        // Realiza la consulta utilizando LINQ
        // Utiliza double en lugar de decimal
        double total = context.Facturas.Sum(f => (double)f.total);
        Console.WriteLine("\nTotal de todas las facturas: " + total.ToString("0.00"));
    }
    catch (Exception ex)
    {
        Console.WriteLine("Se ha producido un error al obtener el total de las facturas: " + ex.Message);
    }
    }
}

    public static void modificarFacturas(){

        Console.Clear();

        facturas fact = new facturas();
        facturasContext context = new facturasContext();

        Console.WriteLine("---MODIFICAR FACTURAS---\n");

        while(fact.id < 1){
        
        Console.WriteLine("Seleccione una factura, si quiere salir pulse enter ");

        mostrarFacturas();

        var tmp = input("id: ");
        var tmp_it = 0;

        if(tmp == "0"){

            return;
        }

        int.TryParse(tmp, out tmp_it);
        var rs = context.Facturas.Where(k=>k.id == tmp_it).ToList();

        if(rs.Count > 0){
            
            fact = rs[0];
        }else {
            Console.WriteLine("---NO SE ENCONTRO LA FACTURA---\n");
        }
   

        }

        string fecha = fact.Date.ToString("dd/MM/yyyy");
        string monto = fact.total.ToString("0.00");

        fact.RNC = confirmar("RNC: ", fact.RNC);
        fecha = confirmar("Fehca: ", fecha);
        fact.NombreFat = confirmar("Nombre de la Empresa: ", fact.NombreFat);
        monto = confirmar("Total pagado: ", monto);
        context.Update(fact);
        context.SaveChanges();

    }

    public static void eliminarFacturas(){

        Console.Clear();
        
        facturas per = new facturas();
        facturasContext contexto = new facturasContext();

        Console.WriteLine("---Eliminar facturas---\n");

        while(per.id < 1){
            Console.WriteLine("Seleccione la factura a Eliminar\n");
            mostrarFacturas();

            var tmp = input("\nid: ");
            var tmp_it = 0;
            if(tmp == "0"){
                return;
            }
            int.TryParse(tmp, out tmp_it);
            var rs = contexto.Facturas.Where(k=>k.id == tmp_it).ToList();
            if(rs.Count > 0){
                per = rs[0];
            }else {
                Console.WriteLine("No se encontro la factura");
            }
        }

    contexto.Remove(per);
    contexto.SaveChanges();
    }



    public static void EXPORTAR(facturas per){

        var plantilla = "";


        StreamReader sr = new StreamReader("facturas.html");

        plantilla = sr.ReadToEnd();
        sr.Close();

        String fecha = per.Date.ToString("dd/MM/yyyy");
        String monto = per.total.ToString("0.00");

       plantilla = plantilla.Replace("RNC#", per.RNC);
       plantilla = plantilla.Replace("FECHA#", fecha);
       plantilla = plantilla.Replace("NOMBRE DE LA EMPRESA#", per.NombreFat);
       plantilla = plantilla.Replace("TOTAL PAGADO#", monto);


       System.IO.File.WriteAllText("fact.html", plantilla);

       var url = "fact.html";
       var psl = new System.Diagnostics.ProcessStartInfo();
       psl.UseShellExecute = true;
       psl.FileName = url;
       System.Diagnostics.Process.Start(psl);

    }
}     