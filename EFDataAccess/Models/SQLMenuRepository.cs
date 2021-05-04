using System.Collections.Generic;
using EFDataAccess.DataAccess;

namespace EFDataAccess.Models
{
    public class SQLMenuRepository :IMenuRepository
    {
        private readonly RestaurantContext _context;

        public SQLMenuRepository(RestaurantContext context)
        {
            _context = context;
        }

        public MenuItem getMenuItem(int id)
        {
            return _context.Menu.Find(id);
        }

        public IEnumerable<MenuItem> GetMenu()
        {
            return _context.Menu;
        }

        public MenuItem addMenuItem(MenuItem menuItem)
        {
            _context.Menu.Add(menuItem);
            _context.SaveChanges();
            return menuItem;
        }

        public MenuItem updateMenuItem(MenuItem menuItemChanges)
        {
            var menuItem = _context.Menu.Attach(menuItemChanges);
            menuItem.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return menuItemChanges;
        }

        public MenuItem DeleteMenuItem(int id)
        {
            MenuItem menu = _context.Menu.Find(id);
            if (menu != null)
            {
                _context.Menu.Remove(menu);
                _context.SaveChanges();
            }

            return menu;
        }
    }
}