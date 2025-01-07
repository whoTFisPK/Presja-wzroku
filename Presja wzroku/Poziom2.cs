namespace Presja_wzroku
{
    public partial class Poziom2 : BaseLevel
    {
        protected override int WaldoPosX => 771;
        protected override int WaldoPosY => 382;
        protected override int WaldoWidth => 20;
        protected override int WaldoHeight => 50;
        protected override string BackgroundImageResource => "background2"; 

        public Poziom2(MainForm parent) : base(parent) { }

        protected override void StartGame()
        {
            parent.ShowTimer(30); 
        }

        protected override Panel NextLevel()
        {
            return new Poziom3(parent); 
        }
    }
}
