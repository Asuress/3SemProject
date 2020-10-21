using WPF_Game.Source.Logic;

namespace WPF_Game.Source.Components
{
    public class SizeChangedEventArgs
    {
        public SizeChangedEventArgs(Size oldSize, Size newSize)
        {
            OldSize = oldSize;
            NewSize = newSize;
        }
        public Size OldSize { get; }
        public Size NewSize { get; }
    }
}