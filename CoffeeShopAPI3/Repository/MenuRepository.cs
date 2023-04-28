using CoffeeShopAPI3.Model;
using CoffeeShopAPI3.Repository.Interface;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CoffeeShopAPI3.Repository
{
    public class MenuRepository:IMenuRepository
    {
        private string? _connection;
        public MenuRepository(IConfiguration configuration) 
        {
            _connection = configuration.GetConnectionString("MenuContext");        
        }

        public async Task<int> Insert(MenuModel menu)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var result = await connection.QueryAsync("INSERT INTO CoffeeShopTable " +
                    "(Name,Price,Stock, Code )" +
                  " VALUES(@name,@price,@stock,@code)", menu);
                return 1;
            }
        }

        public async Task<bool> Update(MenuModel menu, int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                await connection.ExecuteAsync("UPDATE CoffeeShopTable SET Name = @name," +
                    " Price = @price, Stock = @stock," +
                    " Code = @code WHERE id = "+id , menu);
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                await connection.QueryAsync("DELETE FROM CoffeeShopTable Where id = @id", new { Id = id });
            }
            return true;
        }
        public async Task<IEnumerable<MenuModel>> SelectAll()
        {
            using (var connection = new SqlConnection(_connection))
            {
                var CoffeeShop = await connection.QueryAsync<MenuModel>("SELECT * FROM CoffeeShopTable");
                return CoffeeShop;
            }
        }
        public async Task<MenuModel> SelectById(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var CoffeeShop = await connection.QueryFirstOrDefaultAsync<MenuModel>("SELECT * FROM CoffeeShopTable where id = @id", new {Id = id });

                return CoffeeShop;
            }
        }
    }
}
