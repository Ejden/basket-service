namespace BasketService.Domain.Shared
{
    public record UserId(string Raw)
    {
        public static UserId Of(string raw)
        {
            return new UserId(raw);
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
        public virtual bool Equals(UserId? other)
        {
            if (other == null) return false;
            return Raw == other.Raw;
        }
        #nullable disable
    }
}