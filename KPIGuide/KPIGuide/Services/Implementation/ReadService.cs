using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using KPIGuide.Models;
using KPIGuide.Services.Interfaces;
using Newtonsoft.Json;

namespace KPIGuide.Services.Implementation
{
    public class ReadService : IReadService
    {
        private class Rootobject
        {
            public List<Place> Places { get; set; }
        }
        public IEnumerable<Place> ReadAllPlaces()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ReadService)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("KPIGuide.LibJsonResource.json");

            List<Place> result = new List<Place>();
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<Rootobject>(json).Places;
            }

            return result;
        }
	}
}
