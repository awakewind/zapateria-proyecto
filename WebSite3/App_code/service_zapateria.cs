using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using zapateria_clases;


[WebService(Namespace = "http://tempuri.org/", Name = "zapateriaws")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]

public class service_zapateria : System.Web.Services.WebService
{

    public service_zapateria()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    //metodos para cargos 

    [WebMethod]
    public int agregarCargo(String nombre, String descripcion, Decimal   salario)
    {
        cargos cargos = new cargos();
        cargos.NomCargo1 = nombre;
        cargos.DescripcionCargo1 = descripcion;
        cargos.Salario1 = salario;
        CargosService dao = new CargoServiceImpl();
        return (int)dao.add(cargos);
    }

    [WebMethod]
    public List<cargos> getAllcargos()
    {
        CargosService dao = new CargoServiceImpl();
        return dao.findAll();
    }

    [WebMethod]
    public cargos gatCargosById(int id_cargos)
    {
        CargosService dao = new CargoServiceImpl();
        return dao.findById(id_cargos);
    }

    [WebMethod]
    public int deleteCargos(int id_cargos)
    {
        cargos cargo = new cargos();
        cargo.Id_cargo = id_cargos;
        CargosService dao = new CargoServiceImpl();
        return (int)dao.remove(cargo);
    }

    [WebMethod]
    public int updateCargos(Int32 id_cargos, String nombre, String descripcion, Decimal  salario)
    {
        cargos cargos = new cargos();
        cargos.Id_cargo = id_cargos;
        cargos.NomCargo1 = nombre;
        cargos.DescripcionCargo1 = descripcion;
        cargos.Salario1 = salario;
        CargosService dao = new CargoServiceImpl();
        return (int)dao.update(cargos);
    }

    //metodos para clientes

    [WebMethod]
    public int agregarCliente(String nombre, String apellido, String telefono, String direccíon)
    {
        clientes cliente = new clientes();
        cliente.NomCliente1 = nombre;
        cliente.ApeCliente1  = apellido;
        cliente.TelCliente1 = telefono;
        cliente.DireccionCliente1 = direccíon;
        ClientesService dao = new ClientesServiceImpl();
        return (int)dao.add(cliente);
    }

    [WebMethod]
    public List<clientes> getAllClientes()
    {
        ClientesService dao = new ClientesServiceImpl();
        return dao.findAll();
    }

    [WebMethod]
    public clientes gatClientesById(int id_clientes)
    {
        ClientesService dao = new ClientesServiceImpl();
        return dao.findById(id_clientes);
    }

    [WebMethod]
    public List<clientes> getClienteByField(string param)
    {
        ClientesService dao = new ClientesServiceImpl();
        return dao.findByField(param);
    }

    [WebMethod]
    public int deleteClientes(int id_clientes)
    {
        clientes cliente = new clientes();
        cliente.Id_cliente = id_clientes;
        ClientesService dao = new ClientesServiceImpl();
        return (int)dao.remove(cliente);
    }

    [WebMethod]
    public int updateClientes(Int32 id_clientes, String nombre, String apellido, String telefono, String direccíon)
    {
        clientes cliente = new clientes();
        cliente.Id_cliente = id_clientes;
        cliente.NomCliente1 = nombre;
        cliente.ApeCliente1  = apellido;
        cliente.TelCliente1 = telefono;
        cliente.DireccionCliente1 = direccíon;
        ClientesService dao = new ClientesServiceImpl();
        return (int)dao.update(cliente);
    }


    //metodos para comisiones

    [WebMethod]
    public int agregarComision(Int32 empleado, Decimal valor, Int32 venta)
    {
        comisiones comision = new comisiones();
        comision.Empleados = empleado;
        comision.ValorComision1 = valor;
        comision.Ventas = venta;
        ComisionesService dao = new ComisionServiceImpl();
        return (int)dao.add(comision);
    }

    [WebMethod]
    public List<comisiones> getAllComisiones ()
    {
        ComisionesService dao = new ComisionServiceImpl();
        return dao.findAll();
    }

    [WebMethod]
    public comisiones  getComisionesById(int id_comision )
    {
        ComisionesService dao = new ComisionServiceImpl();
        return dao.findById(id_comision);
    }

    [WebMethod]
    public int deleteComisiones (int id_comision )
    {
        comisiones comision = new comisiones();
        comision.Id_comision = id_comision;
        ComisionesService dao = new ComisionServiceImpl();
        return (int)dao.remove(comision);
    }

