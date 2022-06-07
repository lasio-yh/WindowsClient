using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
namespace Core.Model
{
    [XmlRoot(ElementName = "document")]
    public class IMetaData
    {
        [XmlElement(ElementName = "slide")]
        public List<Item1> Value { get; set; }
    }

    public class Item1
    {
        [XmlAttribute("effect")]
        public string Effect { get; set; }

        [XmlElement(ElementName = "object")]
        public List<Item2> Value { get; set; }
    }

    public class Item2
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("target")]
        public string Target { get; set; }

        [XmlAttribute("origin")]
        public string Origin { get; set; }

        [XmlAttribute("effect")]
        public string Effect { get; set; }

        [XmlAttribute("x")]
        public string X { get; set; }

        [XmlAttribute("y")]
        public string Y { get; set; }

        [XmlAttribute("width")]
        public string Width { get; set; }

        [XmlAttribute("height")]
        public string Height { get; set; }

        [XmlAttribute("alpha")]
        public string Alpha { get; set; }

        [XmlAttribute("group")]
        public string Group { get; set; }

        [XmlElement(ElementName = "text")]
        public Text Text { get; set; }

        [XmlElement(ElementName = "metadata")]
        public MetaData MetaData { get; set; }
    }

    public class Text
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("height")]
        public string Height { get; set; }

        [XmlAttribute("width")]
        public string Width { get; set; }

        [XmlAttribute("weight")]
        public string Weight { get; set; }

        [XmlAttribute("align")]
        public string Align { get; set; }

        [XmlAttribute("italic")]
        public string Italic { get; set; }

        [XmlAttribute("interval")]
        public string Interval { get; set; }

        [XmlAttribute("lineinterval")]
        public string LineInterval { get; set; }

        [XmlAttribute("texttype")]
        public string TextType { get; set; }

        [XmlAttribute("fonttype")]
        public string FontType { get; set; }

        [XmlAttribute("blur")]
        public string Blur { get; set; }

        [XmlAttribute("shadow")]
        public string Shadow { get; set; }

        [XmlAttribute("shadowblur")]
        public string ShadowBlur { get; set; }

        [XmlAttribute("shadowx")]
        public string ShadowX { get; set; }

        [XmlAttribute("shadowy")]
        public string ShadowY { get; set; }

        [XmlAttribute("shadowalpha")]
        public string ShadowAlpha { get; set; }

        [XmlAttribute("face")]
        public string Face { get; set; }

        [XmlAttribute("edge")]
        public string Edge { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class MetaData
    {
        [XmlAttribute("format")]
        public string Format { get; set; }

        [XmlAttribute("repeat")]
        public string Repeat { get; set; }

        [XmlAttribute("frames")]
        public string Frames { get; set; }

        [XmlAttribute("ani")]
        public string Ani { get; set; }

        [XmlAttribute("anispd")]
        public string AniSpd { get; set; }

        [XmlAttribute("dis")]
        public string Dis { get; set; }

        [XmlAttribute("size")]
        public string Size { get; set; }

        [XmlAttribute("frequency")]
        public string Frequency { get; set; }

        [XmlAttribute("indexcount")]
        public string IndexCount { get; set; }

        [XmlAttribute("chartheight")]
        public string ChartHeight { get; set; }

        [XmlAttribute("startangle")]
        public string StartAngle { get; set; }

        [XmlAttribute("incliengle")]
        public string Incliengle { get; set; }

        [XmlAttribute("gradient")]
        public string Gradient { get; set; }

        [XmlAttribute("linecolor")]
        public string LineColor { get; set; }

        [XmlAttribute("linealpha")]
        public string LineAlpha { get; set; }

        [XmlAttribute("gradval")]
        public string Gradval { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
