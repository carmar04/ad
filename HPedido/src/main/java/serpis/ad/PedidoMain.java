package serpis.ad;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.List;
import java.util.function.Consumer;
import java.util.function.Function;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import org.hibernate.Hibernate;
import org.hibernate.cfg.JPAIndexHolder;

import serpis.ad.*;

import com.mysql.cj.Session;

public class PedidoMain {

	public static void main (String [] args) {
		
		App.getInstance().setEntityManagerFactory(Persistence.createEntityManagerFactory("serpis.ad.hmysql"));
		
		EntityManager entityManager = App.getInstance().getEntityManagerFactory().createEntityManager();
		
		//EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Articulo articulo = entityManager.find(Articulo.class, 1L);
		show(articulo);
		System.out.println("Articulo id: " + articulo.getId());
		System.out.println("Arituclo nombre: " + articulo.getNombre());
		
		List<Categoria> categorias = entityManager.createQuery("from Categoria", Categoria.class).getResultList();
		
		for(Categoria categoria : categorias){
			System.out.println("Ids: " + categoria.getId());
		}

		entityManager.getTransaction().commit();
		
		
		Articulo articulo2 = articuloNuevo();
		eliminarArticulo(articulo2);
		
		//actualizarCategoria();
		JpaHelper.doInJPA(App.getInstance().getEntityManagerFactory(), entityManager3 -> {
			Articulo articulo3 = entityManager.getReference(Articulo.class, articulo.getId());
			entityManager.remove(articulo2);
		});
		
		
		
		
		Articulo articulo3 = JpaHelper.doInJPA(App.getInstance().getEntityManagerFactory(), entityManager2 -> {
			return entityManager2.find(Articulo.class, 1L);
		});
		show(articulo3);
		//entityManagerFactory.close();
		
	}
	public static void show(Articulo articulo) {
		System.out.printf("%4s %-30s %-30s %s %n",articulo.getId(), articulo.getNombre(), articulo.getCategoria(), articulo.getPrecio());
	}
	
	public static Articulo articuloNuevo() {
		
		EntityManager entityManager = App.getInstance().getEntityManagerFactory().createEntityManager();
		entityManager.getTransaction().begin();
		
		Articulo articulo = new Articulo();
		articulo.setNombre("Articulo prueba" + LocalDateTime.now());
		articulo.setPrecio(BigDecimal.valueOf(1));
		articulo.setCategoria(entityManager.getReference(Categoria.class, 2L));
		entityManager.persist(articulo);
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
		return articulo;

	}
	public static void eliminarArticulo(Articulo articulo) {
		
		EntityManager entityManager = App.getInstance().getEntityManagerFactory().createEntityManager();
		entityManager.getTransaction().begin();
		
		articulo = entityManager.find(Articulo.class, articulo.getId());
		entityManager.remove(articulo);
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
	
	
	public static void actualizarCategoria() {
		EntityManager entityManager = App.getInstance().getEntityManagerFactory().createEntityManager();
		entityManager.getTransaction().begin();
		
		Articulo articulo = new Articulo();
		articulo.setId((long) 1);
		articulo = entityManager.find(Articulo.class, articulo.getId());
		
		articulo.setId((long) 23);
		entityManager.getTransaction().commit();
		entityManager.close();

	}
}
