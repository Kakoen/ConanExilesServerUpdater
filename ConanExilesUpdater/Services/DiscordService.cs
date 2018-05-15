using System;
using System.IO;
using System.Net;
using ConanExilesUpdater.Models;
using Newtonsoft.Json;
using Serilog;

namespace ConanExilesUpdater.Services
{
    public class DiscordService
    {
        #region Properties

        private readonly Settings _settings;

        #endregion

        #region Constructor

        public DiscordService(Settings _settings)
        {
            this._settings = _settings;
        }

        #endregion

        #region Event Handling

        private void Client_Ready(object sender, EventArgs e)
        {
            Log.Information("Discord Connected!");
        }

        #endregion

        #region Public Methods

        public async void SendMessage(string message)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://discordapp.com/api/channels/" + _settings.Discord.ChannelId + "/messages");
                request.ContentType = "application/json";
                request.Method = "POST";
                request.Headers.Add("Authorization", "Bot " + _settings.Discord.DiscordToken);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        content = message
                    });
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            } catch(Exception e)
            {
                //oh well
            }
        }

        #endregion
    }
}
