namespace Playground
{
    partial class PartialDemo
    {

        private string firstName;
        private string lastName;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public string FullName()
        {
            return firstName + " " + lastName;
        }
    }
}
