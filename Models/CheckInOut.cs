using System;
using System.ComponentModel.DataAnnotations;

namespace internscheckInOut.Models
{
	public class CheckInOut
	{
		[Key]

		public Guid Id { get; set; }
		public string internName { get; set; }
		public int positionId { get; set; }
		public int teamId { get; set; }
		public string date { get; set; }
		public string checkinTime { get; set; }
		public string checkoutTime { get; set; }

	}
}

