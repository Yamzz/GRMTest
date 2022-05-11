using GrmDeveloperTest.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrmDeveloperTest.Services
{
    public interface IMusicContractsService
    {
        IEnumerable<MusicContract> GetMusicContractsOfPartner(string partnerNameAndEffectiveDate);
    }
}
