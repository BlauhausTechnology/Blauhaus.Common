using Blauhaus.Common.Utils.NotifyPropertyChanged;

namespace Blauhaus.Common.Tests.Tests.BindableObjectTests.Sut
{
    public class TestBindableObject : BaseBindableObject
    { 

        public TestBindableObject(int intialIncrementValue = 0)
        {
            InitiazeValue(nameof(CountMe), intialIncrementValue);
            InitiazeValue(nameof(CountMeWithSideEffect), intialIncrementValue);
        }

        public int CountMe
        {
            get => GetProperty<int>();
            set => SetProperty(value);
        }
        
        public int CountMeWithSideEffect
        {
            get => GetProperty<int>();
            set => SetProperty(value, () => SideEffect = value);
        }

        public int SideEffect
        {
            get => GetProperty<int>();
            set => SetProperty(value);
        }


    }
}