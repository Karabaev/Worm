namespace Game.Store
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    using System.Xml.Serialization;
    using System.Xml;
    using System.Xml.Schema;

    [Serializable]
    public abstract class StoreItem
    {
        [XmlElement("Name")] public string Name { get; set; }
        [XmlElement("Description")] public string Description { get; set; }
        [XmlElement("Icon")] public Sprite Icon { get; set; }
        [XmlElement("Price")] public int Price { get; set; }
    }
}

