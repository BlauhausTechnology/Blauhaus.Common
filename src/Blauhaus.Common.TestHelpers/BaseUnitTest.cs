using AutoFixture;

namespace Blauhaus.Common.TestHelpers
{
    public abstract class BaseUnitTest<TSut> where TSut : class
    {
        protected IFixture MyFixture => _fixture ?? (_fixture = new Fixture());
        private IFixture _fixture;
        
        private TSut _sut;
        protected TSut Sut => _sut ?? (_sut = ConstructSut());
        protected abstract TSut ConstructSut();


        protected void Cleanup()
        {
            _sut = null;
            _fixture = null;
        }
    }
}