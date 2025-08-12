namespace ClassLibrary1
{
    public class Employee
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Salary { get; set; }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18 || value > 60)
                    throw new ArgumentOutOfRangeException("Age must be between 18 and 60.");
                age = value;
            }
        }

        public string DisplayData()
        {
            return $"Employee Info:\nID: {ID}\nName: {Name}\nAge: {Age}\nSalary: {Salary}";
        }
    }
}
