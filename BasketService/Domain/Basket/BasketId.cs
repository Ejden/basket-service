namespace BasketService.Domain.Basket
{
    public record BasketId(string Raw)
    {
        public static BasketId Of(string raw)
        {
            return new BasketId(raw);
        }

        public override int GetHashCode()
        {
            return Raw.GetHashCode();
        }

        public override string ToString()
        {
            return Raw;
        }

        public virtual bool Equals(BasketId? other)
        {
            if (other == null) return false;
            return Raw == other.Raw;
        }
    }
}