    [WebMethod]
    public int updateComisiones(Int32 id_comision , Int32 empleado, Decimal valor, Int32 venta)
    {
        comisiones comision = new comisiones();
        comision.Id_comision = id_comision;
        comision.Empleados = empleado;
        comision.ValorComision1 = valor;
        comision.Ventas = venta;
        ComisionesService dao = new ComisionServiceImpl();
        return (int)dao.update(comision);
    }

    //metodos para detalles de ventas

    [WebMethod]
    public int agregarDetavent (Int32 ventas , Int32 zapatos , Int32 empleados, Int32 cantidadP , Decimal totalPag)
    {
        detalles_de_venta detavent = new detalles_de_venta();
        detavent.Ventas = ventas;
        detavent.Zapatos = zapatos;
        detavent.Empleados = empleados;
        detavent.CantidadProducto1 = cantidadP;
        detavent.TotalPagar1 = totalPag;
        DetaventService dao = new DetaventServiceImpl();
        return (int)dao.add(detavent);
    }

    [WebMethod]
    public List<detalles_de_venta> getAllDetavent ()
    {
        DetaventService dao = new DetaventServiceImpl();
        return dao.findAll();
    }

    [WebMethod]
    public detalles_de_venta getDetaventById(int id_detalleVenta )
    {
        DetaventService dao = new DetaventServiceImpl();
        return dao.findById(id_detalleVenta);
    }

    [WebMethod]
    public int deleteDetavent (int id_detalleVenta )
    {
        detalles_de_venta detavent  = new detalles_de_venta();
        detavent.Id_detalleVenta = id_detalleVenta;
        DetaventService dao = new DetaventServiceImpl();
        return (int)dao.remove(detavent);
    }

    [WebMethod]
    public int updateDetavent (Int32 id_detalleVenta , Int32 ventas, Int32 zapatos, Int32 empleados, Int32 cantidadP, Decimal totalPag)
    {
        detalles_de_venta detavent  = new detalles_de_venta();
        detavent.Id_detalleVenta = id_detalleVenta;
        detavent.Ventas = ventas;
        detavent.Zapatos = zapatos;
        detavent.Empleados = empleados;
        detavent.CantidadProducto1 = cantidadP;
        detavent.TotalPagar1 = totalPag;
        DetaventService dao = new DetaventServiceImpl();
        return (int)dao.update(detavent);
    }

    //metodos para empleados

    [WebMethod]
    public int agregarEmpleado (String nombre , String apellido , String telefono , String direccion , Int32 cargo, DateTime fechanac , String dui, String nit )
    {
        empleados empleado  = new empleados();
        empleado.Nomempleado  = nombre ;
        empleado.Apeempleado = apellido;
        empleado.Numtellempleado = telefono;
        empleado.Direcempleado = direccion;
        empleado.Cargos = cargo;
        empleado.Fechanacempleado = fechanac;
        empleado.Duiempleado  = dui ;
        empleado.Nitempleado  = nit ;
        EmpleadoService dao = new EmpleadoServiceImpl();
        return (int)dao.add(empleado );
    }

    [WebMethod]
    public List<empleados> getAllEmpleados ()
    {
        EmpleadoService dao = new EmpleadoServiceImpl();
        return dao.findAll();
    }

    [WebMethod]
    public empleados getEmpleadosById(int id_empleado )
    {
        EmpleadoService dao = new EmpleadoServiceImpl();
        return dao.findById(id_empleado);
    }

    [WebMethod]
    public int deleteEmpleado (int id_empleado)
    {
        empleados empleado  = new empleados ();
        empleado.Id_empleado = id_empleado;
        EmpleadoService dao = new EmpleadoServiceImpl();
        return (int)dao.remove(empleado);
    }

    [WebMethod]
    public int updateEmpleado (Int32 id_empleado , String nombre, String apellido, String telefono, String direccion, Int32 cargo, DateTime fechanac, String dui, String nit)
    {
        empleados empleado  = new empleados();
        empleado.Id_empleado = id_empleado;
        empleado.Nomempleado = nombre;
        empleado.Apeempleado = apellido;
        empleado.Numtellempleado = telefono;
        empleado.Direcempleado = direccion;
        empleado.Cargos = cargo;
        empleado.Fechanacempleado = fechanac;
        empleado.Duiempleado = dui;
        empleado.Nitempleado = nit;
        EmpleadoService dao = new EmpleadoServiceImpl();
        return (int)dao.update(empleado);
    }

    //metodos para estilos

    [WebMethod]
    public int agregarEstilo (String nombre, String descripcion, String genero )
    {
        estilos estilo  = new estilos();
        estilo.NomEstilo1 = nombre;
        estilo.Descripcíon1 = descripcion;
        estilo.GeneroEstilo1 = genero;
        EstilosService dao = new EstiloServiceImpl();
        return (int)dao.add(estilo);
    }

