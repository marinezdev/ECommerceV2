using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Articulo
    {
        Data.Articulo _Articulo = new Data.Articulo();
        public Models.Articulo Articulo_agregar(Models.Consultas.NuevoArticulo nuevoArticulo)
        {
            return _Articulo.Articulo_Agregar(nuevoArticulo);
        }
        public List<Models.Consultas.ArticuloConsulta> Articulo_Seleccionar_TotalSubCategoria()
        {
            return _Articulo.Articulo_Seleccionar_TotalSubCategoria();
        }
        public List<Models.Consultas.ArticuloConsulta> Articulo_Seleccionar_UltimosArticulos()
        {
            return _Articulo.Articulo_Seleccionar_UltimosArticulos();
        }
        public List<Models.Consultas.ArticuloConsulta> Articulo_Seleccionar()
        {
            return _Articulo.Articulo_Seleccionar();
        }
        public Models.Consultas.ArticuloConsulta Articulo_Seleccionar_IdArticulo(Models.Articulo articulo)
        {
            return _Articulo.Articulo_Seleccionar_IdArticulo(articulo);
        }
        public string Articulo_Selecionar_IdClasificacion(Models.CatClasificacion catClasificacion)
        {
            string Contenido = "";
            int a = 0;


            string header = "";
            int total = 0;
            bool uno = false;

            if (a == 0)
            {
                header += "" +
                "<div class='tab-pane fade show active' id='grup_" + catClasificacion.Id + "' role='tabpanel'>" +
                    "<!-- Slide2 -->" +
                    "<div class='wrap-slick2'>" +
                        "<div class='slick2'>";
                a += 1;
            }
            else
            {
                header += "" +
                "<div class='tab-pane fade' id='grup_" + catClasificacion.Id + "' role='tabpanel'>" +
                    "<!-- Slide2 -->" +
                    "<div class='wrap-slick2'>" +
                        "<div class='slick2'>";
            }


            List<Models.Consultas.ArticuloConsulta> LisArticulos = _Articulo.Articulo_Selecionar_IdClasificacion(catClasificacion);

            foreach (var articulo in LisArticulos)
            {
                if (articulo.Articulo.Id > 0)
                {
                    total += 1;
                    uno = true;
                    header += "" +
                    "<div class='item-slick2 p-l-15 p-r-15 p-t-15 p-b-15'>" +
                        "<!-- Block2 --> " +
                        "<div class='block2'  onclick='ConsultaArticulo(" + articulo.Articulo.Id + ")'>" +
                            "<div class='block2-pic hov-img0'>" +
                            "<img src='http://" + articulo.ArticuloImagen.ImagenURL + "' alt='IMG-PRODUCT'>" +

                            //"<a href='#' onclick='VistaRapida(" + articulo.Articulo.Id + ")' class='block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04 js-show-modal1'>" +
                            //    "Vista rápida" +
                            //"</a>" +
                            "</div>" +

                            "<div class='block2-txt flex-w flex-t p-t-14 text-center'>" +
                                "<div class='block2-txt-child1  text-center'>" +
                                    "<a href='#' class='stext-104 cl4 hov-cl1 trans-04 js-name-b2 p-b-6''>" +
                                        //"<span class='block2-txt-child1-Sub'>" + articulo.Articulo_Detalle.Nombre + " </span>" +
                                        "<br />" +
                                        articulo.CatClasificacion.Nombre +
                                    "</a>" +
                                    "<div class='product-rating'>" +
                                        "<i class='fa fa-star'></i>" +
                                        "<i class='fa fa-star'></i>" +
                                        "<i class='fa fa-star'></i>" +
                                        "<i class='fa fa-star'></i>" +
                                        "<i class='fa fa-star'></i>" +
                                    "</div>" +
                                    "<hr />" +
                                    "<span class='stext-105 cl3'>" +
                                        "" + articulo.Articulo.PrecioText + "" +
                                    "</span>" +
                                    "<div class='product-label'>" +
                                    //"<span class='sale'>-30%</span>" +
                                    //"<span class='new'>NEW</span>" +
                                    "</div>" +
                                    "<div class='product-btns'>" +
                                        "<button class='add-to-wishlist' tabindex='0' onclick='AgregarInteres(" + articulo.Articulo.Id + ")'><i class='fa fa-heart-o'></i><span class='tooltipp'>Añadir interes</span></button>" +
                                    //"<button class='add-to-compare' tabindex='0' onclick='AgregarComparar(" + inmueble.Id + ")'><i class='fa fa-shopping-cart'></i><span class='tooltipp'>Agregar al carrito </span></button>" +
                                    //"<button class='quick-view js-show-modal1' tabindex='0' onclick='VistaRapida(" + articulo.Articulo.Id + ")'><i class='fa fa-eye'></i><span class='tooltipp'>Vista rápida</span></button>" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +

                        "</div>" +
                    "</div>";

                }
                else
                {
                    uno = false;
                }
            }

            header += "</div>" +
                    "</div>" +
                "</div>";


            if (uno)
            {
                Contenido += header;
            }
            else
            {
                a = 0;
            }

            return Contenido;
        }














        public List<Models.Articulo> Articulo_Listar()
        {
            return _Articulo.Articulo_Listar();
        }

        //public Models.Consultas.ArticuloConsulta Articulo_Selecionar_IdArticulo(Models.Articulo articulo) 
        //{
        //    Models.Consultas.ArticuloConsulta articuloConsulta = _Articulo.Articulo_Selecionar_IdArticulo(articulo);

        //    decimal Precio = 0;
        //    Precio += Convert.ToDecimal(articuloConsulta.Articulo.PrecioPublico);
        //    string Total = string.Format("{0:N2}", Precio); 
        //    articuloConsulta.Articulo.PrecioPublico = Total;

        //    return articuloConsulta;
        //}

        

        
    }
}
