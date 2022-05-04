namespace WinAppListIO
{
    internal class Emp
    {
        private string name;
        private string phone;
        private string position;
        public Emp() { }
        public Emp(string newName, string newPhone, string newPosition)
        {
            name = newName;
            phone = newPhone;
            position = newPosition;
        }
        public void setName(string newName)
        {
            name = newName;
        }
        public string getName()
        {
            return name;
        }
        public void setPhone(string newPhone)
        {
            phone = newPhone;
        }
        public string getPhone()
        {
            return phone;
        }
        public void setPosition(string newPosition)
        {
            position = newPosition;
        }
        public string getPosition()
        {
            return position;
        }
        public string displayOneEmp()
        {
            return getName() + "\t: " + getPhone();
        }
    }
}
