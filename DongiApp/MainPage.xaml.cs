namespace DongiApp
{
    public partial class MainPage : ContentPage
    {
        decimal bill = 0;
        int tip;
        int numberOfPeople = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Txtbill_Completed(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(txtbill.Text))
            {
                bill = 0;
            }
            else if (decimal.TryParse(txtbill.Text, out bill))
            {
                Calculate(); // فقط وقتی عدد معتبر بود
            }
            else
            {
                bill = 0; // اگه عدد نامعتبر بود مثل "abcd"
            }


        }
        private string FormatPrice(decimal amount)
        {
            if (amount >= 1_000_000_000)
                return $"{(amount / 1_000_000_000):0.##} میلیارد تومان";
            else if (amount >= 1_000_000)
                return $"{(amount / 1_000_000):0.##} میلیون تومان";
            else if (amount >= 1_000)
                return $"{(amount / 1_000):0.##} هزار تومان";
            else
                return $"{amount:0} تومان";
        }
        private void Calculate()
        {
            var totaltip = (tip * bill) / 100;
            var tipperperson = (totaltip / numberOfPeople);
            lbltipperson.Text = FormatPrice(tipperperson);

            var subtotal = (bill / numberOfPeople);
            lblsubtotal.Text = FormatPrice(subtotal);

            var total = (bill / numberOfPeople + tipperperson);
            lbltotal.Text = FormatPrice(total);
        }



        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sldTip.Value;
            lbltip.Text = $"انعام :{tip}%";
            Calculate();
        }

        private void Minus_Clicked(object sender, EventArgs e)
        {
            if (numberOfPeople > 1)
            {
                numberOfPeople--;
            }
            txtnumperson.Text = numberOfPeople.ToString();
            Calculate();
        }

        private void Highnus_Clicked(object sender, EventArgs e)
        {
            numberOfPeople++;
            txtnumperson.Text = numberOfPeople.ToString();
            Calculate();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            var percentags = int.Parse(btn.Text.Replace("%", ""));

            sldTip.Value = percentags;
        }
    }

}