    [WebMethod]
    public List<estilos> getAllEstilos ()
    {
        EstilosService dao = new EstiloServiceImpl();
        return dao.findAll();
    }

    [WebMethod]
    public estilos getEstilosById(int id_estilo )
    {
        EstilosService dao = new EstiloServiceImpl();
        return dao.findById(id_estilo);
    }

    [WebMethod]
    public int deleteEstilos (int id_estilo )
    {
        estilos estilo  = new estilos();
        estilo.Id_estilo = id_estilo;
        EstilosService dao = new EstiloServiceImpl();
        return (int)dao.remove(estilo);
    }

    [WebMethod]
    public int updateEstilos (Int32 id_estilo , String nombre, String descripcion, String genero)
    {
        estilos estilo  = new estilos();
        estilo.Id_estilo = id_estilo;
        estilo.NomEstilo1 = nombre;
        estilo.Descripcíon1 = descripcion;
        estilo.GeneroEstilo1 = genero;
        EstilosService dao = new EstiloServiceImpl();
        return (int)dao.update(estilo);
    }

    //metodos para zapatos

    [WebMethod]
    public int agregarZapato (String nombre, Int32 estilo , Int32 marca, String tallas , Int32 cantidad , String colores , Int32 viajeros )
    {
        zapatos zapato  = new zapatos();
        zapato.NomGaZapato1  = nombre;
        zapato.Estilos   = estilo ;
        zapato.Marcas  = marca ;
        zapato.TallasDisponibles1  = tallas ;
        zapato.CantidadDisponible1  = cantidad;
        zapato.ColoresGama1  = colores ;
        zapato.Viajeros  = viajeros ;
        ZapatoService dao = new ZapatoServiceImpl();
        return (int)dao.add(zapato);
    }

    [WebMethod]
    public List<zapatos> getAllZapato ()
    {
        ZapatoService dao = new ZapatoServiceImpl();
        return dao.findAll();
    }

    [WebMethod]
    public zapatos getZapatoById(int id_zapatos )
    {
        ZapatoService dao = new ZapatoServiceImpl();
        return dao.findById(id_zapatos);
    }

    [WebMethod]
    public int deleteZapato (int id_zapatos)
    {
        zapatos zapato  = new zapatos ();
        zapato.Id_zapatos = id_zapatos;
        ZapatoService dao = new ZapatoServiceImpl();
        return (int)dao.remove(zapato);
    }

    [WebMethod]
    public int updateZapato (Int32 id_zapatos , String nombre, Int32 estilo, Int32 marca, String tallas, Int32 cantidad, String colores, Int32 viajeros)
    {
        zapatos zapato  = new zapatos();
        zapato.Id_zapatos = id_zapatos;
        zapato.NomGaZapato1 = nombre;
        zapato.Estilos = estilo;
        zapato.Marcas = marca;
        zapato.TallasDisponibles1 = tallas;
        zapato.CantidadDisponible1 = cantidad;
        zapato.ColoresGama1 = colores;
        zapato.Viajeros = viajeros;
        ZapatoService dao = new ZapatoServiceImpl();
        return (int)dao.update(zapato);
    }

    //metodos para marcas

    [WebMethod]
    public int agregarMarca (String nombre)
    {
        marcas marca  = new marcas ();
        marca.NomMarca1  = nombre;
        MarcasService  dao = new MarcasServiceImpl();
        return (int)dao.add(marca );
    }

    [WebMethod]
    public List<marcas > getAllMarcas ()
    {
        MarcasService dao = new MarcasServiceImpl();
        return dao.findAll();
    }

    [WebMethod]
    public marcas  getMarcasById(int id_marcas)
    {
        MarcasService dao = new MarcasServiceImpl();
        return dao.findById(id_marcas);
    }

    [WebMethod]
    public int deleteMarcas (int id_marcas )
    {
        marcas marca = new marcas();
        marca  .Id_marcas = id_marcas;
        MarcasService dao = new MarcasServiceImpl();
        return (int)dao.remove(marca);
    }

    [WebMethod]
    public int updateMarcas (Int32 id_marcas, String nombre)
    {
        marcas marca = new marcas();
        marca .Id_marcas  = id_marcas;
        marca.NomMarca1  = nombre;
        MarcasService dao = new MarcasServiceImpl();
        return (int)dao.update(marca);
    }


    // metodos para pedidos 

