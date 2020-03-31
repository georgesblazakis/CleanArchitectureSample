using System;
namespace CleanArchitectureSample.Domain.Common
{
    public class AuditEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

        protected AuditEntity()
        {
        }
    }
}
