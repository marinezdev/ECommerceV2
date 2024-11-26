using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using conekta;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ECommerce.Controllers
{
    public class MetodoPagoController : Controller
    {
        public ActionResult Index(Application.CarroElectronico APCarroElectronico, Application.Cliente APcliente)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["SesionInvitacion"] != null)
                {
                    List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                    Models.Cliente cliente = (Models.Cliente)System.Web.HttpContext.Current.Session["SesionInvitacion"];

                    string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                    Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
                    Models.Consultas.UsuarioInformacion usuarioInformacions = APcliente.Cliente_Seleccionar_Id(cliente);


                    decimal Precio = 0;
                    foreach (var dt in Lista)
                    {
                        Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                    }
                    string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                                //String s = String.Format("{0:#,##0.##}", Precio);

                    ViewBag.Total = s;
                    ViewBag.ListaArticulos = Lista;
                    ViewBag.Cliente = usuarioInformacions;
                    return View();
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Index", "CarroElectronico");
            }

        }
        public ActionResult OxxoPay(Application.CarroElectronico APCarroElectronico, Application.Cliente APcliente)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["SesionInvitacion"] != null)
                {
                    List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                    Models.Cliente cliente = (Models.Cliente)System.Web.HttpContext.Current.Session["SesionInvitacion"];

                    string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                    Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
                    Models.Consultas.UsuarioInformacion usuarioInformacions = APcliente.Cliente_Seleccionar_Id(cliente);


                    decimal Precio = 0;
                    foreach (var dt in Lista)
                    {
                        Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                    }
                    string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                                //String s = String.Format("{0:#,##0.##}", Precio);

                    ViewBag.Total = s;
                    ViewBag.ListaArticulos = Lista;
                    ViewBag.Cliente = usuarioInformacions;
                    return View();
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Index", "CarroElectronico");
            }
        }
        public ActionResult OxxoReferencia(Application.CarroElectronico APCarroElectronico, Application.Direccion APDireccion, Application.Venta APventa, Application.Cliente APcliente, Application.VentaArticulo APventaArticulo)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["SesionInvitacion"] != null)
                {
                    //Calculate an expiration time
                    DateTime thirtyDaysFromNowDateTime = DateTime.Now.AddDays(30);
                    long thirtyDaysFromNowUnixTimestamp = (Int64)(thirtyDaysFromNowDateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                    String thirtyDaysFromNow = thirtyDaysFromNowUnixTimestamp.ToString();

                    conekta.Api.apiKey = "key_i6nmbpEDF7gtY2oop0yMpEp";
                    conekta.Api.version = "2.0.0";

                    try
                    {
                        List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                        Models.Cliente cliente = (Models.Cliente)System.Web.HttpContext.Current.Session["SesionInvitacion"];

                        string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                        Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
                        Models.Consultas.UsuarioInformacion usuarioInformacions = APcliente.Cliente_Seleccionar_Id(cliente);

                        decimal Precio = 0;
                        foreach (var dt in Lista)
                        {
                            Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                        }
                        string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format

                        List<lineItems> lineItems = new List<lineItems>();
                        var Email = usuarioInformacions.Email.email;
                        var direccion = usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CatPoblaciones.CatEstados.Estado + ", " + usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CatPoblaciones.Poblacion + ", " + usuarioInformacions.PersonaDireccion.CatColonias.Colonia + ", " + usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CP + ", " 
                            + usuarioInformacions.PersonaDireccion.Calle + ", " + usuarioInformacions.PersonaDireccion.NumExterior + ", " + usuarioInformacions.PersonaDireccion.NumInterior;
                        var _telefono = "";
                        if(usuarioInformacions.Telefono != null)
                        {
                            _telefono = usuarioInformacions.Telefono.telefono;
                        }


                        foreach (var dt in Lista)
                        {
                            float  Num  = dt.ArticuloDetalle.PrecioPublico;
                            string formattedNumber = Num.ToString("0.00");
                            string modifiedString = formattedNumber.Replace(".", "");
                            int x = Convert.ToInt32(modifiedString);

                            lineItems.Add(new lineItems()
                            {
                                name = dt.ArticuloDetalle.Nombre,
                                unit_price = Convert.ToInt32(x),
                                quantity = dt.CarroElectronico.Item,
                            });
                        }

                        var shipping_lines = new[]
                            {
                            new
                            {
                                amount = 0,
                                carrier = "ASAE CONSULTORES",
                            }
                        };

                        var customerInfo = new
                        {
                            name = usuarioInformacions.Persona.Nombre + " " + usuarioInformacions.Persona.ApellidoPaterno + " " + usuarioInformacions.Persona.ApellidoMaterno,
                            email = Email,
                            phone = _telefono,
                        };

                        var address = new
                        {
                            street1 = direccion,
                            postal_code = usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CP,
                            country = "MX",
                        };

                        var shipping_contact = new
                        {
                            address = address
                        };

                        var payment_method = new
                        {
                            type = "oxxo_cash",
                            expires_at = thirtyDaysFromNow
                        };

                        var charges = new[]
                        {
                            new
                            {
                                payment_method = payment_method
                            }

                        };


                        var orderData = new
                        {
                            line_items = lineItems,
                            shipping_lines = shipping_lines,
                            currency = "MXN",
                            customer_info = customerInfo,
                            shipping_contact = shipping_contact,
                            charges = charges,
                        };

                        string _orderDataWithCheckout = JsonConvert.SerializeObject(orderData);


                        //conekta.Order order = new conekta.Order().create(orderData.ToString());
                        conekta.Order order = new conekta.Order().create(_orderDataWithCheckout);

                        Charge charge = (Charge)order.charges.at(0);
                        LineItem line_item = (LineItem)order.line_items.at(0);

                        Console.WriteLine("ID: " + order.id);
                        Console.WriteLine("Payment Method: " + charge.payment_method.service_name);
                        Console.WriteLine("Reference: " + charge.payment_method.reference);
                        Console.WriteLine("$" + (order.amount / 100) + order.currency);
                        Console.WriteLine("Order");
                        Console.WriteLine(line_item.quantity + " - "
                                    + line_item.name + " - "
                                    + (line_item.unit_price / 100));



                        ViewBag.Total = s;
                        ViewBag.ListaArticulos = Lista;
                        ViewBag.Cliente = usuarioInformacions;
                        ViewBag.Referencia = charge.payment_method.reference;

                        //// EJECUTAR REGISTRO DE COMPRA
                        Models.CookieCarrito cookieCarrito = new Models.CookieCarrito();
                        Models.CatMetodoPago catMetodoPago = new Models.CatMetodoPago();
                        catMetodoPago.Id = 2;

                        cookieCarrito.Clave = ClaveCarro;
                        Models.Venta NewVenta = new Models.Venta();
                        NewVenta.CatMetodoPago = catMetodoPago;
                        NewVenta.Referencia = charge.payment_method.reference;
                        NewVenta.Total = Precio;
                        NewVenta.CookieCarrito = cookieCarrito;
                        NewVenta.Cliente = cliente;
                        Models.Venta venta_Consultar = APventa.SPNuevaVenta(NewVenta);
                        ViewBag.Folio = venta_Consultar.Folio;

                        //// REGISTRO ARTICULOS A LA VENTA 
                        foreach (var dt in Lista)
                        {
                            Models.VentaArticulo ventaArticulo = new Models.VentaArticulo();
                            ventaArticulo.Venta = venta_Consultar;
                            ventaArticulo.Articulo = dt.Articulo;
                            ventaArticulo.Item = dt.CarroElectronico.Item;
                            ventaArticulo.Precio = dt.ArticuloDetalle.PrecioPublico;
                            APventaArticulo.VentaArticulo_Agregar(ventaArticulo);
                        }

                        Response.Cookies["Carrito"].Expires = DateTime.Now.AddDays(-1);
                        Session["SesionInvitacion"] = null;

                        //// ENVIO DE CORREO ELECTRONICO
                        Application.Correo.NuevaVenta nuevaVenta = new Application.Correo.NuevaVenta();
                        nuevaVenta.CorreoNuevaCompra(usuarioInformacions, Lista, NewVenta, venta_Consultar, s);

                    }
                    catch (ConektaException e)
                    {
                        foreach (JObject obj in e.details)
                        {
                            System.Console.WriteLine("\n [ERROR]:\n");
                            System.Console.WriteLine("message:\t" + obj.GetValue("message"));
                            System.Console.WriteLine("debug:\t" + obj.GetValue("debug_message"));
                            System.Console.WriteLine("code:\t" + obj.GetValue("code"));
                        }
                    }
                                                               //String s = String.Format("{0:#,##0.##}", Precio);


                    return View();
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Index", "CarroElectronico");
            }
        }
        public ActionResult SPEI(Application.CarroElectronico APCarroElectronico, Application.Cliente APcliente)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["SesionInvitacion"] != null)
                {
                    List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                    Models.Cliente cliente = (Models.Cliente)System.Web.HttpContext.Current.Session["SesionInvitacion"];

                    string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                    Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
                    Models.Consultas.UsuarioInformacion usuarioInformacions = APcliente.Cliente_Seleccionar_Id(cliente);


                    decimal Precio = 0;
                    foreach (var dt in Lista)
                    {
                        Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                    }
                    string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                                //String s = String.Format("{0:#,##0.##}", Precio);

                    ViewBag.Total = s;
                    ViewBag.ListaArticulos = Lista;
                    ViewBag.Cliente = usuarioInformacions;
                    return View();
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Index", "CarroElectronico");
            }
        }
        public ActionResult SPEIReferencia(Application.CarroElectronico APCarroElectronico, Application.Direccion APDireccion, Application.Venta APventa, Application.Cliente APcliente, Application.VentaArticulo APventaArticulo)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["SesionInvitacion"] != null)
                {
                    //Calculate an expiration time
                    DateTime thirtyDaysFromNowDateTime = DateTime.Now.AddDays(30);
                    long thirtyDaysFromNowUnixTimestamp = (Int64)(thirtyDaysFromNowDateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                    String thirtyDaysFromNow = thirtyDaysFromNowUnixTimestamp.ToString();

                    conekta.Api.apiKey = "key_i6nmbpEDF7gtY2oop0yMpEp";
                    conekta.Api.version = "2.0.0";

                    try
                    {
                        List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                        Models.Cliente cliente = (Models.Cliente)System.Web.HttpContext.Current.Session["SesionInvitacion"];

                        string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                        Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
                        Models.Consultas.UsuarioInformacion usuarioInformacions = APcliente.Cliente_Seleccionar_Id(cliente);

                        decimal Precio = 0;
                        foreach (var dt in Lista)
                        {
                            Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                        }
                        string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format

                        List<lineItems> lineItems = new List<lineItems>();
                        var Email = usuarioInformacions.Email.email;
                        var direccion = usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CatPoblaciones.CatEstados.Estado + ", " + usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CatPoblaciones.Poblacion + ", " + usuarioInformacions.PersonaDireccion.CatColonias.Colonia + ", " + usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CP + ", "
                            + usuarioInformacions.PersonaDireccion.Calle + ", " + usuarioInformacions.PersonaDireccion.NumExterior + ", " + usuarioInformacions.PersonaDireccion.NumInterior;
                        //var CP = direccion1.CP;

                        foreach (var dt in Lista)
                        {
                            float Num = dt.ArticuloDetalle.PrecioPublico;
                            string formattedNumber = Num.ToString("0.00");
                            string modifiedString = formattedNumber.Replace(".", "");
                            int x = Convert.ToInt32(modifiedString);

                            lineItems.Add(new lineItems()
                            {
                                name = dt.ArticuloDetalle.Nombre,
                                unit_price = Convert.ToInt32(x),
                                quantity = dt.CarroElectronico.Item,
                            });
                        }

                        var shipping_lines = new[]
                            {
                            new
                            {
                                amount = 0,
                                carrier = "ASAE CONSULTORES",
                            }
                        };

                        var customerInfo = new
                        {
                            name = usuarioInformacions.Persona.Nombre + " " + usuarioInformacions.Persona.ApellidoPaterno + " " + usuarioInformacions.Persona.ApellidoMaterno,
                            email = Email,
                            phone = usuarioInformacions.Telefono.telefono,
                        };

                        var address = new
                        {
                            street1 = direccion,
                            postal_code = usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CP,
                            country = "MX",
                        };

                        var shipping_contact = new
                        {
                            address = address
                        };

                        var payment_method = new
                        {
                            type = "spei",
                            expires_at = thirtyDaysFromNow
                        };

                        var charges = new[]
                        {
                            new
                            {
                                payment_method = payment_method
                            }

                        };


                        var orderData = new
                        {
                            line_items = lineItems,
                            shipping_lines = shipping_lines,
                            currency = "MXN",
                            customer_info = customerInfo,
                            shipping_contact = shipping_contact,
                            charges = charges,
                        };

                        string _orderDataWithCheckout = JsonConvert.SerializeObject(orderData);


                        //conekta.Order order = new conekta.Order().create(orderData.ToString());
                        conekta.Order order = new conekta.Order().create(_orderDataWithCheckout);

                        Charge charge = (Charge)order.charges.at(0);
                        LineItem line_item = (LineItem)order.line_items.at(0);

                        Console.WriteLine("ID: " + order.id);
                        Console.WriteLine("Payment Method: " + charge.payment_method.service_name);
                        Console.WriteLine("Reference: " + charge.payment_method.receiving_account_number);
                        Console.WriteLine("$" + (order.amount / 100) + order.currency);
                        Console.WriteLine("Order");
                        Console.WriteLine(line_item.quantity + " - "
                                    + line_item.name + " - "
                                    + (line_item.unit_price / 100));



                        ViewBag.Total = s;
                        ViewBag.ListaArticulos = Lista;
                        ViewBag.Cliente = usuarioInformacions;
                        ViewBag.Bank = charge.payment_method.receiving_account_bank;
                        ViewBag.Referencia = charge.payment_method.receiving_account_number;

                        //// EJECUTAR REGISTRO DE COMPRA
                        Models.CookieCarrito cookieCarrito = new Models.CookieCarrito();
                        Models.CatMetodoPago catMetodoPago = new Models.CatMetodoPago();
                        catMetodoPago.Id = 3;

                        cookieCarrito.Clave = ClaveCarro;
                        Models.Venta NewVenta = new Models.Venta();
                        NewVenta.CatMetodoPago = catMetodoPago;
                        NewVenta.Referencia = charge.payment_method.receiving_account_number;
                        NewVenta.Total = Precio;
                        NewVenta.CookieCarrito = cookieCarrito;
                        NewVenta.Cliente = cliente;
                        Models.Venta venta_Consultar = APventa.SPNuevaVenta(NewVenta);
                        ViewBag.Folio = venta_Consultar.Folio;

                        //// REGISTRO ARTICULOS A LA VENTA 
                        foreach (var dt in Lista)
                        {
                            Models.VentaArticulo ventaArticulo = new Models.VentaArticulo();
                            ventaArticulo.Venta = venta_Consultar;
                            ventaArticulo.Articulo = dt.Articulo;
                            ventaArticulo.Item = dt.CarroElectronico.Item;
                            ventaArticulo.Precio = dt.ArticuloDetalle.PrecioPublico;
                            APventaArticulo.VentaArticulo_Agregar(ventaArticulo);
                        }


                        Response.Cookies["Carrito"].Expires = DateTime.Now.AddDays(-1);
                        Session["SesionInvitacion"] = null;
                        //// ENVIO DE CORREO ELECTRONICO
                        Application.Correo.NuevaVenta nuevaVenta = new Application.Correo.NuevaVenta();
                        nuevaVenta.CorreoNuevaCompra(usuarioInformacions, Lista, NewVenta, venta_Consultar, s);

                    }
                    catch (ConektaException e)
                    {
                        foreach (JObject obj in e.details)
                        {
                            System.Console.WriteLine("\n [ERROR]:\n");
                            System.Console.WriteLine("message:\t" + obj.GetValue("message"));
                            System.Console.WriteLine("debug:\t" + obj.GetValue("debug_message"));
                            System.Console.WriteLine("code:\t" + obj.GetValue("code"));
                        }
                    }

                    return View();
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Index", "CarroElectronico");
            }
        }
        public ActionResult Paypal(Application.CarroElectronico APCarroElectronico, Application.Cliente APcliente)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["SesionInvitacion"] != null)
                {
                    List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                    Models.Cliente cliente = (Models.Cliente)System.Web.HttpContext.Current.Session["SesionInvitacion"];

                    string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                    Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
                    Models.Consultas.UsuarioInformacion usuarioInformacions = APcliente.Cliente_Seleccionar_Id(cliente);


                    decimal Precio = 0;
                    foreach (var dt in Lista)
                    {
                        Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                    }
                    string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                                //String s = String.Format("{0:#,##0.##}", Precio);
                    ViewBag.Total = s;
                    ViewBag.TotalT = Precio;
                    ViewBag.ListaArticulos = Lista;
                    ViewBag.Cliente = usuarioInformacions;
                    return View();
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Index", "CarroElectronico");
            }
        }
        public ActionResult PaypalReferencia(Application.CarroElectronico APCarroElectronico, Application.Direccion APDireccion, Application.Venta APventa, Application.Cliente APcliente, Application.VentaArticulo APventaArticulo)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["SesionInvitacion"] != null)
                {
                    try 
                    { 
                
                        List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                        Models.Cliente cliente = (Models.Cliente)System.Web.HttpContext.Current.Session["SesionInvitacion"];

                        string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                        Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
                        Models.Consultas.UsuarioInformacion usuarioInformacions = APcliente.Cliente_Seleccionar_Id(cliente);

                        decimal Precio = 0;
                        foreach (var dt in Lista)
                        {
                            Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                        }
                        string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format

                        List<lineItems> lineItems = new List<lineItems>();
                        var Email = usuarioInformacions.Email.email;
                        var direccion = usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CatPoblaciones.CatEstados.Estado + ", " + usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CatPoblaciones.Poblacion + ", " + usuarioInformacions.PersonaDireccion.CatColonias.Colonia + ", " + usuarioInformacions.PersonaDireccion.CatColonias.CatCp.CP + ", "
                            + usuarioInformacions.PersonaDireccion.Calle + ", " + usuarioInformacions.PersonaDireccion.NumExterior + ", " + usuarioInformacions.PersonaDireccion.NumInterior;
                        //var CP = direccion1.CP;


                        ViewBag.Total = s;
                        ViewBag.ListaArticulos = Lista;
                        ViewBag.Cliente = usuarioInformacions;

                        //// EJECUTAR REGISTRO DE COMPRA
                        Models.CookieCarrito cookieCarrito = new Models.CookieCarrito();
                        Models.CatMetodoPago catMetodoPago = new Models.CatMetodoPago();
                        catMetodoPago.Id = 1;

                        cookieCarrito.Clave = ClaveCarro;
                        Models.Venta NewVenta = new Models.Venta();
                        NewVenta.CatMetodoPago = catMetodoPago;
                        NewVenta.Referencia = "-";
                        NewVenta.Total = Precio;
                        NewVenta.CookieCarrito = cookieCarrito;
                        NewVenta.Cliente = cliente;
                        Models.Venta venta_Consultar = APventa.SPNuevaVenta(NewVenta);
                        ViewBag.Folio = venta_Consultar.Folio;

                        //// REGISTRO ARTICULOS A LA VENTA 
                        foreach (var dt in Lista)
                        {
                            Models.VentaArticulo ventaArticulo = new Models.VentaArticulo();
                            ventaArticulo.Venta = venta_Consultar;
                            ventaArticulo.Articulo = dt.Articulo;
                            ventaArticulo.Item = dt.CarroElectronico.Item;
                            ventaArticulo.Precio = dt.ArticuloDetalle.PrecioPublico;
                            APventaArticulo.VentaArticulo_Agregar(ventaArticulo);
                        }

                        Response.Cookies["Carrito"].Expires = DateTime.Now.AddDays(-1);
                        Session["SesionInvitacion"] = null;

                        //// ENVIO DE CORREO ELECTRONICO
                        Application.Correo.NuevaVenta nuevaVenta = new Application.Correo.NuevaVenta();
                        nuevaVenta.CorreoNuevaCompra(usuarioInformacions, Lista, NewVenta, venta_Consultar, s);
                    }
                    catch (ConektaException e)
                    {
                        foreach (JObject obj in e.details)
                        {
                            System.Console.WriteLine("\n [ERROR]:\n");
                            System.Console.WriteLine("message:\t" + obj.GetValue("message"));
                            System.Console.WriteLine("debug:\t" + obj.GetValue("debug_message"));
                            System.Console.WriteLine("code:\t" + obj.GetValue("code"));
                        }
                    }

                    return View();
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Index", "CarroElectronico");
            }
        }
        public ActionResult Checkout(Application.CarroElectronico APCarroElectronico, Application.Cliente APcliente)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["SesionInvitacion"] != null)
                {
                    List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                    Models.Cliente cliente = (Models.Cliente)System.Web.HttpContext.Current.Session["SesionInvitacion"];

                    string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                    Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
                    Models.Consultas.UsuarioInformacion usuarioInformacions = APcliente.Cliente_Seleccionar_Id(cliente);


                    decimal Precio = 0;
                    foreach (var dt in Lista)
                    {
                        Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                    }
                    string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                                //String s = String.Format("{0:#,##0.##}", Precio);
                    ViewBag.Total = s;
                    ViewBag.ListaArticulos = Lista;
                    ViewBag.Cliente = usuarioInformacions;
                    return View();
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Index", "CarroElectronico");
            }

        }


        public class Item
        {
            public string name { get; set; }
            public int unit_price { get; set; }
            public int quantity { get; set; }
        }
        public class lineItems
        {
            public string name { get; set; }
            public int unit_price { get; set; }
            public int quantity { get; set; }
        }
    }
}
