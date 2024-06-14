namespace Library.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    IPostCategoryRepository PostCategory { get; }
    IPostRepository Post { get; }
    IBookCategoryRepository BookCategory { get; }
    IBookRepository Book { get; }
    IBookImageRepository BookImage { get; }
    IOrderHeaderRepository OrderHeader { get; }
    IShoppingCartRepository ShoppingCart { get; }
    IOrderDetailRepository OrderDetail { get; }
    IApplicationUserRepository ApplicationUser { get; }

    void Save();
}
