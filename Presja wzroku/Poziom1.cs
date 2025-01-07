namespace Presja_wzroku
{
    public partial class Poziom1 : BaseLevel
    {
        protected override int WaldoPosX => 1066;
        protected override int WaldoPosY => 699;
        protected override int WaldoWidth => 28;
        protected override int WaldoHeight => 60;
        protected override string BackgroundImageResource => "background1"; 

        public Poziom1(MainForm parent) : base(parent) { }

        protected override void StartGame()
        {
            parent.ShowTimer(30); 
        }

        protected override Panel NextLevel()
        {
            return new Poziom2(parent); 
        }
    }
}
