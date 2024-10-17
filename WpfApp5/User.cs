namespace WpfApp5
{
	class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public bool Academy { get; set; }
		public string City { get; set; }

		public User() { }
		public User(string name, string surname, string gender, bool academy, string city)
		{
			Name = name;
			Surname = surname;
			Gender = gender;
			Academy = academy;
			City = city;
		}

		public override string ToString()
		{
			return $"{Name} - {Surname} - {Gender} - {Academy} - {City}";
		}
	}
}
