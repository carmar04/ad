package serpis.ad;

import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class CategoriaDao {
	private static String insertSql = "insert into categoria (nombre) values (?)";
	public static int insert(Categoria categoria) throws SQLException {
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(insertSql);
		preparedStatement.setObject(1, categoria.getNombre());
		return preparedStatement.executeUpdate();
	}
	private static String updateSql = "update categoria set nombre=? where id=?";
	public static int update(Categoria categoria) throws SQLException {
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(updateSql);
		preparedStatement.setObject(1, categoria.getNombre());
		preparedStatement.setObject(2, categoria.getId());
		return preparedStatement.executeUpdate();
	}
	public static int save(Categoria categoria) throws SQLException {
		if(categoria.getId() == 0) {
			return insert(categoria);
		}else {
			return update(categoria);
		}
	}
	private static String selectSql = "select id, nombre from categoria where id=?";
	public static Categoria load(long id) throws SQLException {
		Categoria categoria = new Categoria();
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(selectSql);
		preparedStatement.setObject(1, id);
		ResultSet rs = preparedStatement.executeQuery();
		rs.next();
		categoria.setId((long)rs.getObject(1));
		categoria.setNombre((String)rs.getObject(2));
		
		return categoria;
		
	}
	private static String deleteSql = "delete from categoria where id=?";
	public static int delete(long id) throws SQLException {
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(deleteSql);
		preparedStatement.setObject(1, id);
		return preparedStatement.executeUpdate();
		
	}
	private static String selectAllSql = "select * from categoria";
	public static List<Categoria> getAll() throws SQLException{
		List<Categoria> categorias = new ArrayList<Categoria>();
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(selectAllSql);
		ResultSet rs = preparedStatement.executeQuery();
		int iterador = 0; 
		while(rs.next()) {
			categorias.add(new Categoria());
			categorias.get(iterador).setId((long)rs.getObject(1));
			categorias.get(iterador).setNombre((String)rs.getString(2));
			iterador++;
		}
		return categorias;
	}
}
