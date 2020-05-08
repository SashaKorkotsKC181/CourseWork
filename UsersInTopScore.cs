using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;

namespace CourseWork
{
    public class UsersInTopScore : IXmlSerializable, IComparable<UsersInTopScore> 
    {
        string nick;
        int level;
        int score;
        DateTime date;

        public UsersInTopScore()
        {
            nick = "";
            level = 0;
            score = 0;
            date = DateTime.Today;
        }

        public UsersInTopScore(string nick_, int level_, int score_)
        {
            nick = nick_;
            level = level_;
            score = score_;
            date = DateTime.Today;
        }
        public string Nick
        {
            get
            {
                return nick;
            }
        }
        public int Level
        {
            get
            {
                return level;
            }
        }
        public int Score
        {
            get
            {
                return score;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
        }

        public int CompareTo(UsersInTopScore that)
        {
            return that.Score.CompareTo(this.Score);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("NickOfUser");
            writer.WriteValue(nick);
            writer.WriteEndElement();
            writer.WriteStartElement("Level");
            writer.WriteValue(level);
            writer.WriteEndElement();
            writer.WriteStartElement("Score");
            writer.WriteValue(score);
            writer.WriteEndElement();
            writer.WriteStartElement("Date");
            writer.WriteValue(date);
            writer.WriteEndElement();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            reader.Read();
            nick = reader.Value;
            reader.Read();
            reader.Read();
            reader.Read();
            level = Convert.ToInt32(reader.Value);
            reader.Read();
            reader.Read();
            reader.Read();
            score = Convert.ToInt32(reader.Value);
            reader.Read();
            reader.Read();
            reader.Read();
            date = DateTime.Parse(reader.Value);
            reader.Read();
            reader.Read();
            reader.Read();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}
