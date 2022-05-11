using GrmDeveloperTest.DataModels;
using GrmDeveloperTest.Extensions;
using GrmDeveloperTest.FileReader;
using GrmDeveloperTest.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrmDeveloperTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                    .AddTransient<IInputFileReader, InputFileReader>()
                    .AddTransient<IMusicContractsService, MusicContractsService>()
                .BuildServiceProvider();

            string partnerNameAndEffectiveDate;
            Console.Write("Please Enter Delivery partner name and an Effective date: ");
            partnerNameAndEffectiveDate = Console.ReadLine();

            var musicContractsService = new MusicContractsService(serviceProvider.GetService<IInputFileReader>());
            var musicContracts = musicContractsService.GetMusicContractsOfPartner(partnerNameAndEffectiveDate);

            ShowResults(musicContracts);
            Console.ReadLine();
        }


        public static void ShowResults(IEnumerable<MusicContract>  musicContracts)
        {
            Console.WriteLine("Artist|Title|Usages|StartDate|EndDate");
            foreach (var musicContract in musicContracts)
            {
                Console.WriteLine($"{musicContract.Artist}|{musicContract.Title}|{string.Join(',', musicContract.Usages)}|{musicContract.StartDate}|{musicContract.EndDate}");
            }
        }

    }
}
