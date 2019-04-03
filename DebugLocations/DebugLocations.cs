using System;
using System.Collections.Generic;
using System.Linq;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;

namespace DebugLocations
{
    public class Locations : BaseScript
    {
        public static List<string> LocationsNew = new List<string>();
        
        public Locations()
        {
            API.RegisterCommand("loc", new Action<int, List<object>, string>((source, arguments, raw) => { GetLocation(); }), false);
            API.RegisterCommand("WriteLocations", new Action<int, List<object>, string>((source, arguments, raw) => { WriteLocations(); }), false);
            API.RegisterCommand("ClearLocations", new Action<int, List<object>, string>((source, arguments, raw) => { CLearLocations(); }), false);
            API.RegisterCommand("RemoveLastLoc", new Action<int, List<object>, string>((source, arguments, raw) => { Removelast(); }), false);
        }
        
        private async void CLearLocations()
        {
            await Delay(0);
            LocationsNew.Clear();
        }
        
        private async void Removelast()
        {
            await Delay(0);
            if(LocationsNew.Any()) //prevent IndexOutOfRangeException for empty list
            {
                LocationsNew.RemoveAt(LocationsNew.Count - 1);
            }
        }
        
        private async void GetLocation()
        {
            await Delay(0);
            var PlayerCoords = GetEntityCoords(PlayerPedId(), true);
            float FloatCoords1 = PlayerCoords.X;
            float FloatCoords2 = PlayerCoords.Y;
            float FloatCoords3 = PlayerCoords.Z;
            float Heading = GetEntityHeading(PlayerPedId());
            
            LocationsNew.Add($"{FloatCoords1},{FloatCoords2},{FloatCoords3},{Heading}");
            //Debug.Write($"\n[AlsekLocation]:::{FloatCoords1},{FloatCoords2},{FloatCoords3},{Heading}\n");
        }

        private async void WriteLocations()
        {
            await Delay(0);
            Debug.Write($"\n[DebugLocations]:::[Start]\n");
            foreach (object o in LocationsNew)
            {
                Debug.Write($"\n[DebugLocations]:{o}");
            }
            Debug.Write($"\n[DebugLocations]:::[End]\n");
        }
    }
}