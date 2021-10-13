using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarWashAggregator.Files.Domain.Models
{
    public class FileModel
    {
		[Key]
		public Guid Id { get; set; }

		[StringLength(255)]
		public string FileName { get; set; }
		public string ContentType { get; set; }
		public byte[] Content { get; set; }
		public int ContentLength { get; set; }
	}
}