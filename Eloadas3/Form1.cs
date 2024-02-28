namespace Eloadas3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random(1);

            MessageBox.Show(rnd.Next(100).ToString());
            string TimeZoneId = "Central European Strandard Time";
            TimeZoneInfo cetZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneId);
            DateTime cetTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);

            DateTime currentDateTime = DateTime.Now;
            DateTime midnight = currentDateTime.Date;
        }
    }
}
