using System;

namespace Challenge2
{
    public class Media : BaseEntity
    {
        // Atributos
		private Genres Genres { get; set; }
		private string Title { get; set; }
        private string Type { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
        private bool Deleted {get; set;}

        // Métodos
		public Media(int id, Genres genres, string type, string title, string description, int year)
		{
			this.Id = id;
			this.Genres = genres;
            this.Type = type;
			this.Title = title;
			this.Description = description;
			this.Year = year;
            this.Deleted = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Genres: " + this.Genres + Environment.NewLine;
            retorno += "Type: " + this.Type + Environment.NewLine;
            retorno += "Title: " + this.Title + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Year: " + this.Year + Environment.NewLine;
            retorno += "Deleted: " + this.Deleted;
			return retorno;
		}

        public string returnTitle()
		{
			return this.Title;
		}

		public int returnId()
		{
			return this.Id;
		}
        public bool returnDeleted()
		{
			return this.Deleted;
		}
        public void ToDelete() {
            this.Deleted = true;
        }
    }
}