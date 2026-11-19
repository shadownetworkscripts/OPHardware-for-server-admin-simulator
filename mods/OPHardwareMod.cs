using System;
using System.Collections.Generic;

namespace OPHardware
{
    public class OPHardwareMod : IServerAdminMod
    {
        public ModManifest GetManifest() => new ModManifest
        {
            Name           = "OP Hardware",
            Version        = "1.3.0",
            Author         = "ttvdemonyt",
            Description    = "Overpowered hardware at cheap prices, with a part at every size step.",
            MinGameVersion = "1.2.0",
            Tags           = new[] { "hardware", "economy" },
        };

        // One cheap, low-power part at the cap of every base-game chassis tier:
        //   1U (Basic/T1):  32 cores | 32 GB   | 10 Gbps  | 2 TB
        //   1U Pro (T1_5):  48 cores | 48 GB   | 25 Gbps  | 3 TB
        //   2U (T2):        64 cores | 64 GB   | 50 Gbps  | 8 TB
        //   3U (T2_5):      96 cores | 96 GB   | 100 Gbps | 12 TB
        //   4U Pro (T3):   128 cores | 1024 GB | 250 Gbps | 16 TB
        // A part shows up on every chassis whose cap is at or above its value.
        private static ModComponentData Part(string asset, string name, string type, int value, string from = null)
            => new ModComponentData
            {
                AssetName = asset, DisplayName = name, ComponentType = type,
                Value = value, UpgradeCost = 100f, PowerCostPerTick = 0.01f,
                UpgradesFromAssetName = from,
            };

        public IEnumerable<ModComponentData> GetComponents() => new[]
        {
            // CPU (cores)
            Part("Titan_CPU_4", "Titan CPU 4", "CPU", 4),
            Part("Titan_CPU_8", "Titan CPU 8", "CPU", 8, "Titan_CPU_4"),
            Part("Titan_CPU_12", "Titan CPU 12", "CPU", 12, "Titan_CPU_8"),
            Part("Titan_CPU_16", "Titan CPU 16", "CPU", 16, "Titan_CPU_12"),
            Part("Titan_CPU_24", "Titan CPU 24", "CPU", 24, "Titan_CPU_16"),
            Part("Titan_CPU_32", "Titan CPU 32", "CPU", 32, "Titan_CPU_24"),
            Part("Titan_CPU_48", "Titan CPU 48", "CPU", 48, "Titan_CPU_32"),
            Part("Titan_CPU_64", "Titan CPU 64", "CPU", 64, "Titan_CPU_48"),
            Part("Titan_CPU_I", "Titan CPU 96", "CPU", 96, "Titan_CPU_64"),
            Part("Titan_CPU_II", "Titan CPU 128", "CPU", 128, "Titan_CPU_I"),

            // RAM (GB)
            Part("Titan_RAM_4", "Titan RAM 4GB", "RAM", 4),
            Part("Titan_RAM_8", "Titan RAM 8GB", "RAM", 8, "Titan_RAM_4"),
            Part("Titan_RAM_12", "Titan RAM 12GB", "RAM", 12, "Titan_RAM_8"),
            Part("Titan_RAM_16", "Titan RAM 16GB", "RAM", 16, "Titan_RAM_12"),
            Part("Titan_RAM_24", "Titan RAM 24GB", "RAM", 24, "Titan_RAM_16"),
            Part("Titan_RAM_32", "Titan RAM 32GB", "RAM", 32, "Titan_RAM_24"),
            Part("Titan_RAM_48", "Titan RAM 48GB", "RAM", 48, "Titan_RAM_32"),
            Part("Titan_RAM_64", "Titan RAM 64GB", "RAM", 64, "Titan_RAM_48"),
            Part("Titan_RAM_96", "Titan RAM 96GB", "RAM", 96, "Titan_RAM_64"),
            Part("Titan_RAM_128", "Titan RAM 128GB", "RAM", 128, "Titan_RAM_96"),
            Part("Titan_RAM_256", "Titan RAM 256GB", "RAM", 256, "Titan_RAM_128"),
            Part("Titan_RAM_512", "Titan RAM 512GB", "RAM", 512, "Titan_RAM_256"),
            Part("Titan_RAM_Max", "Titan RAM 1TB", "RAM", 1024, "Titan_RAM_512"),

            // Network (Mbps)
            Part("Titan_NIC_100", "Titan NIC 100M", "Network", 100),
            Part("Titan_NIC_500", "Titan NIC 500M", "Network", 500, "Titan_NIC_100"),
            Part("Titan_NIC_1000", "Titan NIC 1G", "Network", 1000, "Titan_NIC_500"),
            Part("Titan_NIC_2500", "Titan NIC 2G", "Network", 2500, "Titan_NIC_1000"),
            Part("Titan_NIC_5000", "Titan NIC 5G", "Network", 5000, "Titan_NIC_2500"),
            Part("Titan_NIC_10000", "Titan NIC 10G", "Network", 10000, "Titan_NIC_5000"),
            Part("Titan_NIC_25000", "Titan NIC 25G", "Network", 25000, "Titan_NIC_10000"),
            Part("Titan_NIC_50000", "Titan NIC 50G", "Network", 50000, "Titan_NIC_25000"),
            Part("Titan_NIC_100000", "Titan NIC 100G", "Network", 100000, "Titan_NIC_50000"),
            Part("Titan_NIC_Max", "Titan NIC 250G", "Network", 250000, "Titan_NIC_100000"),

            // Storage (GB)
            Part("Titan_Storage_500", "Titan Storage 500GB", "Storage", 500),
            Part("Titan_Storage_1000", "Titan Storage 1TB", "Storage", 1000, "Titan_Storage_500"),
            Part("Titan_Storage_2000", "Titan Storage 2TB", "Storage", 2000, "Titan_Storage_1000"),
            Part("Titan_Storage_3000", "Titan Storage 3TB", "Storage", 3000, "Titan_Storage_2000"),
            Part("Titan_Storage_4000", "Titan Storage 4TB", "Storage", 4000, "Titan_Storage_3000"),
            Part("Titan_Storage_8000", "Titan Storage 8TB", "Storage", 8000, "Titan_Storage_4000"),
            Part("Titan_Storage_12000", "Titan Storage 12TB", "Storage", 12000, "Titan_Storage_8000"),
            Part("Titan_Storage_Max", "Titan Storage 16TB", "Storage", 16000, "Titan_Storage_12000"),
        };

