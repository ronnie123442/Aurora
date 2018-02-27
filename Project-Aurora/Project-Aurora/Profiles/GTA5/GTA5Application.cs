﻿using Aurora.Settings;
using Aurora.Settings.Layers;
using Aurora.Profiles.GTA5.Layers;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace Aurora.Profiles.GTA5
{
    public class GTA5 : Application
    {
        public GTA5()
            : base(new LightEventConfig { Name = "GTA 5", ID = "gta5", ProcessNames = new[] { "gta5.exe", "fivem.exe" }, ProfileType = typeof(GTA5Profile), OverviewControlType = typeof(Control_GTA5), GameStateType = typeof(GSI.GameState_GTA5), Event = new GameEvent_Generic(), IconURI = "Resources/gta5_64x64.png" })
        {
            var extra = new List<LayerHandlerEntry>
            {
                new LayerHandlerEntry("GTA5Background", "GTA 5 Background Layer", typeof(GTA5BackgroundLayerHandler)),
                new LayerHandlerEntry("GTA5PoliceSiren", "GTA 5 Police Siren Layer", typeof(GTA5PoliceSirenLayerHandler)),
            };

            Global.LightingStateManager.RegisterLayerHandlers(extra, false);

            foreach (var entry in extra)
            {
                Config.ExtraAvailableLayers.Add(entry.Key);
            }
        }
    }
}
