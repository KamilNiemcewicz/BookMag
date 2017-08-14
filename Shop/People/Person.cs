using Shop.Book;

namespace Shop.People
{
    public abstract class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string DeathDate { get; set; }
        public string DeathPlace { get; set; }
        public string Sex { get; set; }
        public string Website { get; set; }

        protected Person(int personId, string name, string surname, string birthDate, string birthPlace, string deathDate, string deathPlace, string sex, string website)
        {
            PersonId = personId;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            DeathDate = deathDate;
            DeathPlace = deathPlace;
            Sex = sex;
            Website = website;
        }

        public abstract void AddBook(BookBase book);
    }
}
