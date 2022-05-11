using GrmDeveloperTest.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GrmDeveloperTest.Extensions;
using System.Text;
using System.Reflection;

namespace GrmDeveloperTest.FileReader
{
    public class InputFileReader : IInputFileReader
    {
        public const string MusicContractFileName = "MusicContracts";
        public const string DistributionPartnerName = "DistributionPartnerContracts";
        public const char PipeDelimiter = '|';

        public InputFileReader()
        {
        }

        public IEnumerable<MusicContract> GetAllMusicContracts()
        {
            List<MusicContract> musicContracts = new List<MusicContract>();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"Inputs\{MusicContractFileName}.txt");
            var lines = File.ReadAllLines(path).ToList();

            foreach (string line in lines.Skip(1))
            {
                string[] musicData = line.Split(PipeDelimiter);
                DateTime outStartDate;
                DateTime outEndDate;
                musicContracts.Add(new MusicContract
                {
                    Artist = musicData[0],
                    Title = musicData[1],
                    Usages = musicData[2].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(u => u.Trim()),
                    StartDate = musicData[3].TryParseNewDateFormat(out outStartDate) ? outStartDate : DateTime.Parse(musicData[3]),
                    EndDate = musicData[4].TryParseNewDateFormat(out outEndDate) ? outEndDate : DateTime.Now,
                });
            }

            return musicContracts;
        }

        public IEnumerable<DistributionPartnerContract> GetAllDistributionPartnerContracts()
        {
            List<DistributionPartnerContract> distributionPartnerContracts = new List<DistributionPartnerContract>();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"Inputs\{DistributionPartnerName}.txt");
            var lines = File.ReadAllLines(path).ToList();

            foreach (string line in lines.Skip(1))
            {
                string[] partnerData = line.Split(PipeDelimiter);
                distributionPartnerContracts.Add(new DistributionPartnerContract
                {
                    Partner = partnerData[0],
                    Usage = partnerData[1]
                });
            }

            return distributionPartnerContracts;
        }
    }
}
