package serpis.ad;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import org.hibernate.Hibernate;

import com.mysql.cj.Session;

public class PedidoMain {
	public static void main (String [] args) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.hmysql");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		//Articulo articulo = entityManager.find(Articulo.class, 1L);
		//show(articulo);
		
		List<Categoria> categorias = entityManager.createQuery("from Categoria", Categoria.class).getResultList();
		
		for(Categoria categoria : categorias){
			System.out.println("Ids: " + categoria.getId());
		}

		entityManager.getTransaction().commit();
		entityManager.close();
		
		entityManagerFactory.close();
		
		Articulo articulo = articuloNuevo();
		eliminarArticulo(articulo);
	}
	public static void show(Articulo articulo) {
		System.out.printf("%4s %-30s %-30s %s %n",articulo.getId(), articulo.getNombre(), articulo.getCategoria(), articulo.getPrecio());
	}
	
	public static Articulo articuloNuevo() {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.hmysql");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		
		Articulo articulo = new Articulo();
		articulo.setNombre("Articulo prueba" + LocalDateTime.now());
		articulo.setPrecio(BigDecimal.valueOf(1));
		articulo.setCategoria(entityManager.getReference(Categoria.class, 2L));
		entityManager.persist(articulo);
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
		entityManagerFactory.close();
		
		return articulo;

	}
	public static void eliminarArticulo(Articulo articulo) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.hmysql");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		articulo = entityManager.find(Articulo.class, articulo.getId());
		entityManager.remove(articulo);
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
		entityManagerFactory.close();
		
	}
}
