namespace Presja_wzroku
{
    public partial class Tutorial : BaseLevel
    {
        protected override int WaldoPosX => 503;
        protected override int WaldoPosY => 425;
        protected override int WaldoWidth => 223;
        protected override int WaldoHeight => 484;
        protected override string BackgroundImageResource => "Tutorial"; 

        public Tutorial(MainForm parent) : base(parent) { }

        protected override void StartGame()
        {
            parent.ShowTimer(30); 
        }

        protected override Panel NextLevel()
        {
            return new Poziom1(parent); 
        }
    }
}