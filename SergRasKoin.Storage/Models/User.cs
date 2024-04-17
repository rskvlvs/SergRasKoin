using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRasKoin.Storage.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Surname { get; set; }

        [Required, MaxLength(255)]
        public string Email { get; set; }

        [InverseProperty(nameof(Sales.User))]
        public virtual ICollection<Sales> Sale { get; set; }
    }
}
