namespace App.Domain.Entities
{
	public class Product : EntityBase
	{
        public string Descripton { get; set; }

		public decimal Price { get; set; }

        public override void Validate()
		{
			if (string.IsNullOrEmpty(Descripton))
			{
				ValidationResult.Add(nameof(Descripton), "A Descrição do produto não pode ser vazia");
			}
			else
			{
				if (Descripton.Length < 10)
					ValidationResult.Add("Descrição produto", "A Descrição deve conter pelo menos 10 caracteres");
			}
			

			if (Price < 10 || Price > 100)
				ValidationResult.Add(nameof(Price), "O Preço do produto precisa estar entre R$ 10 até R$ 100");

			IsValid = ValidationResult.Count() == 0;
		}
	}
}
