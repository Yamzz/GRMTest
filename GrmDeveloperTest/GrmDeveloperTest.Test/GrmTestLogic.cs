using GrmDeveloperTest.FileReader;
using GrmDeveloperTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace GrmDeveloperTest.Test
{
    [TestClass]
    public class GrmTestLogic
    {

        [TestMethod]
        public void TestScenario_WhenUserEntersITunes1stMarch2012()
        {
            var inputFileReaderMock = new Mock<IInputFileReader>();
            var input = "ITunes 1st March 2012";

            inputFileReaderMock.Setup(x => x.GetAllMusicContracts()).Returns(TestInputData.MusicContracts());
            inputFileReaderMock.Setup(x => x.GetAllDistributionPartnerContracts()).Returns(TestInputData.DistributionPartnerContracts());


            var musicContractsService = new MusicContractsService(inputFileReaderMock.Object);
            var musicContracts = musicContractsService.GetMusicContractsOfPartner(input);


            Assert.IsNotNull(musicContracts);
            Assert.AreEqual(4, musicContracts.Count());
        }

        [TestMethod]
        public void TestScenario_WhenUserEntersYouTube1stApril2012()
        {
            var inputFileReaderMock = new Mock<IInputFileReader>();
            var input = "YouTube 1st April 2012";

            inputFileReaderMock.Setup(x => x.GetAllMusicContracts()).Returns(TestInputData.MusicContracts());
            inputFileReaderMock.Setup(x => x.GetAllDistributionPartnerContracts()).Returns(TestInputData.DistributionPartnerContracts());


            var musicContractsService = new MusicContractsService(inputFileReaderMock.Object);
            var musicContracts = musicContractsService.GetMusicContractsOfPartner(input);


            Assert.IsNotNull(musicContracts);
            Assert.AreEqual(2, musicContracts.Count());

        }

        [TestMethod]
        public void TestScenario_WhenUserEntersYouTube27thDec2012()
        {
            var inputFileReaderMock = new Mock<IInputFileReader>();
            var input = "YouTube 27th Dec 2012";

            inputFileReaderMock.Setup(x => x.GetAllMusicContracts()).Returns(TestInputData.MusicContracts());
            inputFileReaderMock.Setup(x => x.GetAllDistributionPartnerContracts()).Returns(TestInputData.DistributionPartnerContracts());


            var musicContractsService = new MusicContractsService(inputFileReaderMock.Object);
            var musicContracts = musicContractsService.GetMusicContractsOfPartner(input);


            Assert.IsNotNull(musicContracts);
            Assert.AreEqual(4, musicContracts.Count());
        }
    }
}
