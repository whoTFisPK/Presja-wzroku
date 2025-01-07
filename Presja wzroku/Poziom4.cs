namespace Presja_wzroku
{
    public partial class Poziom4 : BaseLevel
    {
        protected override int WaldoPosX => 17;
        protected override int WaldoPosY => 57;
        protected override int WaldoWidth => 124;
        protected override int WaldoHeight => 870;
        protected override string BackgroundImageResource => "background4"; 

        public Poziom4(MainForm parent) : base(parent) { }

        protected override void StartGame()
        {
            parent.ShowTimer(30); 
        }

        protected override Panel NextLevel()
        {
            return new Menu(parent); 
        }
    }
}

