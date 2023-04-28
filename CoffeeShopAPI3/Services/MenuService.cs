using CoffeeShopAPI3.Model;
using CoffeeShopAPI3.Repository.Interface;
using CoffeeShopAPI3.Services.Interface;

namespace CoffeeShopAPI3.Services
{
    public class MenuService: IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public Task<int> Insert(MenuModel menu) { return _menuRepository.Insert(menu); }
        public Task<bool> Update(MenuModel menu, int id) { return _menuRepository.Update(menu,id); }
        public Task<bool> Delete(int id) { return _menuRepository.Delete(id); }
        public Task<IEnumerable<MenuModel>> SelectAll() { return _menuRepository.SelectAll(); }
        public Task<MenuModel> SelectById(int id) { return _menuRepository.SelectById(id); }
    }
}
