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
		try (PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(insertSql)) {
			preparedStatement.setObject(1, categoria.getNombre());
			return preparedStatement.executeUpdate();
		}
	}
	private static String updateSql = "update categoria set nombre=? where id=?";
	public static int update(Categoria categoria) throws SQLException {
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(updateSql);
		preparedStatement.setObject(1, categoria.getNombre());
		preparedStatement.setObject(2, categoria.getId());
		int rows = preparedStatement.executeUpdate();
		preparedStatement.close();
		return rows;
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
				
		if(!rs.next()) {
			return null;
		}
		categoria.setId(rs.getLong(1));
		categoria.setNombre((String)rs.getObject(2));
		preparedStatement.close();
		return categoria;
	}
	private static String deleteSql = "delete from categoria where id=?";
	public static int delete(long id) throws SQLException {
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(deleteSql);
		preparedStatement.setLong(1, id);
		int rows = preparedStatement.executeUpdate();
		preparedStatement.close();
		return rows;
		
	}
	private static String selectAllSql = "select id, nombre from categoria";
	public static List<Categoria> getAll() throws SQLException{
		List<Categoria> categorias = new ArrayList<Categoria>();
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(selectAllSql);
		ResultSet rs = preparedStatement.executeQuery();
		while(rs.next()) {
			Categoria categoria = new Categoria();
			categoria.setId(rs.getLong(1));
			categoria.setNombre((String) rs.getObject(2));
			categorias.add(categoria);
		}
		preparedStatement.close();
		return categorias;
	}
}
