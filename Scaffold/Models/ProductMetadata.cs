using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scaffold.Models
{
	[MetadataType(typeof(Product.Metadata))]
	public partial class Product
	{
		// a class inside a class. sealed=can't be extended 
		sealed class Metadata
		{
			[Key]
			public System.Guid Product { get; set; }

			// insert this to get message when fields are not met:
			// (ErrorMessage ="This is a custom message!")
			[Required(ErrorMessage ="This is a custom message!")]
			[Display(Name = "Product Name")]
			[StringLength(10)]
			public string Name { get; set; }

			[Required]
			[RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
			[Range(0.01,1000.0)]
			public decimal Price{get;set;}
		}
	}
}