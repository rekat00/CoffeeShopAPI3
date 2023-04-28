using CoffeeShopAPI3.Model;

namespace CoffeeShopAPI3.Repository.Interface
{
    public interface IMenuRepository
    {
        public Task<int> Insert(MenuModel Menu);
        public Task<bool> Update(MenuModel Menu, int id);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<MenuModel>> SelectAll();
        public Task<MenuModel> SelectById(int id);
    }
}
