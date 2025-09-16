

namespace PerfectPay
{
    public partial class MainPage : ContentPage
    {

        private decimal bill;
        private int tip;
        private int noPersons = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void txtBill_Completed(object sender, EventArgs e)
        {
            //bill = decimal.Parse(txtBill.Text);
            if (!decimal.TryParse(txtBill.Text, out bill))     
            {
                // Manejo del caso cuando la conversión falla (por ejemplo, mostrar un mensaje o dejar en 0)
                bill = 0;
            }


            CalculateTotal();
        }

 

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip= (int)sldTip.Value;
            lblTip.Text = $"Tip: {tip}%";
            CalculateTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button) { 
                var btn = (Button)sender;
                var percentage = int.Parse(btn.Text.Replace("%", ""));
                sldTip.Value = percentage;
            }

        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if(noPersons > 1)
                noPersons--;

            lblNoPersons.Text = noPersons.ToString();
            CalculateTotal();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            noPersons++;
            lblNoPersons.Text = noPersons.ToString();
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            var totalTip = (bill * tip) / 100;

            var tipByPerson = totalTip / noPersons;
            lblTipByPerson.Text = $"Tip by person: {tipByPerson:C}";

            var subTotal = bill / noPersons;
            lblSubtotal.Text = $"Subtotal: {subTotal:C}";

            var totalByPerson = (bill + totalTip) / noPersons;
            lblTotal.Text = $"T: {totalByPerson:C}";
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://github.com/rbrenesr/edu-.Net-MAUI-CSharp"));
        }
    }

}
