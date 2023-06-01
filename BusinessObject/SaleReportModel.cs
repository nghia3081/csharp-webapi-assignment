using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SaleReportModel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TotalQuantitySale { get; set; }
        public decimal TotalMoneySale { get; set; }
    }
}
