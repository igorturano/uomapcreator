using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Xml;
namespace Transition
{
    public class MapTile
    {
        private ushort m_TileID;
        private ushort m_AltID;
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
                return this.m_AltID;
            }
            set
            {
                this.m_AltID = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0:X4} [{1}]", this.m_TileID, this.m_AltID);
        }
        public MapTile(ushort TileID, ushort AltID)
        {
            this.m_TileID = TileID;
            this.m_AltID = AltID;
        }
        public MapTile()
        {
        }
        public MapTile(XmlElement xmlInfo)
        {
            try
            {
                this.m_TileID = (ushort)XmlConvert.ToInt16(xmlInfo.GetAttribute("TileID"));
            }
            catch (Exception expr_21)
            {
                ProjectData.SetProjectError(expr_21);
                this.m_TileID = (ushort)ShortType.FromString("&H" + xmlInfo.GetAttribute("TileID"));
                ProjectData.ClearProjectError();
            }
            this.m_AltID = (ushort)XmlConvert.ToInt16(xmlInfo.GetAttribute("AltIDMod"));
        }
        public void Save(XmlTextWriter xmlInfo)
        {
            xmlInfo.WriteStartElement("MapTile");
            xmlInfo.WriteAttributeString("TileID", StringType.FromInteger((int)this.m_TileID));
            xmlInfo.WriteAttributeString("AltIDMod", StringType.FromInteger((int)this.m_AltID));
            xmlInfo.WriteEndElement();
        }
    }
}
