
// This file has been generated by the GUI designer. Do not modify.
namespace CArticulo
{
	public partial class ArticuloWindow
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.VBox vbox4;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label Nombre;

		private global::Gtk.Entry entry3;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Label label4;

		private global::Gtk.SpinButton spinbutton1;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Label label5;

		private global::Gtk.ComboBox combobox1;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Button button4;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget CArticulo.ArticuloWindow
			this.Name = "CArticulo.ArticuloWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("ArticuloWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child CArticulo.ArticuloWindow.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.Nombre = new global::Gtk.Label();
			this.Nombre.Name = "Nombre";
			this.Nombre.LabelProp = global::Mono.Unix.Catalog.GetString("Nombre");
			this.hbox3.Add(this.Nombre);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.Nombre]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.entry3 = new global::Gtk.Entry();
			this.entry3.CanFocus = true;
			this.entry3.Name = "entry3";
			this.entry3.IsEditable = true;
			this.entry3.InvisibleChar = '•';
			this.hbox3.Add(this.entry3);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.entry3]));
			w2.Position = 1;
			this.vbox4.Add(this.hbox3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox3]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Precio");
			this.hbox4.Add(this.label4);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label4]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.spinbutton1 = new global::Gtk.SpinButton(0D, 100D, 1D);
			this.spinbutton1.CanFocus = true;
			this.spinbutton1.Name = "spinbutton1";
			this.spinbutton1.Adjustment.PageIncrement = 10D;
			this.spinbutton1.ClimbRate = 1D;
			this.spinbutton1.Numeric = true;
			this.hbox4.Add(this.spinbutton1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.spinbutton1]));
			w5.Position = 1;
			this.vbox4.Add(this.hbox4);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox4]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Categoria");
			this.hbox5.Add(this.label5);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label5]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.combobox1 = global::Gtk.ComboBox.NewText();
			this.combobox1.Name = "combobox1";
			this.hbox5.Add(this.combobox1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.combobox1]));
			w8.Position = 1;
			this.vbox4.Add(this.hbox5);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox5]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			this.vbox2.Add(this.vbox4);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox4]));
			w10.Position = 0;
			w10.Expand = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.button4 = new global::Gtk.Button();
			this.button4.CanFocus = true;
			this.button4.Name = "button4";
			this.button4.UseUnderline = true;
			this.button4.Label = global::Mono.Unix.Catalog.GetString("Guardar");
			this.hbox6.Add(this.button4);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.button4]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			this.vbox2.Add(this.hbox6);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox6]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 405;
			this.DefaultHeight = 300;
			this.Show();
		}
	}
}
