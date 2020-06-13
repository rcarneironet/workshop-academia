using Academia.Store.Domain.Contexts.ValueObjects;
using NUnit.Framework;

namespace Academia.Store.Tests.ValueObjectsTests
{
    public class CpfVoTests
    {

        private CpfVo _cpfValido;
        private CpfVo _cpfInvalido;

        [SetUp]
        public void Setup()
        {
            _cpfValido = new CpfVo("15366015006");
            _cpfInvalido = new CpfVo("123456789011");
        }

        [Test]
        public void CpfVoTests_IsValid_ReturnTrue()
        {
            Assert.AreEqual(true, _cpfValido.IsValid);
        }

        [Test]
        public void CpfVoTests_IsValid_ReturnFalse()
        {
            Assert.AreEqual(true, _cpfInvalido.Invalid);
        }

    }
}
