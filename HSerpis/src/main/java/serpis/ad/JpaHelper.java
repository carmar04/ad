package serpis.ad;

import java.util.function.Consumer;
import java.util.function.Function;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;

public class JpaHelper {
	
	
    public static void execute(Consumer<EntityManager> consumer) {
    	doInJPA(App.getInstance().getEntityManagerFactory(), consumer);
    }
    
    public static <R> R execute(Function<EntityManager, R> function ) {
    	return doInJPA(App.getInstance().getEntityManagerFactory(), function);
    }
    
    public static void doInJPA(EntityManagerFactory entityManagerFactory, Consumer<EntityManager>consumer) {
        EntityManager entityManager = entityManagerFactory.createEntityManager();
        entityManager.getTransaction().begin();
        consumer.accept(entityManager);
        entityManager.getTransaction().commit();
        entityManager.close();
        
    }
    
    public static <R> R doInJPA(EntityManagerFactory entityManagerFactory, Function <EntityManager, R> function) {
        EntityManager entityManager = entityManagerFactory.createEntityManager();
        entityManager.getTransaction().begin();
        R result = function.apply(entityManager);
        entityManager.getTransaction().commit();
        entityManager.close();
        return result;
        
    }
}
