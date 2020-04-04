using System;
using System.ComponentModel.DataAnnotations;
using CleanArchitectureSample.Domain.Common;

namespace CleanArchitectureSample.Domain.Entities
{
    public class User : AuditEntity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
