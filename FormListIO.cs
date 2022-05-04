using System.Text;

namespace WinAppListIO
{
    public partial class FormListIO : Form
    {
        public FormListIO()
        {
            InitializeComponent();
        }
        List<Emp> AceEmp = new List<Emp>();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Emp newEmp = new Emp();
            newEmp.setName(textBoxName.Text);
            newEmp.setPhone(textBoxPhone.Text);
            newEmp.setPosition(textBoxPosition.Text);
            AceEmp.Add(newEmp);
            clearTextbox();
            displayEmployees();
        }
        private void clearTextbox()
        {
            textBoxName.Clear();
            textBoxPhone.Clear();
            textBoxPosition.Clear();
        }
        private void displayEmployees()
        {
            listBoxEmployees.Items.Clear();
            foreach(var emp in AceEmp)
            {
                listBoxEmployees.Items.Add(emp.displayOneEmp());
            }
        }
        private void listBoxEmployees_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBoxEmployees.SelectedIndex == -1)
            {
                MessageBox.Show("Select a record from the List Box");
            }
            else
            {
                string curItem = listBoxEmployees.SelectedItem.ToString();
                int indx = listBoxEmployees.FindString(curItem);
                listBoxEmployees.SetSelected(indx, true);
                textBoxName.Text = AceEmp[indx].getName();
                textBoxPhone.Text = AceEmp[indx].getPhone();
                textBoxPosition.Text = AceEmp[indx].getPosition();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var stream = File.Open("employee.dat", FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    foreach(var x in AceEmp)
                    {
                        writer.Write(x.getName());
                        writer.Write(x.getPhone());
                        writer.Write(x.getPosition());
                    }
                }
            }
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists("employee.dat"))
            {
                using (var stream = File.Open("employee.dat", FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        AceEmp.Clear();                     
                        while (stream.Position < stream.Length)
                        {
                            Emp readEmp = new Emp();
                            readEmp.setName(reader.ReadString());
                            readEmp.setPhone(reader.ReadString());
                            readEmp.setPosition(reader.ReadString());
                            AceEmp.Add(readEmp);
                        }
                    }
                }
                displayEmployees();
            }
        }
    }
}