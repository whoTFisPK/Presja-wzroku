namespace Presja_wzroku
{
    public partial class Poziom3 : BaseLevel
    {
        protected override int WaldoPosX => 621;
        protected override int WaldoPosY => 49;
        protected override int WaldoWidth => 15;
        protected override int WaldoHeight => 50;
        protected override string BackgroundImageResource => "background3"; 

        public Poziom3(MainForm parent) : base(parent) { }

        protected override void StartGame()
        {
            parent.ShowTimer(30); 
        }

        protected override Panel NextLevel()
        {
            return new Poziom4(parent); 
        }
    }
}

