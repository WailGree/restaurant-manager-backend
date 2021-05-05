using System.Collections.Generic;

namespace EFDataAccess.Models
{
    public interface IMenuRepository
    {
        MenuItem getMenuItem(int id);
        IEnumerable<MenuItem> GetMenu();
        MenuItem addMenuItem(MenuItem menuItem);
        MenuItem updateMenuItem(MenuItem menuItemChanges);
        MenuItem DeleteMenuItem(int id);
    }
}