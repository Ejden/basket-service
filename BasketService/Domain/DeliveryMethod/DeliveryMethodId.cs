namespace BasketService.Domain.DeliveryMethod
{
    public record DeliveryMethodId(string Raw)
    {
        public static DeliveryMethodId Of(string raw)
        {
            return new DeliveryMethodId(raw);
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
        public virtual bool Equals(DeliveryMethodId? other)
        {
            if (other == null) return false;
            return Raw == other.Raw;
        }
        #nullable disable
    }
}
