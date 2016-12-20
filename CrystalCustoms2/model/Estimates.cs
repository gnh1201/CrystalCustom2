using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class Estimates
    {
        public int Id { get; set; }
        public string ReptName { get; set; }
        public string ReptTel { get; set; }
        public string ReptFax { get; set; }
        public string ReptOwn { get; set; }
        public string ReptAddress { get; set; }
        public string ReptDate { get; set; }
        public string ReptNo { get; set; }
        public string SendName { get; set; }
        public string SendAddress { get; set; }
        public string SendTel { get; set; }
        public string SendFax { get; set; }
        public string SendDeadline { get; set; }
        public string SendOwn { get; set; }
        public string SalesOwn { get; set; }
        public string ShipDate { get; set; }
        public string ShipType { get; set; }
        public string DeliveryPoint { get; set; }
        public string PayCond { get; set; }
        public string TaxRate { get; set; }
        public List<EstimateItems> Items { get; set; }
        public string Amount { get; set; }
    }
}