    [WebMethod]
    public int agregarPedidos (Int32 viajeros , Int32 zapatos , Int32 CantidadPedido,  Double CostoTotal )
    {
        pedidos  pedido  = new pedidos ();
        pedido  .Viajeros  = viajeros ;
        pedido.Zapatos = zapatos;
        pedido.CantidadPedido1 = CantidadPedido;
        pedido.CostoTotal1 = CostoTotal;
        PedidosService  dao = new PedidoServiceImpl ();
        return (int)dao.add(pedido );
    }

    [WebMethod]
    public List<pedidos > getAllPedidos ()
    {
        PedidosService  dao = new PedidoServiceImpl ();
        return dao.findAll();
    }

    [WebMethod]
    public pedidos  getPedidosById(int id_pedido )
    {
        PedidosService  dao = new PedidoServiceImpl ();
        return dao.findById(id_pedido);
    }

    [WebMethod]
    public int deletePedidos (int id_pedido )
    {
        pedidos  pedido  = new pedidos ();
        pedido.Id_pedido  = id_pedido ;

        PedidosService  dao = new PedidoServiceImpl ();
        return (int)dao.remove(pedido );
    }

    [WebMethod]
    public int updatePedidos (Int32 id_pedido , Int32 viajeros, Int32 zapatos, Int32 CantidadPedido, Double CostoTotal)
    {
        pedidos  pedido  = new pedidos ();
        pedido.Id_pedido  = id_pedido ;
        pedido.Viajeros = viajeros;
        pedido.Zapatos = zapatos;
        pedido.CantidadPedido1 = CantidadPedido;
        pedido.CostoTotal1 = CostoTotal;
        PedidosService  dao = new PedidoServiceImpl ();
        return (int)dao.update(pedido);
    }

    //Metodos para prestamos

    [WebMethod]
    public int agregarPrestamos (Int32 ventas , Decimal  abonodeuda , Decimal   saldopendiente )
    {
        prestamos  prestamo  = new prestamos ();
        prestamo .Ventas  = ventas;
        prestamo .AbonoDeuda1  = abonodeuda ;
        prestamo .SaldoPendiente1  = saldopendiente ;
        PrestamoService  dao = new PrestamoServiceImpl ();
        return (int)dao.add(prestamo );
    }

    [WebMethod]
    public List<prestamos > getAllPrestamos ()
    {
        PrestamoService  dao = new PrestamoServiceImpl ();
        return dao.findAll();
    }

    [WebMethod]
    public prestamos  getPrestamosById(int id_prestamo )
    {
        PrestamoService  dao = new PrestamoServiceImpl ();
        return dao.findById(id_prestamo);
    }

    [WebMethod]
    public int deletePrestamos (int id_prestamo )
    {
        prestamos  prestamo  = new prestamos ();
        prestamo  .Id_prestamo  = id_prestamo ;

        PrestamoService dao = new PrestamoServiceImpl ();
        return (int)dao.remove(prestamo );
    }

    [WebMethod]
    public int updatePrestamos (Int32 id_prestamo , Int32 ventas, Decimal abonodeuda, Decimal saldopendiente)
    {
        prestamos  prestamo  = new prestamos ();
        prestamo  .Id_prestamo  = id_prestamo ;
        prestamo.Ventas = ventas;
        prestamo.AbonoDeuda1 = abonodeuda;
        prestamo.SaldoPendiente1 = saldopendiente;
        PrestamoService  dao = new PrestamoServiceImpl ();
        return (int)dao.update(prestamo );
    }

    // Metodos para proveedores

    [WebMethod]
    public int agregarProveedor (String  nomempresa , String  telempresa , String  correoempresa )
    {
        proveedores  proveedor  = new proveedores ();
        proveedor.NomEmpresa1  = nomempresa ;
        proveedor .TelefonoEmpresa1  = telempresa ;
        proveedor .CorreoEmpresa1  = correoempresa ;
        ProveedoresService  dao = new ProveedoresServiceImpl ();
        return (int)dao.add(proveedor );
    }

    [WebMethod]
    public List<proveedores > getAllProveedores ()
    {
        ProveedoresService   dao = new ProveedoresServiceImpl  ();
        return dao.findAll();
    }

    [WebMethod]
    public proveedores  getProveedoresById(int id_proveedor )
    {
        ProveedoresService  dao = new ProveedoresServiceImpl ();
        return dao.findById(id_proveedor);
    }

    [WebMethod]
    public int deleteProveedores (int id_proveedor )
    {
        proveedores  proveedor  = new proveedores ();
        proveedor  .Id_proveedor  = id_proveedor;

        ProveedoresService  dao = new ProveedoresServiceImpl ();
        return (int)dao.remove(proveedor );
    }

