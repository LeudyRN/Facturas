

bool continuar = true;

while(continuar){
    
    Console.Clear();
    Console.WriteLine(@"
    
    -----------FACTURAS-----------
    
    1. AGREGAR FACTURAS
    2. MOSTRAR FACTURAS
    3. MODIFICAR FACTURAS
    4. ELIMINAR FACTURAS
    5. EXPORTAR FACTURA
    x. SALIR

    -----------FACTURS-----------

    ");
   

    string opcion = Console.ReadLine();
    switch(opcion.ToLower()){

        case "1":
        Console.Clear();
        Manejador.agregarFactura();
        break;

        case "2":
        Console.Clear();
        Manejador.mostrarFacturas();
        Console.ReadKey();
        break;

        case "3":
        Console.Clear();
        Manejador.modificarFacturas();
        Console.ReadKey();
        break;

        case "4":
        Console.Clear();
        Manejador.eliminarFacturas();
        break;

        case "5":
        Console.Clear();

        facturas per = new facturas();
        facturasContext contexto = new facturasContext();

        while(per.id < 1){
            Console.WriteLine("Seleccione la factura a Exportar\n");
            Manejador.mostrarFacturas();

            var tmp = Manejador.input("\nid: ");
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
        Manejador.EXPORTAR(per);
        break;

        case "x":
        continuar = false;
        break;
        default:
        Console.WriteLine("Opcion no valida");
        break;
    }
}

