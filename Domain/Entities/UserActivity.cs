using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserActivity
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime DateOfAction { get; set; }
    }
}