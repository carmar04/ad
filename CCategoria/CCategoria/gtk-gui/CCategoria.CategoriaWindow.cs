
// This file has been generated by the GUI designer. Do not modify.
namespace CCategoria
{
	public partial class CategoriaWindow
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HButtonBox hbuttonbox1;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Label Nombre;

		private global::Gtk.Entry entryNombre;

		private global::Gtk.HButtonBox hbuttonbox3;

		private global::Gtk.Button buttonSave;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget CCategoria.CategoriaWindow
			this.Name = "CCategoria.CategoriaWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("CategoriaWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child CCategoria.CategoriaWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbuttonbox1 = new global::Gtk.HButtonBox();
			this.hbuttonbox1.Name = "hbuttonbox1";
			this.vbox1.Add(this.hbuttonbox1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbuttonbox1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.Nombre = new global::Gtk.Label();
			this.Nombre.Name = "Nombre";
			this.Nombre.LabelProp = global::Mono.Unix.Catalog.GetString("Nombre");
			this.vbox2.Add(this.Nombre);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.Nombre]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.entryNombre = new global::Gtk.Entry();
			this.entryNombre.CanFocus = true;
			this.entryNombre.Name = "entryNombre";
			this.entryNombre.IsEditable = true;
			this.entryNombre.InvisibleChar = '•';
			this.vbox2.Add(this.entryNombre);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.entryNombre]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbuttonbox3 = new global::Gtk.HButtonBox();
			this.hbuttonbox3.Name = "hbuttonbox3";
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseStock = true;
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = "gtk-save";
			this.hbuttonbox3.Add(this.buttonSave);
			global::Gtk.ButtonBox.ButtonBoxChild w4 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3[this.buttonSave]));
			w4.Expand = false;
			w4.Fill = false;
			this.vbox2.Add(this.hbuttonbox3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbuttonbox3]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vbox2]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 375;
			this.DefaultHeight = 104;
			this.Show();
		}
	}
}