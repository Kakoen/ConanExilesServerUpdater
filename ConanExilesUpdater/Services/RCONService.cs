using ConanExilesUpdater.Models;
using MinecraftServerRCON;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanExilesUpdater.Services
{
    public class RCONService
    {

        private readonly Settings _settings;
        private readonly RCONClient rcon;

        public RCONService(Settings settings)
        {
            Log.Information("Initializing RCON service...");

            this._settings = settings;

            RCON rconSettings = _settings.RCON;
            rcon = RCONClient.INSTANCE;

            rcon.setupStream(rconSettings.RCONHost, rconSettings.RCONPort, rconSettings.RCONPassword);

            Log.Information("RCON service initialized!");
        }

        public void SendMessage(string message)
        {
            try
            {
                string command = "Broadcast " + message;
                Log.Information("Sending RCON command: " + command);
                rcon.fireAndForgetMessage(RCONMessageType.Command, command);
            } catch(Exception e) {
                Log.Error(e, "Error when sending RCON Message");
            }
        }

    }
}
