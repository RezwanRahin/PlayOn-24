using System;

namespace RDLCDesign
{
	internal class OrderInfo
	{
		public int Id { get; set; }
        public string Item { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
		public int Quantity { get; set; }
		public decimal NetCost { get; set; }
	}
}
