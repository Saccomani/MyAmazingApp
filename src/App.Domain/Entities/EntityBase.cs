using SQLite;
using System.ComponentModel;

namespace App.Domain.Entities
{
	public abstract class EntityBase
	{
		public string Id { get; private set; }
		
		[Ignore]
		public Dictionary<string, string> ValidationResult { get; set; }

		public void SetId(string id) => Id = id;
		protected EntityBase()
		{
			Id = Guid.NewGuid().ToString();
			ValidationResult = new Dictionary<string, string>();
		}

		public override string ToString()
			=> string.Join('\n', ValidationResult);

		public bool IsValid { get; set; }

		public abstract void Validate();
	}
}