    [WebMethod]
    public int updateProveedores (Int32 id_proveedor , String nomempresa, String telempresa, String correoempresa)
    {
        proveedores   proveedor  = new proveedores ();
        proveedor .Id_proveedor   = id_proveedor ;
        proveedor.NomEmpresa1 = nomempresa;
        proveedor.TelefonoEmpresa1 = telempresa;
        proveedor.CorreoEmpresa1 = correoempresa;
        ProveedoresService  dao = new ProveedoresServiceImpl ();
        return (int)dao.update(proveedor );
    }

    // Metodos para ventas 

    [WebMethod]
    public int agregarVenta (DateTime FechaVenta, Int32  clientes)
    {
        ventas  venta  = new ventas();
        venta .FechaVenta1  = FechaVenta ;
        venta.Clientes = clientes;
        VentasService  dao = new VentaServiceImpl();
        return (int)dao.add(venta);
    }

    [WebMethod]
    public List<ventas> getAllVentas ()
    {
        VentasService dao = new VentaServiceImpl();
        return dao.findAll();
    }

    [WebMethod]
    public ventas getVentasById(int id_venta )
    {
        VentasService dao = new VentaServiceImpl();
        return dao.findById(id_venta);
    }

    [WebMethod]
    public int deleteVentas (int id_venta )
    {
        ventas venta  = new ventas ();
        venta.Id_venta = id_venta ;

        VentasService dao = new VentaServiceImpl();
        return (int)dao.remove(venta);
    }

    [WebMethod]
    public int updateVentas (Int32 id_venta , DateTime FechaVenta, Int32 clientes)
    {
        ventas venta  = new ventas();
        venta.Id_venta = id_venta;
        venta.FechaVenta1 = FechaVenta;
        venta.Clientes = clientes;
        VentasService dao = new VentaServiceImpl();
        return (int)dao.update(venta);
    }

    // Metodos para Viajeros 


    [WebMethod]
    public int agregarViajero (String NomViajero, String ApeViajero , String TelefonoViajero ,  Int32 proveedores , String CorreoViajero )
    {
        viajeros  viajero  = new viajeros ();
        viajero.NomViajero1  = NomViajero ;
        viajero.ApeViajero1  = ApeViajero ;
        viajero.TelefonoViajero1  = TelefonoViajero;
        viajero.Proveedores = proveedores ;
        viajero.CorreoViajero1  = CorreoViajero ;
        ViajeroService  dao = new ViajeroServiceImpl();
        return (int)dao.add(viajero );
    }

    [WebMethod]
    public List<viajeros > getAllViajeros ()
    {
        ViajeroService  dao = new ViajeroServiceImpl ();
        return dao.findAll();
    }

    [WebMethod]
    public viajeros  getViajerosById(int id_viajero )
    {
        ViajeroService  dao = new ViajeroServiceImpl ();
        return dao.findById(id_viajero);
    }

    [WebMethod]
    public int deleteViajeros (int id_viajero )
    {
        viajeros  viajero  = new viajeros ();
        viajero  .Id_viajero  = id_viajero ;

        ViajeroService  dao = new ViajeroServiceImpl ();
        return (int)dao.remove(viajero );
    }

    [WebMethod]
    public int updateViajeros (Int32 id_viajero , String NomViajero, String ApeViajero, String TelefonoViajero, Int32 proveedores, String CorreoViajero)
    {
        viajeros  viajero  = new viajeros ();
        viajero  .Id_viajero  = id_viajero ;
        viajero.NomViajero1 = NomViajero;
        viajero.ApeViajero1 = ApeViajero;
        viajero.TelefonoViajero1 = TelefonoViajero;
        viajero.Proveedores = proveedores;
        viajero.CorreoViajero1 = CorreoViajero;
        ViajeroService dao = new ViajeroServiceImpl();
        return (int)dao.update(viajero);
    }

    //metodo para usuario 

    [WebMethod]
    public int agregarUsuario (String usuario, String contraseña)
    {
        usuarios  usuario2   = new usuarios ();
        usuario2.Usuario  = usuario ;
        usuario2.Contraseña  = contraseña  ;
        Usuarioservice  dao = new UsuarioServiceImpl ();
        return (int)dao.add(usuario2  );
    }

    [WebMethod]
    public usuarios  login(string usuario , string contraseña )
    {
        Usuarioservice  dao = new UsuarioServiceImpl ();
        usuarios  usuario2  = new usuarios ();
        usuario2.Usuario  = usuario  ;
        usuario2.Contraseña  = contraseña ;
        return dao.login(usuario2);
    }

}
