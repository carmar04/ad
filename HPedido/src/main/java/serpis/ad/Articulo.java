package serpis.ad;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;


@Entity(name = "Articulo")
public class Articulo {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	Long id;
	String nombre;
	double precio;
	
	@ManyToOne
	@JoinColumn(name = "categoria", 
			foreignKey = ForeignKey(name = "CATEGORIA_ID_FK"))
	Categoria categoria;
}
