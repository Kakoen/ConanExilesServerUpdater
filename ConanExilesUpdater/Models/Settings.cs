﻿namespace ConanExilesUpdater.Models
{
    public class Settings
    {
        public Twitch Twitch { get; set; }
        public Discord Discord { get; set; }
        public Conan Conan { get; set; }
        public RCON RCON { get; set; }
        public Update Update { get; set; }
        public General General { get; set; }

        public Settings()
        {
            Twitch = new Twitch();
            Discord = new Discord();
            Conan = new Conan();
            RCON = new RCON();
            Update = new Update();
            General = new General();
        }
    }

    public class Twitch
    {
        public string OAuth { get; set; }
        public string Username { get; set; }
        public string Channel { get; set; }
    }

    public class Discord
    {
        public string DiscordToken { get; set; }
        public ulong ChannelId { get; set; }
    }

    public class RCON
    {
        public string RCONHost { get; set; }
        public int RCONPort { get; set; }
        public string RCONPassword { get; set; }

        public RCON()
        {
            RCONHost = "localhost";
            RCONPort = 25575;
        }
    }

    public class Conan
    {
        public string FolderPath { get; set; }
        public string Executable { get; set; }
        public string StartupParameters { get; set; }
        public bool RaidingProtectionHoursEnabled { get; set; }
        public int RaidingStartHour { get; set; }
        public int RaidingLengthInHours { get; set; }
        public bool AvatarsEnabledCertainHours { get; set; }
        public int AvatarActivationHour { get; set; }
        public int AvatarsActiveLengthInHours { get; set; }
        
        public Conan()
        {
            RaidingLengthInHours = 0;
            RaidingProtectionHoursEnabled = false;
            RaidingStartHour = 0;
            AvatarsEnabledCertainHours = false;
            AvatarActivationHour = 0;
            AvatarsActiveLengthInHours = 0;
        }
    }

    public class Update
    {
        public bool ShouldInstallSteamCmdIfMissing { get; set; }
        public bool ShouldInstallConanServerIfMissing { get; set; }
        public string SteamCmdPath { get; set; }
        public bool AnnounceDiscord { get; set; }
        public bool AnnounceTwitch { get; set; }
        public bool AnnounceRCON { get; set; }
        public int AnnounceMinutesBefore { get; set; }
        public int UpdateCheckInterval { get; set; }
        public int InstalledBuild { get; set; }
        public bool UpdateOnLaunch { get; set; }

        public Update()
        {
            AnnounceDiscord = false;
            AnnounceTwitch = false;
            AnnounceRCON = false;
            UpdateCheckInterval = 5;
            AnnounceMinutesBefore = 5;
            ShouldInstallSteamCmdIfMissing = false;
            ShouldInstallConanServerIfMissing = false;
            UpdateOnLaunch = false;
        }
    }

    public class General
    {
        public bool ShouldRestartConanOnNotRunning { get; set; }
        public int RestartServerAfterHours { get; set; }

        public General()
        {
            ShouldRestartConanOnNotRunning = true;
            RestartServerAfterHours = 0;
        }

    }
}
