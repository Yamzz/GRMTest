using GrmDeveloperTest.DataModels;
using GrmDeveloperTest.Extensions;
using GrmDeveloperTest.FileReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrmDeveloperTest.Services
{
    public class MusicContractsService : IMusicContractsService
    {
        private IEnumerable<MusicContract> musicContracts;
        private IEnumerable<DistributionPartnerContract> distributionPartnerContracts;

        public MusicContractsService(IInputFileReader inputFileReader)
        {
            musicContracts = inputFileReader.GetAllMusicContracts();
            distributionPartnerContracts = inputFileReader.GetAllDistributionPartnerContracts();
        }

        public IEnumerable<MusicContract> GetMusicContractsOfPartner(string partnerNameAndEffectiveDate)
        {
            string[] words = partnerNameAndEffectiveDate.Split(' ');
            var partnerName = words[0];
            var effectiveDate = string.Join(" ", partnerNameAndEffectiveDate.Split(' ').Skip(1));

            var formattedEffectiveDate = effectiveDate.Trim().TryParseNewDateFormat(out DateTime date) ? date : throw new Exception($"Wrong Date Formate");

            // filter by name first
            var usage = distributionPartnerContracts.FirstOrDefault(dpc => dpc.Partner == partnerName).Usage;

            // then by date before effectiveness 
            var activeMusicContracts = musicContracts.Where(musciContract => musciContract.Usages.Contains(usage)
                                                      && musciContract.StartDate <= formattedEffectiveDate &&
                                                      ((musciContract.EndDate.HasValue && musciContract.EndDate.Value >= formattedEffectiveDate) || !musciContract.EndDate.HasValue));

            return activeMusicContracts;
        }
    }
}
