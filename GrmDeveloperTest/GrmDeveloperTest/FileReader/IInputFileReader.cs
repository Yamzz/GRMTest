using GrmDeveloperTest.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrmDeveloperTest.FileReader
{
    public interface IInputFileReader
    {
        IEnumerable<MusicContract> GetAllMusicContracts();
        IEnumerable<DistributionPartnerContract> GetAllDistributionPartnerContracts();
    }
}
