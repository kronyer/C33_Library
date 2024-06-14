using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;

namespace Library.DataAccess.Repository;

public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
{
    private LibraryDbContext _db;

    public ShoppingCartRepository(LibraryDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(ShoppingCart shoppingCart)
    {
        _db.ShoppingCarts.Update(shoppingCart);
    }
}
