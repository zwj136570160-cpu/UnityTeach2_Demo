using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;


public class SerizlizerDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
{
    public XmlSchema GetSchema()
    {
        return null;
    }

    //自定义字典的反序列化规则
    public void ReadXml(XmlReader reader)
    {
        XmlSerializer keySer = new XmlSerializer(typeof(TKey));
        XmlSerializer valueSer = new XmlSerializer(typeof(TValue));
        //跳过根节点
        reader.Read();
        //判断当前不是元素节点 结束 就进行反序列化
        while (reader.NodeType != XmlNodeType.EndElement)
        {
            //反序列化键
            TKey key = (TKey)keySer.Deserialize(reader);
            //反序列化值
            TValue value = (TValue)valueSer.Deserialize(reader);
            //存储到字典中
            this.Add(key, value);
        }
    }

    //自定义字典的序列化规则
    public void WriteXml(XmlWriter writer)
    {
        XmlSerializer keySer = new XmlSerializer(typeof(TKey));
        XmlSerializer valueSer = new XmlSerializer(typeof(TValue));

        foreach (KeyValuePair<TKey, TValue> kv in this)
        {
            //键值对 的序列化
            keySer.Serialize(writer, kv.Key);
            valueSer.Serialize(writer, kv.Value);
        }
    }
}
