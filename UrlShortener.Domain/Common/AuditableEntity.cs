namespace UrlShortener.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}