using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Backend
{
    static class DataAccess
    {
        public static bool CheckSomething()
        {
            return true;
        }

        static void SerializeToXml<T>(T data, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data);
            }
        }

        public static List<Team> LoadSavedTeams()
        {
            return new List<Team>();
        }
    }
}
