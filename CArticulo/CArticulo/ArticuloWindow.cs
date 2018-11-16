using System;
using CArticulo;
using Serpis.Ad;
using Serpis.Ad.Ventas;

namespace CArticulo
{
    public partial class ArticuloWindow : Gtk.Window
    {
		public ArticuloWindow(Articulo cArticulo) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
