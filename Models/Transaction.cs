using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServicesLab1.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SourceAccNumber { get; set; }

        [Required]
        public string Operation { get; set; } // "Transfer", "Deposit", or "Withdraw"

        [Required]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(BankAccount))]
        public int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }


    
    }

}
