using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Xml;
namespace Transition
{
    public class StaticTile
    {
        private ushort m_TileID;
        private ushort m_AltIDMod;
        public ushort TileID
        {
            get
            {
                return this.m_TileID;
            }
            set
            {
                this.m_TileID = value;
            }
        }
        public ushort AltIDMod
        {
            get
            {
                return this.m_AltIDMod;
            }
            set
            {
                this.m_AltIDMod = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0:X4} [{1}]", this.m_TileID, this.m_AltIDMod);
        }
        public StaticTile()
        {
        }
        public StaticTile(ushort TileID, ushort AltIDMod)
        {
            this.m_TileID = TileID;
            this.m_AltIDMod = AltIDMod;
        }
        public StaticTile(XmlElement xmlInfo)
        {
            this.m_TileID = (ushort)XmlConvert.ToInt16(xmlInfo.GetAttribute("TileID"));
            this.m_AltIDMod = (ushort)XmlConvert.ToInt16(xmlInfo.GetAttribute("AltIDMod"));
        }
        public void Save(XmlTextWriter xmlInfo)
        {
            xmlInfo.WriteStartElement("StaticTile");
            xmlInfo.WriteAttributeString("TileID", StringType.FromInteger((int)this.m_TileID));
            xmlInfo.WriteAttributeString("AltIDMod", StringType.FromInteger((int)this.m_AltIDMod));
            xmlInfo.WriteEndElement();
        }
    }
}
