namespace BasketService.Domain.Order
{
    public record OrderId(string Raw)
    {
        public static OrderId Of(string raw)
        {
            return new OrderId(raw);
        }
        
        public override int GetHashCode()
        {
            return Raw.GetHashCode();
        }

        public override string ToString()
        {
            return Raw;
        }

        #nullable enable
        public virtual bool Equals(OrderId? other)
        {
            if (other == null) return false;
            return Raw == other.Raw;
        }
        #nullable disable
    }
}
