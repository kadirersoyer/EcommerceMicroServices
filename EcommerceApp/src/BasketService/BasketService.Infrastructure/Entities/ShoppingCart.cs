namespace BasketService.Infrastructure.Entities
{
    public class ShoppingCart
    {
        public string? UserName { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
        public ShoppingCart()
        {
        }

        public ShoppingCart(string userName)
        {
            this.UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                ShoppingCartItems.ForEach(m =>
                {
                    totalPrice += (m.Price * m.Quantity);
                });

                return totalPrice;
            }
        }

        internal Task ToConvertToString<T>(T shoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}
