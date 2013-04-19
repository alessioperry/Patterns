using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests.Test
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        Code.LogAnalyzer sut;

        [SetUp]
        public void Setup()
        {
            sut = new Code.LogAnalyzer();
        }

        [Test]
        public void IsValidFileName__Should_return_true__if_extension_is_valid_but_Ucase()
        {
            //act
            bool result = sut.IsValidLogFileName("whatever.SLF");
            //assert
            Assert.IsTrue(result, "filename should be valid!");
        }

        [Test]
        public void IsValidFileName__Should_return_true__if_extension_is_Lcase()
        {
            //act
            bool result = sut.IsValidLogFileName("whatever.slf");
            //assert
            Assert.IsTrue(result, "filename should be valid!");
        }

        [Test]
        public void IsValidFileName__Should_return_false__if_extension_is_invalid()
        {
            //act
            bool result = sut.IsValidLogFileName("whatever.sf");
            //assert
            Assert.IsFalse(result, "filename should be valid!");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Invalid file name")]
        public void IsValidFileName__Should_throw_excption__if_filename_is_empty()
        {
            sut.IsValidLogFileName(string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Invalid file name")]
        public void IsValidFileName__Should_throw_excption__if_filename_is_blank_space()
        {
            sut.IsValidLogFileName(" ");
        }

        //[Test]
        //public void IsValidFileName__Should_throw_excption__if_filename_is_blank_space_version_II()
        //{
        //    Assert.Throws<ArgumentException>(x => sut.IsValidLogFileName(" "));
        //}

        [Test]
        public void IsValidLogFileName__waslastnameproperty_be_ture__if_last_file_name_is_good()
        {
            Code.LogAnalyzer log = new Code.LogAnalyzer();
            log.IsValidLogFileName("somefile.slf");
            Assert.IsTrue(log.WasLastFileNameValid);
        }

        [TearDown]
        public void Teardown()
        {
            sut = null;
        }
    }
}