        public IEnumerable<ModContractData> GetContracts() => new[]
        {
            new ModContractData
            {
                AssetName = "Titan_Contract_01", Category = "WebsiteHosting",
                ClientName = "Titan Dynamics",
                Description = "High-paying hosting deal.", IncomePerTick = 50f,
            },
            new ModContractData
            {
                AssetName = "Titan_Contract_02", Category = "SaaSHosting",
                ClientName = "Echo Holdings",
                Description = "Premium infrastructure contract.", IncomePerTick = 120f,
            },
        };

        public IEnumerable<ModServerData>          GetServers()           => Array.Empty<ModServerData>();
        public IEnumerable<ModRackData>            GetRacks()             => Array.Empty<ModRackData>();
        public IEnumerable<ModSoftwareData>        GetSoftware()          => Array.Empty<ModSoftwareData>();
        public IEnumerable<ModStaffData>           GetStaff()             => Array.Empty<ModStaffData>();
        public IEnumerable<ModAchievementData>     GetAchievements()      => Array.Empty<ModAchievementData>();
        public IEnumerable<ModChallengeData>       GetChallenges()        => Array.Empty<ModChallengeData>();
        public IEnumerable<ModRandomEventData>     GetRandomEvents()      => Array.Empty<ModRandomEventData>();
        public IEnumerable<ModRivalData>           GetRivals()            => Array.Empty<ModRivalData>();
        public IEnumerable<ModLoanOfferData>       GetLoanOffers()        => Array.Empty<ModLoanOfferData>();
        public IEnumerable<ModInsurancePolicyData> GetInsurancePolicies() => Array.Empty<ModInsurancePolicyData>();
        public IEnumerable<ModSeasonalEventData>   GetSeasonalEvents()    => Array.Empty<ModSeasonalEventData>();
        public IEnumerable<ModTerminalCommandData> GetTerminalCommands()  => Array.Empty<ModTerminalCommandData>();
        public IEnumerable<ModNewsEntryData>       GetNewsEntries()       => Array.Empty<ModNewsEntryData>();
        public IEnumerable<ModZeroDayData>         GetZeroDayExploits()   => Array.Empty<ModZeroDayData>();
        public IEnumerable<ModLocalizationEntry>   GetLocalization(string language) => Array.Empty<ModLocalizationEntry>();
        public ModGameHooks                        GetHooks()             => null;
    }
}
